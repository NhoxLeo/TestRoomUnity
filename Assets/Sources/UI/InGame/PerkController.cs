﻿using UnityEngine;
using UnityEngine.UI;

public class PerkController : MonoBehaviour
{
    [Header("References")]
    public Image icon = null;

    private int _index = 0;

    public void Initialize(int index)
    {
        _index = index;
    }

    public void UpdateContent(Perk perk)
    {
        icon.sprite = perk.icon;
        icon.enabled = true;
    }
}