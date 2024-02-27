using System;
using System.Collections;
using System.Collections.Generic;
using GameTool;
using UnityEngine;

public class Block : BasePooling
{
    public BlockType blockType;
    private float curHp;
    private SpriteRenderer sr;
    private void OnEnable()
    {
        Disable(7.0f);
        sr = GetComponent<SpriteRenderer>();
    }

    public void SetData()
    {
        curHp = GameData.Instance.blockData.listBlockSprites[(int)blockType].spriteInfo.maxHP;
        sr.sprite = GameData.Instance.blockData.listBlockSprites[(int)blockType].spriteInfo.listSprite[2];
    }

    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.gameObject.CompareTag("Bullet"))
    //     {
    //         Debug.Log("Hit Block");
    //         other.gameObject.SetActive(false);
    //     }
    // }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Bullet"))
        {
            curHp -= 1;
            
        }
        
    }

    private void Update()
    {
        // curHp -= MaxH
    }
    
    
}
