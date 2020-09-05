using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject cameras;
    private Vector3 offset;
    private float max;

    void Start()
    {
        offset = cameras.transform.position;
    }
    
    void LateUpdate()
    {
        max = cameras.transform.position.x;
        offset.x = transform.position.x;
        if(offset.x < max)
        {
            offset.x = max;
        }
        transform.position = new Vector3(offset.x, transform.position.y, transform.position.z);
        cameras.transform.position = offset;
    }
}
