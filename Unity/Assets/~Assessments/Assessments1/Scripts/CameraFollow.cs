using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform player;    // Variable that stores a reference to our Player
    public Vector3 offset;      // Variable that allows us to offset the position (x, y, z)

    // Update is called once per frame
    void Update()
    {
        // Sets the Cameras position to the Players position
        transform.position = player.position + offset;
    }
}
