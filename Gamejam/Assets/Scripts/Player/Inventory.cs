using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private int _maxItems;
    private int _usedSlots;
    private Dictionary<Items, int> _items;
    private InventoryText _trashBagText;
    private InventoryText _paperText;
    private InventoryText _bagStateText;
    
    public enum Items
    {
        Paper,
        TrashBag,
    }

    public static Dictionary<Items, int> ItemSize = new Dictionary<Items, int>
    {
        {Items.Paper, 1},
        {Items.TrashBag, 5}
    };

    void Awake()
    {
        _maxItems = 50;
        _usedSlots = 0;
        _items = new Dictionary<Items, int>();
        foreach (Items item in Enum.GetValues(typeof(Items)))
        {
            _items[item] = 0;
        }
    }

    private void Start()
    {
        _trashBagText = transform.GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetComponent<InventoryText>();
        //_trashBagText = transform.Find("TrashBagScore").gameObject.GetComponent<InventoryText>();
        _paperText = transform.GetChild(0).GetChild(0).GetChild(2).GetChild(1).GetComponent<InventoryText>();
        //_paperText = transform.Find("PaperScore").gameObject.GetComponent<InventoryText>();
        _bagStateText = transform.GetChild(0).GetChild(0).GetChild(2).GetChild(2).GetComponent<InventoryText>();
        //_bagStateText = transform.Find("BagStateScore").gameObject.GetComponent<InventoryText>();
    }

    public bool AddItem(Items item)
    {
        if (ItemSize[item] + _usedSlots > _maxItems)
            return false;
        _usedSlots += ItemSize[item];
        _items[item] += 1;
        _displayScore(item);
        return true;
    }

    private void _displayScore(Items item)
    {
        if (item == Items.Paper)
        {
            _paperText.SetState(_items[item].ToString());
            _bagStateText.SetState(_usedSlots.ToString() + "/" + _maxItems.ToString());
        } else if (item == Items.TrashBag)
        {
            _paperText.SetState(_items[item].ToString());
            _bagStateText.SetState(_usedSlots.ToString() + "/" + _maxItems.ToString());
        }
    }

    public bool Contains(Items item)
    {
        if (_items[item] > 0)
            return true;
        return false;
    }

    public int GetAllItemInstances(Items item)
    {
        int nb = _items[item];
        _items[item] = 0;
        _usedSlots -= ItemSize[item] * nb;
        _displayScore(item);
        return nb;
    }
}
