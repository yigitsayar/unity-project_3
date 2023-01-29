using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlanktonBallAI : MonoBehaviour
{
    public Transform player;
    public Transform targetLeft;
    public Transform targetRight;
    public Collider2D damageCollider;
    
    private Animator playerAnimator;
    
    private Transform Position;

    private float maxDistanceX = 10;
    private float maxDistanceYtoMove = 6;
    private float speedHorizontal = 2;
    private float speedVertical = 2;
    private float speedAttack = 10;

    public Boolean takepositionAffirmative;
    public Boolean rollRightYes;
    public Boolean rollLeftYes;

    //private IEnumerator fermesKes;
    private void Start()
    {
        takepositionAffirmative = true;
        playerAnimator = GetComponent<Animator>();
        damageCollider = GetComponent<Collider2D>();
        damageCollider.enabled = false;
    }
    void Update()
    {
        if(takepositionAffirmative)
        {
           takePosition();
        }
        
        if (transform.position == targetRight.position)
        {
            
            StartCoroutine(toLeft());
            playerAnimator.SetBool("Attack", true);
        }
        
        if (transform.position == targetLeft.position)
        {
            StartCoroutine(toRight());
            playerAnimator.SetBool("Attack", true);
        }

        if (rollRightYes)
        {
            transform.position -= Vector3.right * speedAttack * Time.deltaTime;
        }
        if (rollLeftYes)
        {
            transform.position += Vector3.right * speedAttack * Time.deltaTime;
        }

    }

    private void JustCheckingBro()
    {
        //print(transform.position.x - player.position.x);
    }
    private void takePosition()
    {
        if (Mathf.Sign(transform.position.x - player.position.x) >= 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetLeft.position, speedVertical * Time.deltaTime);
        } else if (Mathf.Sign(transform.position.x - player.position.x) <= 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetRight.position, speedVertical * Time.deltaTime);
        }        
    }

    private IEnumerator toLeft()
    {
        playerAnimator.SetBool("Attack", true);
        takepositionAffirmative = false;
        yield return new WaitForSeconds(1.5f);
        damageCollider.enabled = true;
        rollLeftYes = true;

        yield return new WaitForSeconds(2.3f);
        rollLeftYes = false;
        playerAnimator.SetBool("Attack", false);
        yield return new WaitForSeconds(1.5f);
        damageCollider.enabled = false;
        takepositionAffirmative = true;
        
    }
    private IEnumerator toRight()
    {
        playerAnimator.SetBool("Attack", true);
        takepositionAffirmative = false;
        yield return new WaitForSeconds(1.5f);
        damageCollider.enabled = true;
        rollRightYes = true;

        yield return new WaitForSeconds(2.3f);
        rollRightYes = false;
        playerAnimator.SetBool("Attack", false);
        yield return new WaitForSeconds(1.5f);
        damageCollider.enabled = false;
        takepositionAffirmative = true;
        

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject.Find("FishPlayer").GetComponent<PlayerHealth>().takeDamage();
        }
    }
    }
