using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class ScoreColor : MonoBehaviour
{
    private int _maxScore;
    private int _minScore;
        
    private Color _color;

    private UnityEngine.UI.Image _fill;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _fill = gameObject.GetComponent<UnityEngine.UI.Image>();
    }

    public void Init(int min, int max)
    {
        _minScore = min;
        _maxScore = max;
    }

    public void SetScore(int score)
    {
        float percentage = ((float)(score - _minScore) / (float)(_maxScore - _minScore));
        _color = new Color(0, (1-percentage), 0);
        _fill.color = _color;
    }
}
