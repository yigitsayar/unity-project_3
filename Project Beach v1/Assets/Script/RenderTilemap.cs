using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RenderTilemap : MonoBehaviour
{
    private Tile sandTile;
    private Vector3 tilesPainted;
    private Tilemap tileMap;
    public Transform player = GameObject.Find("TargetForCam").GetComponent<Transform>();
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
