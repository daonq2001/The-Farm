using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject cameras;
    private Vector3 offset;
    private float max;
    private Vector3 leftCamera;
    
    void Start()
    {
        offset = cameras.transform.position;
    }
    
    void LateUpdate()
    {
        leftCamera = Camera.main.ScreenToWorldPoint(Vector3.zero);
        max = cameras.transform.position.x;
        offset.x = transform.position.x;
        if(offset.x < max)
        {
            offset.x = max;
        }
        if(transform.position.x < (leftCamera.x + 0.3f))
        {
            transform.position = new Vector3(leftCamera.x + 0.3f, transform.position.y, transform.position.z);
        }
        cameras.transform.position = offset;
    }
}
