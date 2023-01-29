using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D mybody;
    private float verticalSpeed = 3;
    private float horizontalSpeed = 5;

    private void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }
    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(Vector3.right * horizontalSpeed * Time.deltaTime * Input.GetAxisRaw("Horizontal"));
        transform.Translate(Vector3.up * verticalSpeed * Time.deltaTime * Input.GetAxisRaw("Vertical"));
    }
}
