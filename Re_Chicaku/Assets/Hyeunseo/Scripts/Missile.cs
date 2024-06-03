using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public GameObject player;
    public GameObject missile; // �̻���
    public float spawnTime = 5f; // ����
    public float distance = 100f; //�÷��̾���� �Ÿ�

    private Vector3 playerPosition;

    private void Start()
    {
        StartCoroutine(SpawnObjectRoutine());
    }

    private void Update()
    {
        playerPosition = player.transform.position;
    }

    private IEnumerator SpawnObjectRoutine()
    {
        while (true)
        {
            int height = Random.Range(0, 25); // ����
            spawnTime = Random.Range(5, 8);

            yield return new WaitForSeconds(spawnTime);

            Vector3 spawnPosition = playerPosition + player.transform.forward * distance;
            Instantiate(missile, new Vector3(player.transform.position.x, height, player.transform.position.z), Quaternion.identity);
        }
    }
}
