using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        health = 6;
    }

    // Update is called once per frame
    void Update()
    {
        if (health==0)
        {
            Destroy(gameObject);
        }


    }

    public void takeDamage()
    {
        health -= 1;
        GameObject.Find("AquariumWater").GetComponent<Animator>().SetInteger("Health", health);
        GameObject.Find("FishPlayer").GetComponent<Animator>().SetTrigger("Damaged");
    }
}
