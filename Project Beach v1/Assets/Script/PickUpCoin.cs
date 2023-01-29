using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCoin : MonoBehaviour
{
    //public GameObject canvas;

    public Animator coinAnimator;
    void Start()
    {
        coinAnimator = GetComponent<Animator>();
    }
    IEnumerator OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            coinAnimator.Play("CoinDisappearing");
            yield return new WaitForSeconds(1.5f);
            GameObject.Find("Canvas").GetComponent<CoinCounter>().coinCount += 1;
            Destroy(gameObject);
        }
    }
}
