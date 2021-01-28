using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayLightScript : MonoBehaviour
{
    // Start is called before the first frame update

    Light sun;
    public float speed = 1f;

    public static DayLightScript script;

    private void Awake()
    {
        if (script != null)
        {
            Debug.Log("Error: multiple instances of DayLightScript.");
            return;
        }

        script = this;
    }

    void Start()
    {
        sun = GetComponent<Light>();

    }

    // Update is called once per frame
    void Update()
    {
        sun.transform.Rotate(Vector3.right * speed * Time.deltaTime);
    }

    public bool IsDay() {
        Vector3 rot = sun.transform.rotation.eulerAngles;
        if (rot.x > 0 && rot.x < 90)
            return true;
        else
            return false;
    }
}