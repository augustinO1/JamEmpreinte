using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ray_pick : MonoBehaviour
{
    private float _range { get; set; }
    private void Awake()
    {
        _range = 7f;
    }

    void Update() {
        this.GetInteractableObject()?.Interact();
    }

    private Interactable GetInteractableObject()
    {
        Debug.DrawRay(transform.position, transform.forward * _range, Color.green);

        if (Input.GetKeyDown(KeyCode.E))
        {
            //Debug.DrawRay(transform.position, transform.forward * _range, Color.red);
            RaycastHit[] hits = Physics.RaycastAll(transform.position, transform.forward, _range);
            foreach (RaycastHit hit in hits)
            {
                Debug.Log(hit.transform.name);
                Interactable res;
                if (hit.transform.TryGetComponent(out res))
                    return res;
            }
        }

        return null;
    }
}