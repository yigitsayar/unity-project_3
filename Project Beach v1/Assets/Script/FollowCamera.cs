using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    public Transform followCamera;

    void Update()
    {
        transform.position = new Vector3(followCamera.position.x, 0, -10);
    }
}
