using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        gun.SetActive(true);
        d_gun.SetActive(false);
        playerS.bulletPrefab = b;
        playerS.power = power;

        yield return new WaitForSeconds(6f);

        gun.SetActive(false);
        d_gun.SetActive(true);
        playerS.bulletPrefab = bullet;
        playerS.power = 1f;

        Destroy(gameObject);
    }
}
