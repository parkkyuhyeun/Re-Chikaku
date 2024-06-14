using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    public GameObject[] mapPrefab; //소환할 오브젝트
    public GameObject exMapPrefab; //이전에 소환한 오브젝트
    private float spawnInterval; // 장애물 사이의 간격

    void Start()
    {
        spawnInterval = Random.Range(25, 32);
        StartCoroutine(ProduceEnemy());
    }

    IEnumerator ProduceEnemy()
    {
        while (true)
        {
            int ran = Random.Range(0, 3);
            int height = Random.Range(-60, -40); // 높이
            int thickness = Random.Range(1, 2); // 두께
            spawnInterval = Random.Range(25, 32);

            GameObject newMapPrefab = Instantiate(mapPrefab[ran], new Vector3(0, height, 0), Quaternion.Euler(0,180,0));
            newMapPrefab.transform.localScale = new Vector3(thickness, 1.5f, 1);

            if (exMapPrefab != null)
            {
                newMapPrefab.transform.position = new Vector3(exMapPrefab.transform.position.x + spawnInterval, height, 0);
            }

            exMapPrefab = newMapPrefab;

            yield return new WaitForSeconds(0.3f);
        }
    }
}
