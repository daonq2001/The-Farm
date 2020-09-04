using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlant : MonoBehaviour
{
    public GameObject plant, plant1;
    public GameObject parent, parent1;

    private void OnTrigerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (collision.CompareTag("Plant"))
            {
                GameObject plants1 = Instantiate(plant1, collision.transform.position, Quaternion.identity);
                plant1.transform.SetParent(parent1.transform);
            }
            if (collision.CompareTag("Nenco"))
            {
                GameObject plants = Instantiate(plant, collision.transform.position, Quaternion.identity);
                plants.transform.SetParent(parent.transform);
            }
        }
    }
}
