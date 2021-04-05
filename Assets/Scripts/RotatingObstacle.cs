using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script causes an obstacle to constantly rotate around its center. */

public class RotatingObstacle : MonoBehaviour
{
    public float rotationSpeed = 180f;
    public float rotationDir = 1f;

    void FixedUpdate()
    {
        if(!PauseGame.isGamePaused)
            transform.eulerAngles += new Vector3(0, rotationSpeed * rotationDir * Time.deltaTime, 0);
    }
}
