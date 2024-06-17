using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMove : MonoBehaviour
{
    Rigidbody rigid;

    UIMan ui;

    public float speed;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();

    }

    private void Update()
    {
        rigid.AddForce(Vector3.left * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Break"))
        {
            Destroy(gameObject);
        }
    }
}
