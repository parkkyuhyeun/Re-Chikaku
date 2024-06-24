using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject player;

    private void Update()
    {
        Camera.main.transform.position = new Vector3(player.transform.position.x + 15f, 0f, player.transform.position.z -9f);
    }
}
