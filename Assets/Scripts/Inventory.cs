using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private TMP_Text _goldCountText;
    [SerializeField] private TMP_Text _woodCountText;

    private int _goldCount;
    private int _woodCount;

    private void Start()
    {
        Gold.OnPickUpGold.AddListener(AddMoney);
        Wood.OnPickUpWood.AddListener(AddWood);
    }

    private void AddWood()
    {
        _woodCount++;
        _woodCountText.text = "Wood: " + _woodCount.ToString(); 
    }

    private void AddMoney(int gold)
    {
        _goldCount += gold;
        _goldCountText.text = "Gold: " + _goldCount.ToString();
    }
}
