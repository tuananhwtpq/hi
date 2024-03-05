using System;
using System.Collections;
using System.Collections.Generic;
using GameTool;
using UnityEngine;

public class Block : BasePooling
{
    public BlockType blockType;
    [SerializeField] private float curHP;
    public eSoundName sound;
    private float maxHP;
    
    private SpriteRenderer sr;
    private void OnEnable()
    {
        Disable(7.0f);
        sr = GetComponent<SpriteRenderer>();
    }

    public void SetData()
    {
        ShotSFX();
        maxHP = GameData.Instance.blockData.listBlockSprites[(int)blockType].spriteInfo.maxHP;
        curHP = maxHP;
        sr.sprite = GameData.Instance.blockData.listBlockSprites[(int)blockType].spriteInfo.listSprite[2];
    }

    public void TakeDamage(float amount)
    {
        curHP -= amount;
        SetSprite();
        AudioManager.Instance.Shot(sound);
    }

    public void SetSprite()
    {
        if (curHP / maxHP <= 1f / 3)
        {
            sr.sprite = GameData.Instance.blockData.listBlockSprites[(int)blockType].spriteInfo.listSprite[0];
        }
        else if ( curHP / maxHP <= 2f / 3)
        {
            sr.sprite = GameData.Instance.blockData.listBlockSprites[(int)blockType].spriteInfo.listSprite[1];
        } if (curHP <= 0)
        {
            GameMenu.Instance.UpdateScore((int)blockType + 1);
            Disable();
        }
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
        //Của Đạt
        // if (other.gameObject.CompareTag("Bullet"))
        // {
        //     curHP -= 3;
        //     Debug.Log(curHP);
        // }
        //
        // float curHP_percent = (float)curHP/GameData.Instance.blockData.listBlockSprites[(int)blockType].spriteInfo.maxHP;
        // if (curHP_percent <= 2.0 / 3 && curHP_percent > 1.0 / 3)
        // {
        //     sr.sprite = GameData.Instance.blockData.listBlockSprites[(int)blockType].spriteInfo.listSprite[1];
        // }
        // if (curHP_percent <= 1.0 / 3)
        // {
        //     sr.sprite = GameData.Instance.blockData.listBlockSprites[(int)blockType].spriteInfo.listSprite[0];
        // }
        //
        // if (curHP <= 0)
        // {
        //     gameObject.SetActive(false);
        // }
        
    }
    public void ShotSFX()
    {
        if (blockType == BlockType.wood)
        {
            sound = eSoundName.Wood_Sound;
        }
        else if (blockType == BlockType.metal)
        {
            sound = eSoundName.Metal_Sound;
        }
        else if (blockType == BlockType.stone)
        {
            sound = eSoundName.Stone_Sound;
        }
    }
    
    
    
}
