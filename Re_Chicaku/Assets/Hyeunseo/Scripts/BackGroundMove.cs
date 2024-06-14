using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMove : MonoBehaviour
{
    public GameObject player;
    public GameObject building;

    private void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("¥Í¿Ω");
            //transform.position += new Vector3(235, 0, 0);
            GameObject nb = Instantiate(building, new Vector3(transform.position.x + 235, transform.position.y, transform.position.z), Quaternion.identity);
        }
    }
}
