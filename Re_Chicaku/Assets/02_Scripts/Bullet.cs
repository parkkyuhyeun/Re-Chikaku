using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(transform.position.magnitude > 1000f)
        {
            Destroy(gameObject);
        }
    }

    public void Launch(Vector3 dir, float speed)
    {
        rigid.AddForce(dir * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
