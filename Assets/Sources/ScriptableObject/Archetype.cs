﻿using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Archetype", menuName = "ScriptableObjects/Archetype")]
[Serializable]
public class Archetype : DescriptiveObject
{
    public static readonly string SAVE_PATH = "PLAYER_ARCHETYPE";

    public CharacterEnum character = CharacterEnum.NONE;

    public Player configuration = null;

    public AnimatorOverrideController animationController = null;
    public PlayerStateAttackEffects attackEffects = null;

    public GearController gearLeft = null;
    public GearController gearRight = null;

    public void Save(string path)
    {
        PlayerPrefs.SetString(path, JsonUtility.ToJson(this));
    }

    public static Archetype Load(string path)
    {
        string serialized = PlayerPrefs.GetString(path);
        Archetype archetype = ScriptableObject.CreateInstance<Archetype>();

        JsonUtility.FromJsonOverwrite(serialized, archetype);

        return archetype;
    }
}