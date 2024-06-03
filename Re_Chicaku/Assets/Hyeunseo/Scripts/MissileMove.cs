using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMove : MonoBehaviour
{
    Rigidbody rigid;

    public float speed;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();

    }

    private void Update()
    {
        rigid.AddForce(Vector3.left * speed);
        
    }
}
