using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CoinCounter : MonoBehaviour
{
    //public GameObject fddsd;
    public Text coinNumber;
    public int coinCount = 0;
    //public Text coinText;
    // Start is called before the first frame update
   // void Start()
   // {
        
   // }

    // Update is called once per frame
    void Update()
    {
        coinNumber.text = coinCount.ToString();
    }
}
