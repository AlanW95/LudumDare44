using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate()
    {
        // we store current cameras position in variable temp - temporary position
        Vector3 temp = transform.position;

        // we set the cameras position x to be equal to the player's position x
        temp.x = playerTransform.position.x;

        // we set back the cameras temp position to the cameras current position
        transform.position = temp;
    }
}
