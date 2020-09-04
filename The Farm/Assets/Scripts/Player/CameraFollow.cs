using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject cameras;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = cameras.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        offset.x = transform.position.x;
        offset.y = transform.position.y;
        cameras.transform.position = offset;
    }
}
