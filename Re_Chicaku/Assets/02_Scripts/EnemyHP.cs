using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public int enemyHP;

    private int currentHP;

    private void Start()
    {
        currentHP = enemyHP;
    }

    private void Update()
    {
        if (currentHP <= 0) Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (transform.gameObject.layer == LayerMask.NameToLayer("Building"))
        {
            if (collision.gameObject.CompareTag("Rocket"))
            {
                Destroy(gameObject);
            }
        }
        else if(transform.gameObject.layer == LayerMask.NameToLayer("Flying"))
        {
            if(collision.gameObject.CompareTag("Bullet"))
            {
                currentHP--;
            }
            else if(collision.gameObject.CompareTag("Rocket"))
            {
                Destroy(gameObject);
            }
        }
    }
}
