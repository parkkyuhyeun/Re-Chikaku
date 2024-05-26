using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject mapPrefab; //소환할 오브젝트
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
            int height = Random.Range(-30, -40); // 높이
            int thickness = Random.Range(12, 18); // 두께
            spawnInterval = Random.Range(25, 32);

            GameObject newMapPrefab = Instantiate(mapPrefab, new Vector3(0, height, 0), Quaternion.identity);
            newMapPrefab.transform.localScale = new Vector3(thickness, 50, 10);

            if (exMapPrefab != null)
            {
                newMapPrefab.transform.position = new Vector3(exMapPrefab.transform.position.x + spawnInterval, height, 0);
            }

            exMapPrefab = newMapPrefab;

            yield return new WaitForSeconds(0.3f);
        }
    }
}
