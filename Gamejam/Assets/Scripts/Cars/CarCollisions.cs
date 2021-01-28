using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollisions : MonoBehaviour
{
    private ScoreScript _score;

    private void Start()
    {
        _score = GameObject.Find("Player").GetComponent<ScoreScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            _score.KillPlayer();
        }
    }
}
