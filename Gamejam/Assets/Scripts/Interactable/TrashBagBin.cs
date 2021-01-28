using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBagBin : Interactable
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
        if (_inventory.Contains(Inventory.Items.TrashBag))
        {
            int nb = _inventory.GetAllItemInstances(Inventory.Items.TrashBag);
            MakeSound(binSound);
            _score.AddScore(-60);
            _particles.Trigger();
            Debug.Log("Throwed " + nb + " trash bags to bin.");
        }
    }

    private void MakeSound(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, transform.position);
    }
}
