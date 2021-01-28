using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LampScript : Interactable
{
    public AudioClip source;
    
    private LampManager _lampManager;

    private bool _state;
    private GameObject _light;

    private float _timer;
    private ScoreScript _score;

    private float _initialTimer;

    private void Awake()
    {
        _initialTimer = Random.Range(1000, 2000) / 100f;
    }

    // Start is called before the first frame update
    void Start()
    {
        _state = Convert.ToBoolean(Random.Range(0, 2));
        _lampManager = LampManager.manager;
        _score = GameObject.Find("Player").GetComponent<ScoreScript>();
        _light = transform.GetChild(0).gameObject;
        _lampManager.Toggle(_state, true);
    }

    public override void Interact()
    {
        this._toggle();
        AudioSource.PlayClipAtPoint(source, transform.position);
    }

    private void _toggle()
    {
        _state = !_state;
        _light.SetActive(_state);
        _lampManager.Toggle(_state);
        if (_state)
            _timer = _initialTimer;
    }

    private void Update()
    {
        if (_state)
        {
            _timer -= Time.deltaTime;
            if (_timer < 0)
            {
                _timer = _initialTimer;
                _score.AddScore(1);
            }
        }
    }
}
