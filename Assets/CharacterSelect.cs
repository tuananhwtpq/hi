using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameTool;

public class CharacterSelect : MonoBehaviour
{
    private int index;
    [SerializeField] private GameObject[] characters;
    
    
    void Start()
    {
        index = 0;
        SelectCharacter();
    }

    public void OnPlayClick()
    {
        LoadSceneManager.Instance.LoadScene("Game");
    }
    
    public void OnLeftClick()
    {
        if (index > 0)
        {
            index--;
        }
        else
        {
            index = 3;
        }

        SelectCharacter();
    }

    public void OnRightClick()
    {
        if (index < characters.Length - 1)
        {
            index++;
        }
        else
        {
            index = 0;
        }

        SelectCharacter();
    }

    private void SelectCharacter()
    {
        for (int i = 0; i < characters.Length; i++)
        {
            if (i == index)
            {
                characters[i].GetComponent<SpriteRenderer>().color = Color.white;
                characters[i].GetComponent<Animator>().enabled = true;
            }
            else
            {
                characters[i].GetComponent<SpriteRenderer>().color = Color.black;
                characters[i].GetComponent<Animator>().enabled = false;
            }
        }
    }
}
