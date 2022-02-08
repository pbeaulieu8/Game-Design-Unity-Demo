﻿using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0.0f,0.0f,2.0f);

    void LateUpdate()
    {
        transform.position = target.position - offset;    
    }
}
