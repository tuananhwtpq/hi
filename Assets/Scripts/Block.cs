using System;
using System.Collections;
using System.Collections.Generic;
using GameTool;
using UnityEngine;

public class Block : BasePooling
{
    private void OnEnable()
    {
        Disable(7.0f);
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
    }
}
