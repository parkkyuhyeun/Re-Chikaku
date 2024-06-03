using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject mapPrefab; //��ȯ�� ������Ʈ
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
            int height = Random.Range(-30, -40); // ����
            int thickness = Random.Range(12, 18); // �β�
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
