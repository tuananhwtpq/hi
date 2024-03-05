using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using GameTool;
using UnityEngine;

public class Bullet : BasePooling
{
    // Start is called before the first frame update
    public float speed = 5.0f;
   public Rigidbody2D rb;
   public SpriteRenderer sr;
   //Mới thêm vào ngày 27/2
   public float damage = 2.0f;

   private void Start()
   {
       
   }

   private void OnEnable()
   {
       rb.velocity = new Vector2(speed, 0);
       int score = GameData.Instance.score;
       int index = score / 10;
      
       if (index >= GameData.Instance.bulletData.BulletInfos.Count )
       {
           index = GameData.Instance.bulletData.BulletInfos.Count - 1;
       }
        sr.sprite = GameData.Instance.bulletData.BulletInfos[index].sprite;
        damage = GameData.Instance.bulletData.BulletInfos[index].damage;
   }

   private void Update()
   {
       
   }

   public void CheckIfChangeBulletSprite()
   {
       
       
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
       
       if (other.gameObject.CompareTag("Block"))
       {
           var block = other.gameObject.GetComponent<Block>();
               block.TakeDamage(damage);
           // gameObject.SetActive(false);
       }
   }
}
