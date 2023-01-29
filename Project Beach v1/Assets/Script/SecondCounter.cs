using System.Collections;
using UnityEngine;

public class SecondCounter : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(logEverySecond());
    }

    IEnumerator logEverySecond()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
        }
    }
}
