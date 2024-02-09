using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    private Dictionary<string, int> _inventory = new()
    {
        ["Gold"] = 0,
        ["Wood"] = 0
    };

    public static UnityEvent<string, int> UpdateOnUI = new();

    private void Start()
    {
        Resource.ItemPicked.AddListener(AddResource);
    }

    private void AddResource(string resource, int value)
    {
        _inventory[resource] += value;
        UpdateOnUI.Invoke(resource, _inventory[resource]);
    }

    private void RemoveResource(string resource, int value)
    {
        _inventory[resource] -= value;
        UpdateOnUI.Invoke(resource, _inventory[resource]);
    }
}
