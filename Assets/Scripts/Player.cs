using System;
using System.Collections;
using System.Collections.Generic;
using GameTool;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float jumpForce = 7.5f;
    private Rigidbody2D rb;
    public GameObject prefab;
    public float cooldown;
    public float timeShoot = 1.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(0, 20));
        cooldown = timeShoot;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = new Vector2(0, jumpForce);
        }
        cooldown -= Time.deltaTime;
        if (cooldown <= 0.0f)
        {
            PoolingManager.Instance.GetObject(NamePrefabPool.Bullet, parent: null, transform.position).Disable(1);
            cooldown = timeShoot;
        }
        
        
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Block"))
        {
            Debug.Log("Collided with square");
            Instantiate(prefab, new Vector3(0f, 0f, 0f), Quaternion.identity);
            Destroy(other.gameObject);
        }
    }
}
