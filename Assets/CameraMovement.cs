using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // what the camera is going to follow
    public GameObject target;

    void Update()
    {
        // follows the player on the x axis
        transform.position = new Vector3(target.transform.position.x, transform.position.y, transform.position.z);
    }
}
