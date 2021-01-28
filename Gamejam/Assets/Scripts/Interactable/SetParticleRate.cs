using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetParticleRate : MonoBehaviour
{
    public int rate;
    private ParticleSystem _particle; 
    // Start is called before the first frame update
    void Start()
    {
        _particle = transform.GetChild(1).GetComponent<ParticleSystem>();
        ParticleSystem.EmissionModule emission = _particle.emission;
        emission.rateOverTime = rate;
    }

    public void Trigger()
    {
        _particle.Play();
    }
}
