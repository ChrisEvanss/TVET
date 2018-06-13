using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
[] - Brackets
{} - Braces
() - Parenthesis
Clean Code:     CTRL + K + D
Fold Code:      CTRL + M + O
UnFold Code:    CTRL + M + P
*/

public class Player : MonoBehaviour
{
    public float speed = 10f;
    public float jumpHeight = 15f;

    private Rigidbody rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // 'CALL' Move() and Jump()
        Move();
        Jump();
    }

    void Move()
    {
        // Check if the 'W' key is pressed
        if (Input.GetKey(KeyCode.W))
        {
            rigid.AddForce(Vector3.forward * speed);
        }

        // Check if the 'S' key is pressed
        if (Input.GetKey(KeyCode.S))
        {
            rigid.AddForce(Vector3.back * speed);
        }

        // Check if the 'A' key is pressed
        if (Input.GetKey(KeyCode.A))
        {
            rigid.AddForce(Vector3.left * speed);
        }

        // Check if the 'D' key is pressed
        if (Input.GetKey(KeyCode.D))
        {
            rigid.AddForce(Vector3.right * speed);
        }
    }
    void Jump()
    {
        // Checks if the "space" key was pressed ONCE
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigid.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }
    }
}