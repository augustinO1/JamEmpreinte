using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampMalusManager : MonoBehaviour
{
    private DayLightScript _dayLight;
    private ScoreScript _score;

    private float _malusTimer;
    private float _malusTimerInitializer;
    // Start is called before the first frame update
    void Start()
    {
        _malusTimerInitializer = 20f;
        _malusTimer = _malusTimerInitializer;
        _dayLight = DayLightScript.script;
        _score = GameObject.Find("Player").GetComponent<ScoreScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_dayLight.IsDay())
        {
            _malusTimer -= Time.deltaTime;
            if (_malusTimer < 0)
            {
                _malusTimer = _malusTimerInitializer;
                _score.AddScore(10);
            }
        }
    }
}
