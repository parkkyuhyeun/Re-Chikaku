using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject hand;
    [SerializeField] GameObject head;

    void Update()
    {
        RotateToMouseDir();
    }

    void RotateToMouseDir()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10f);

        float angle = Mathf.Atan2(
            hand.transform.position.y - mouseWorldPosition.y,
            hand.transform.position.x - mouseWorldPosition.x) * Mathf.Rad2Deg;

        float final = -(angle + 90f);
        Debug.Log(angle + " / " + final);

        hand.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, -final));


        if(mouseWorldPosition.x > 0f)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 90f, 0f));
        }
        else
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, -90f, 0f));
        }
    }
}
