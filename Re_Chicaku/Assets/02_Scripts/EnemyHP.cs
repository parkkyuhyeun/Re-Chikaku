using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public ParticleSystem explosion;

    public int enemyHP;

    private int currentHP;

    [SerializeField] public SoundManager soundManager;

    private void Start()
    {
        currentHP = enemyHP;
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    private void Update()
    {
        if (currentHP <= 0)
        {
            StartCoroutine(Break());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (transform.gameObject.layer == LayerMask.NameToLayer("Building"))
        {
            if (collision.gameObject.CompareTag("Rocket"))
            {
                StartCoroutine(Break());
            }
        }
        else if(transform.gameObject.layer == LayerMask.NameToLayer("Flying"))
        {
            soundManager.EnemyHit();
            if (collision.gameObject.CompareTag("Bullet"))
            {
                currentHP--;
            }
            else if(collision.gameObject.CompareTag("Rocket"))
            {
                StartCoroutine(Break());
            }
        }
    }

    IEnumerator Break()
    {
        ParticleSystem eff = Instantiate(explosion, transform.position, Quaternion.identity);
        eff.Stop();
        Destroy(gameObject);
        yield return new WaitForSeconds(1f);


    }
}
