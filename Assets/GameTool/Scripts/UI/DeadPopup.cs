using System;
using System.Collections;
using System.Collections.Generic;
using GameTool;
using UnityEngine;
using UnityEngine.UI;

public class DeadPopup : SingletonUI<DeadPopup>
{
    public Button playAgainBtn;
    public Button chooseBirdBtn;

    private void OnEnable()
    {
        playAgainBtn.onClick.AddListener(() =>
        {
            Time.timeScale = 1;
            LoadSceneManager.Instance.LoadScene("Game");
        });
        
        chooseBirdBtn.onClick.AddListener(() =>
        {
            Time.timeScale = 1;
            LoadSceneManager.Instance.LoadScene("Choose Bird");
        });
    }
}