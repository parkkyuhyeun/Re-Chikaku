using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingInstance : MonoBehaviour
{
    public float speed = -5f;

    void Update()
    {
        transform.position = new Vector3(speed * Time.deltaTime, 0, 0);
    }
}
