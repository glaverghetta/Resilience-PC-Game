using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObstacle : MonoBehaviour
{
    public float rotationSpeed = 180f;
    public float rotationDir = 1f;

    void Update()
    {
        transform.eulerAngles += new Vector3(0, rotationSpeed * rotationDir * Time.deltaTime, 0);
    }
}
