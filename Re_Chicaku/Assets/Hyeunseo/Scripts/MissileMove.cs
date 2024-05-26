using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMove : MonoBehaviour
{
    public float speed = -5f;

    void Update()
    {
        transform.position = new Vector3(speed * Time.deltaTime, 0, 0);
    }
}
