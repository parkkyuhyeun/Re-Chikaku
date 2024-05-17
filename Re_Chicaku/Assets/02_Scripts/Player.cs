using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject hand;
    [SerializeField] GameObject hand2;

    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject firePos;

    private Rigidbody rigid;
    private Bullet bulletController;

    private Vector3 playerTrm;
    private Quaternion rArmAng;
    private Quaternion lArmAng;

    public float power;
    public float pGravity;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        RotateToMouseDir();

        Fire();

        playerTrm = transform.position;
        rArmAng = hand.transform.rotation;
        lArmAng = hand2.transform.rotation;

        rigid.AddForce(Vector3.down * pGravity);
    }

    void Fire()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10f);
        Vector3 dir = mouseWorldPosition - playerTrm;
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 getVal = new Vector3(playerTrm.x - mouseWorldPosition.x, playerTrm.y - mouseWorldPosition.y, playerTrm.z - mouseWorldPosition.z) * power;
            rigid.velocity = getVal;

            GameObject bullet = Instantiate(bulletPrefab, firePos.transform.position, Quaternion.identity);
            bulletController = bullet.GetComponent<Bullet>();
            bulletController.Launch(dir.normalized, 9000);
        }
    }

    void RotateToMouseDir()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10f);

        float angle = Mathf.Atan2(
            hand.transform.position.y - mouseWorldPosition.y,
            hand.transform.position.x - mouseWorldPosition.x) * Mathf.Rad2Deg;

        float final = -(angle + 90f);

        hand.transform.rotation = Quaternion.Euler(new Vector3(rArmAng.x, rArmAng.y, -final));

        float angle2 = Mathf.Atan2(
            hand2.transform.position.y - mouseWorldPosition.y,
            hand2.transform.position.x - mouseWorldPosition.x) * Mathf.Rad2Deg;

        float final2 = -(angle2 + 90f);

        hand2.transform.rotation = Quaternion.Euler(new Vector3(lArmAng.x, lArmAng.y, -final2));


        if (mouseWorldPosition.x > playerTrm.x)
        {
            transform.localScale = new Vector3(10, 10, -10);
            hand.transform.localScale = new Vector3(-1, 1, -1);
            hand2.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(10, 10, 10);
            hand.transform.localScale = new Vector3(1, 1, 1);
            hand2.transform.localScale = new Vector3(-1, 1, -1);
        }
    }
}
