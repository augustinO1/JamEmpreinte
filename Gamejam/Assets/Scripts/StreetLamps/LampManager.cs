using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LampManager : MonoBehaviour
{
    public static LampManager manager;
    
    private int _lampOnCount;

    private void Awake()
    {
        if (manager != null)
        {
            Debug.Log("Error: multiple instances of LampManager.");
            return;
        }
        manager = this;
        _lampOnCount = 0;
    }
    
    public void Toggle(bool state, bool init = false)
    {
        _lampOnCount += state ? 1 : init ? 0 : -1;
    }

    
}
