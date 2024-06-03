using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Item : MonoBehaviour
{
    [SerializeField] GameObject r_gun;
    [SerializeField] GameObject a_gun;
    [SerializeField] GameObject d_gun;

    [SerializeField] GameObject player;

    [SerializeField] GameObject rocket;
    [SerializeField] GameObject bullet;

    Player playerS;

    private void Awake()
    {
        playerS = player.GetComponent<Player>();
        r_gun = GameObject.Find("MG - ORANGE");
        a_gun = GameObject.Find("SMG 2 - ORANGE");
        d_gun = GameObject.Find("SMG 2 - ORANGE");
    }
    private void Start()
    {
        r_gun.transform.position = new Vector3(-0.1f, 5f, -0.1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(transform.gameObject.layer == LayerMask.NameToLayer("R_Item"))
            {
                StartCoroutine(ChangeGun(r_gun, rocket, 1.5f));
            }

            else if(transform.gameObject.layer == LayerMask.NameToLayer("A_Item"))
            {
                StartCoroutine(ChangeGun(a_gun, bullet, 1f));
            }

            transform.localScale = Vector3.zero;
        }
    }

    IEnumerator ChangeGun(GameObject gun, GameObject b, float power)
    {
        playerS.bulletPrefab = b;
        playerS.power = power;

        yield return new WaitForSeconds(6f);

        playerS.bulletPrefab = bullet;
        playerS.power = 1f;

        Destroy(gameObject);
    }
}
