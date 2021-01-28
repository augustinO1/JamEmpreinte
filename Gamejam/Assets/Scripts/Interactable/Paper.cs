using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : Interactable
{
    private GameObject _player;
    private Inventory _inventory;
    
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player");
        _inventory = _player.GetComponent<Inventory>();
    }

    public override void Interact()
    {
        if (_inventory.AddItem(Inventory.Items.Paper))
            Destroy(transform.parent.gameObject);
    }
}
