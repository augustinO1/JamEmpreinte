using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderPosition : MonoBehaviour
{
    private Slider _slider;
    // Start is called before the first frame update
    void Start()
    {
        _slider = gameObject.GetComponent<Slider>();
    }

    public void Init(int min, int max)
    {
        _slider.minValue = min;
        _slider.maxValue = max;
    }
    
    public void SetScore(int score)
    {
        _slider.value = score;
    }
}
