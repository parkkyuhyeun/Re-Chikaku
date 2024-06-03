using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject itemPrefab; //��ȯ�� ������
    public GameObject exItemPrefab; //������ ��ȯ�� ������
    private float spawnInterval; // ��ֹ� ������ ����

    void Start()
    {
        spawnInterval = Random.Range(30, 45);
        StartCoroutine(ProduceEnemy());
    }

    IEnumerator ProduceEnemy()
    {
        while (true)
        {
            int height = Random.Range(0, 25); // ����
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
