using System;
using System.Collections;
using System.Collections.Generic;
using GameTool;
using UnityEngine;
using UnityEngine.UI;

public class Lobby : MonoBehaviour
{
    public Animator bird;
    private int id;
    private List<RuntimeAnimatorController> listAnimators;
    [SerializeField] private Button leftBtn;
    [SerializeField] private Button rightBtn;
    [SerializeField] private Button playBtn;

    private void Start()
    {
        listAnimators = GameData.Instance.listAnimators;
        id = 0;
    }

    private void Awake()
    {
        
        playBtn.onClick.AddListener(() =>
        {
            GameData.Instance.ID = id;
            LoadSceneManager.Instance.LoadScene("Game");
        });
        
        
        leftBtn.onClick.AddListener(() =>
        {
            id--;
            if (id < 0)
            {
                id = listAnimators.Count - 1;
            }

            bird.runtimeAnimatorController = listAnimators[id];
        });
        
        rightBtn.onClick.AddListener(() =>
        {
            id++;
            if (id > listAnimators.Count - 1)
            {
                id = 0;
            }

            bird.runtimeAnimatorController = listAnimators[id];
        });
        
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
    }
}
