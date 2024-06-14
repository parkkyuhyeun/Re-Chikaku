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

            int height = Random.Range(10, 25);

            GameObject missiles = Instantiate(missile, new Vector3(spawnPos.transform.position.x, height, spawnPos.transform.position.z), Quaternion.identity);
            Destroy(missiles, 2.5f);
        }
    }
}
