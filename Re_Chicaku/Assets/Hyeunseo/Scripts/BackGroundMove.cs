using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMove : MonoBehaviour
{
    public List<GameObject> backgroundList = new List<GameObject>();
    public GameObject player;

    void Update()
    {
        if(player.transform.position.x % 47 == 0)
        {
            int i = 0;
            backgroundList[i].transform.position += new Vector3(141,0,0);

            if (i == 3)
            {
                i = 0;
            }
        }
    }
}
