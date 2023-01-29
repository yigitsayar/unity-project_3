using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PufferFishAI : MonoBehaviour
{
    public float MinX;
    private float MinY = -5.75f;
    public float MaxX;
    private float MaxY = 5.75f;
    public float speed;
    private float MaxTime = 3f;
    private float cutTime;
    private float x, y;

    public Transform transformMax;
    public Transform transformMin;
    private void Start()
    {
        TurnAround();
        //
        //
    }

    void Update()
    {
        Move();

        MinX = transformMin.position.x;
        MaxX = transformMax.position.x;
    }



    private void TurnAround()
    {
        x = Random.Range(-1f, 1f);
        y = Random.Range(-1f, 1f);
        Debug.Log("Min:" + MinY.ToString());
    }

    void Move()
    {
        cutTime += Time.deltaTime;
        if (transform.position.x < MinX || transform.position.x > MaxX)
        {
            x = -x;
            cutTime = 0f;
        }

        if (transform.position.y < MinY || transform.position.y > MaxY)
        {
            y = -y;
            cutTime = 0f;
        }
        if (cutTime > MaxTime)
        {
            TurnAround();
            cutTime = 0;
        }

        transform.Translate(Vector3.right * speed * x * Time.deltaTime + Vector3.up * y * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject.Find("FishPlayer").GetComponent<PlayerHealth>().takeDamage();
        }
    }
}
