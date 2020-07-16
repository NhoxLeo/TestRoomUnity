﻿using System;
using UnityEngine;

/// <summary>
/// Define what to do when enemy dies
/// </summary>
[Serializable]
public class EnemyStateDie : CharacterFSM.CharacterState
{
    public GameObject fx = null;

    private const string ANIMATION_PARAM = "Die";

    public override void Enter()
    {
        character.animator.SetTrigger(ANIMATION_PARAM);
    }

    public override void Exit()
    {
        CharacterGameEvent.instance.Died(character.data);

        if (fx != null)
        {
            GameObject currentFx = GamePoolManager.instance.UseFromPool(fx.name);

            currentFx.transform.position = character.transform.position;
            currentFx.transform.rotation = character.transform.rotation;

            currentFx.SetActive(true);
        }
    }
}