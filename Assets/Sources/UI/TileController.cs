﻿using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TileController : Button
{
    public Image background = null;
    public TextMeshProUGUI title = null;
    public Color normalTitleColor = Color.white;
    public Color selectedTitleColor = Color.white;
    public Image icon = null;
    public float iconAnimationTime = 0.25f;
    public LeanTweenType iconAnimationIn = LeanTweenType.linear;
    public LeanTweenType iconAnimationOut = LeanTweenType.linear;

    public ProgressBarController confirmBar = null;
    public float confirmDelay = 0.25f;

    private LTDescr _confirmAnimation = null;

    public override void OnSelect(BaseEventData eventData)
    {
        if (background != null)
        {
            background.color = colors.selectedColor;
        }

        if (title != null)
        {
            title.color = selectedTitleColor;
        }

        targetGraphic.color = colors.selectedColor;

        LeanTween.scale(icon.gameObject, Vector3.one * 1.1f, iconAnimationTime).setEase(iconAnimationIn);
    }

    public override void OnDeselect(BaseEventData eventData)
    {
        if (background != null)
        {
            background.color = colors.normalColor;
        }

        if (title != null)
        {
            title.color = normalTitleColor;
        }

        targetGraphic.color = colors.normalColor;

        LeanTween.scale(icon.gameObject, Vector3.one, iconAnimationTime).setEase(iconAnimationOut);
    }

    public void ConfirmSelection()
    {
        _confirmAnimation = LeanTween.value(0f, 100f, confirmDelay).setOnUpdate(ConfirmProgress).setOnComplete(ConfirmComplete);
    }

    private void ConfirmProgress(float progress)
    {
        confirmBar.current = Mathf.RoundToInt(progress);
    }

    private void ConfirmComplete()
    {
        onClick.Invoke();
    }

    public void CancelSelection()
    {
        if (_confirmAnimation != null)
        {
            LeanTween.cancel(_confirmAnimation.id);

            confirmBar.current = 0;
        }
    }
}