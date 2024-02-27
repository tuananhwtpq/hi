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
   public float damage = 1.0f;

   private void Start()
   {
       
   }

   private void OnEnable()
   {
       rb.velocity = new Vector2(speed, 0);
   }

   private void Update()
   {
       
   }
}
