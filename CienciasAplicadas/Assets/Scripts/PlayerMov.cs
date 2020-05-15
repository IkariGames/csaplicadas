using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    Rigidbody2D rigidbody;
    public float speed;
    public float jumpForce;


    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        float movementX = Input.GetAxis("Horizontal");
        float movementY = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(movementX * speed, movementY * jumpForce);
        rigidbody.AddForce(movement);
    }
}
