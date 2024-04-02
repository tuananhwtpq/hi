using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using GameTool;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour
{
    private int maxWidth = 1600;
    public Image yellowBar;
    public TextMeshProUGUI loadingText;

    private void Start()
    {
        yellowBar.rectTransform.DOSizeDelta(new Vector2(maxWidth, yellowBar.rectTransform.sizeDelta.y), 5).SetEase(Ease.Linear).OnComplete(
            () =>
            {
                LoadSceneManager.Instance.LoadScene("Choose Bird");
            });

        DOTween.To(value => loadingText.text = "Loading ... " + (int)value + "%", 1, 100,5).SetEase(Ease.Linear);
    }
}
