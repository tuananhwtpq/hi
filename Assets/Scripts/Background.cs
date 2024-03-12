using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private float startPosX;
    [SerializeField] private float resetPosX;
    

    [SerializeField]private float speed;
    // Start is called before the first frame update
    private void Start()
    {
        transform.position = new Vector3(startPosX, transform.position.y, transform.position.z);

    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(new Vector3(-speed, 0f, 0f) * Time.deltaTime);
        if (Math.Abs(transform.position.x - resetPosX) <= 0.1f)
        {
            transform.position = new Vector3(startPosX, transform.position.y, transform.position.z);
        }
    }
}
