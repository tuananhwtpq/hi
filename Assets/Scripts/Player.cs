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
    public float timeShoot = 50.0f;
    public float boundTop = 4.1f;
    public float boundBottom = -4.5f;
    public eSoundName sound;
    public BlockType blockType;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(0, 20));
        AudioManager.Instance.PlayMusic(eMusicName.Game);
        cooldown = timeShoot;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AudioManager.Instance.Shot(eSoundName.Jump);
            rb.velocity = new Vector2(0, jumpForce);

            
        }
        cooldown -= Time.deltaTime;
        if (cooldown <= 0.0f)
        {
            PoolingManager.Instance.GetObject(NamePrefabPool.Bullet, parent: null, transform.position).Disable(1);
            cooldown = timeShoot;
        }
        
        var pos = transform.position;
        if (pos.y >= boundTop)
        {
            transform.position = new Vector2(pos.x, boundTop);
        }
        else if (pos.y <= boundBottom)
        {
            transform.position = new Vector2(pos.x, boundBottom);
        }

        //Của Đạt
        // if (gameObject.transform.position.y < -5)
        // {
        //     Debug.Log("Death");
        //     UnityEditor.EditorApplication.isPaused = true;
        // }
        
        
        
        
        
        
        
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Block"))
        {
            rb.velocity = new Vector2(0, -30f);
        }
    }

    
}
