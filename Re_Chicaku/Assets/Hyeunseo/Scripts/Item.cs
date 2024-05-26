using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject itemPrefab; //소환할 아이템
    public GameObject exItemPrefab; //이전에 소환한 아이템
    private float spawnInterval; // 장애물 사이의 간격

    void Start()
    {
        spawnInterval = Random.Range(30, 45);
        StartCoroutine(ProduceEnemy());
    }

    IEnumerator ProduceEnemy()
    {
        while (true)
        {
            int height = Random.Range(0, 25); // 높이
            spawnInterval = Random.Range(30, 45);

            GameObject newMapPrefab = Instantiate(itemPrefab, new Vector3(0, height, 0), Quaternion.identity);
            newMapPrefab.transform.localScale = new Vector3(5, 5, 5);

            if (exItemPrefab != null)
            {
                newMapPrefab.transform.position = new Vector3(exItemPrefab.transform.position.x + spawnInterval, height, 0);
            }

            exItemPrefab = newMapPrefab;

            yield return new WaitForSeconds(0.3f);
        }
    }
}
