using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour
{
    private int _winScore;
    private int _loseScore;
    private int _currentScore;

    private ScoreColor _scoreColor;
    private SliderPosition _sliderPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        _winScore = 50;
        _loseScore = 650;
        _currentScore = 350;
        _scoreColor = transform.GetChild(0).GetChild(0).GetChild(0).GetChild(1).GetChild(0).GetComponent<ScoreColor>();
        _sliderPosition = transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<SliderPosition>();
        _sliderPosition.Init(_winScore, _loseScore);
        _scoreColor.Init(_winScore, _loseScore);
    }

    private void Update()
    {
        if (_currentScore <= _winScore)
        {
            Debug.Log("WIN!");
            SceneManager.LoadScene("Win");
        }
        else if (_currentScore >= _loseScore)
        {
            Debug.Log("LOOSE BOOOOOOUUUUUH!");
            SceneManager.LoadScene("Lose");
        }
    }

    public void AddScore(int score)
    {
        _currentScore += score;
        _scoreColor.SetScore(_currentScore);
        _sliderPosition.SetScore(_currentScore);
    }

    public void KillPlayer()
    {
        _currentScore = _loseScore * 10;
    }
}
