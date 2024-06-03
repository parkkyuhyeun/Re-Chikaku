using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileSpawner : MonoBehaviour
{
    public GameObject player;
    public GameObject missile; // 미사일
    public float spawnTime = 5f; // 간격
    public float distance = 100f; //플레이어와의 거리

    private void Start()
    {
        StartCoroutine(SpawnObjectRoutine());
    }

    private IEnumerator SpawnObjectRoutine()
    {
        while (true)
        {
            int height = Random.Range(0, 25); // 높이
            spawnTime = Random.Range(5, 8);

            yield return new WaitForSeconds(spawnTime);

            Vector3 spawnPosition = transform.position + transform.forward * distance;
            Instantiate(missile, new Vector3(0, height, 0), Quaternion.identity);
        }
    }
}
