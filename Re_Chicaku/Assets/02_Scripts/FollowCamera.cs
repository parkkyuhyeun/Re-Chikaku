using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject player;

    private void Update()
    {
        Camera.main.transform.position = new Vector3(player.transform.position.x + 5f, player.transform.position.y, player.transform.position.z -9f);
    }
}
