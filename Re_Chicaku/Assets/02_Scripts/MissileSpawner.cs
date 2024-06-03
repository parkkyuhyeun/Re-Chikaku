using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileSpawner : MonoBehaviour
{
    public GameObject player;
    public GameObject missile; // �̻���
    public float spawnTime = 5f; // ����
    public float distance = 100f; //�÷��̾���� �Ÿ�

    private void Start()
    {
        StartCoroutine(SpawnObjectRoutine());
    }

    private IEnumerator SpawnObjectRoutine()
    {
        while (true)
        {
            int height = Random.Range(0, 25); // ����
            spawnTime = Random.Range(5, 8);

            yield return new WaitForSeconds(spawnTime);

            Vector3 spawnPosition = transform.position + transform.forward * distance;
            Instantiate(missile, new Vector3(0, height, 0), Quaternion.identity);
        }
    }
}
