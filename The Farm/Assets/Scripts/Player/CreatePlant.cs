using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlant : MonoBehaviour
{
    public GameObject plant;
    public GameObject parent;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            GameObject plants = Instantiate(plant, transform.position, Quaternion.identity);
            plants.transform.SetParent(parent.transform);
        }
    }
}
