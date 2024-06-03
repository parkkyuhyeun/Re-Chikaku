using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileSpawner : MonoBehaviour
{
    public GameObject spawnPos;
    public GameObject missile; // �̻���
    private float spawnTime = 5f; // ����

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
