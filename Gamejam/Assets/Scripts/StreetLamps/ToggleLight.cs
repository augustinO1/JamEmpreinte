using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ToggleLight : MonoBehaviour
{
    private bool _state;
    private GameObject _light;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        _state = Convert.ToBoolean(Random.Range(0, 2));
        _light = transform.GetChild(0).gameObject;
        _light.SetActive(_state);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Toggle()
    {
        _state = !_state;
        _light.SetActive(_state);
        return _state;
    }
}
