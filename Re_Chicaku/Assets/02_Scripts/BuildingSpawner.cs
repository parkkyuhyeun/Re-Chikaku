using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    public GameObject[] mapPrefab; //��ȯ�� ������Ʈ
    public GameObject exMapPrefab; //������ ��ȯ�� ������Ʈ
    private float spawnInterval; // ��ֹ� ������ ����

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
            int height = Random.Range(-60, -40); // ����
            int thickness = Random.Range(1, 2); // �β�
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
