using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bin : Interactable
{
    public AudioClip binSound;
    
    private GameObject _player;
    private Inventory _inventory;
    private ScoreScript _score;

    private SetParticleRate _particles;

    private void Start()
    {
        _player = GameObject.Find("Player");
        _inventory = _player.GetComponent<Inventory>();
        _score = GameObject.Find("Player").GetComponent<ScoreScript>();
        _particles = transform.gameObject.GetComponentInParent<SetParticleRate>();
    }

    public override void Interact()
    {
        if (_inventory.Contains(Inventory.Items.Paper))
        {
            int nb = _inventory.GetAllItemInstances(Inventory.Items.Paper);
            MakeSound(binSound);
            _score.AddScore(-10);
            _particles.Trigger();
            Debug.Log("Throwed " + nb + " papers to bin.");
        }
    }

    private void MakeSound(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, transform.position);
    }
}
