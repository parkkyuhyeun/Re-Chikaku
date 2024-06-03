using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileSpawner : MonoBehaviour
{
    public GameObject spawnPos;
    public GameObject missile; // 미사일
    private float spawnTime = 5f; // 간격

    private void Start()
    {
        StartCoroutine(SpawnObjectRoutine());
    }

    private IEnumerator SpawnObjectRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);

            GameObject missiles = Instantiate(missile, spawnPos.transform.position, Quaternion.identity);
        }
    }
}
