using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // This is a reference to the Rigidbody component called "rigid"
    public Rigidbody rigid;

    public float forwardForce = 2000f;  // Variable to change forward force
    public float sidewaysForce = 500f;  // Variable to change sideways force
    public float jumpHeight = 15f; // Variable to change jump height

    // We are using "FixedUpdate" because it performs better with the PhysicsEngine
    void FixedUpdate()
    {
        // Add a forward force
        rigid.AddForce(0, 0, forwardForce * Time.deltaTime);

        // Checks if the player is pressing "d"
        if (Input.GetKey("d"))
        {
            rigid.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        // Checks if the player is pressing "a"
        if (Input.GetKey("a"))
        {
            rigid.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        // Checks if the "space" key was pressed ONCE
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigid.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }
    }
}