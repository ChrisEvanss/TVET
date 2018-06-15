using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;

    // Function disables movement if the player hits an object.
    void OnCollisionEnter(Collision collisionInfo)
    {
        // Checks if the object we collided with has a tag called "Obstacle".
        if (collisionInfo.collider.tag == "Obstacle")
        {
            movement.enabled = false;   // Disable the players movement.
        }
    }
}