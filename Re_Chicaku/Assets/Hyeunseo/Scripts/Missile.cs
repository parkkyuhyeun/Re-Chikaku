using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public GameObject player;
    public GameObject missile; // 미사일
    public float spawnTime = 5f; // 간격
    public float distance = 100f; //플레이어와의 거리

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
            int height = Random.Range(0, 25); // 높이
            spawnTime = Random.Range(5, 8);

            yield return new WaitForSeconds(spawnTime);

            Vector3 spawnPosition = playerPosition + player.transform.forward * distance;
            Instantiate(missile, new Vector3(player.transform.position.x, height, player.transform.position.z), Quaternion.identity);
        }
    }
}
