using System;
using System.Collections;
using System.Collections.Generic;
using GameTool;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class Wall : BasePooling
{
    // Start is called before the first frame update
    public float size = 5.0f;
    public float speed = 5f;

    private float[] posY = new float[4];
    private float[] height = new float[4];

    private void OnEnable()
    {
        size = Camera.main.orthographicSize;
        CreateBlocks();

    }
    
    private void CreateBlocks()
    {
        height[0] = Random.Range(1, 4);
        height[1] = size - height[0];
        height[2] = Random.Range(1, 4);
        height[3] = size - height[2];

        posY[0] = size - height[0] / 2;
        posY[1] = height[1] / 2;
        posY[2] = -height[2] / 2;
        posY[3] = -size + height[3] / 2;

        for (int i = 0; i < 4; i++)
        {
            // BlockType blockType;
            // if (GameData.Instance.score <= 6)
            // {
            //     blockType = (BlockType.wood);
            // } else if (GameData.Instance.score <= 15)
            // {
            //     blockType = BlockType.stone;
            // } else if (GameData.Instance.score >= 30)
            // {
            //     blockType = (BlockType)Random.Range(0, 3);
            // }
            var blockType = (BlockType)Random.Range(0, 3);
            var position = transform.position;
            var block = (Block)PoolingManager.Instance.GetObject(NamePrefabPool.Block, 
                position: new Vector3(position.x, posY[i], position.z), parent:transform);
            //Lỗi sắp xếp sai dòng, phải gán block.blockType = blockType trước sau đó ms truy cập block.SetData();
            block.blockType = blockType;
            block.SetData();
           SpriteRenderer sr = block.gameObject.GetComponent<SpriteRenderer>();
            sr.size = new Vector2(1, height[i]);
            BoxCollider2D bc = block.gameObject.GetComponent<BoxCollider2D>();

            bc.size = sr.size;
            bc.offset = Vector2.zero;
        }
    }

    private void Update()
    {
        transform.Translate(new Vector3(-speed *Time.deltaTime, transform.position.y, transform.position.z));
        //transform.position = new Vector3(-speed * Time.deltaTime, transform.position.y, transform.position.z);
        
        
        
    }
}
