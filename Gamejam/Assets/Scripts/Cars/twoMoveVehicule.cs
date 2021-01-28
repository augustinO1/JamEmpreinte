using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class twoMoveVehicule : MonoBehaviour
{
    Vector3 tempPos;
    public float chrono;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        tempPos = transform.position;
        chrono += Time.deltaTime;
        if (chrono > 0.05) {
            chrono = 0;
            tempPos.x -= 1f;
            transform.position = tempPos;
            if (tempPos.x < -436) {
                tempPos.x -= -250;
                transform.position = tempPos;
            }
        }
    }
}