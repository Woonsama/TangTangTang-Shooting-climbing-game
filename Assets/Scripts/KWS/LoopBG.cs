using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopBG : MonoBehaviour
{
    public float offset;
    public GameObject player;

    void Start()
    {
        
    }

    void Update()
    {
        if(player.transform.position.y - transform.position.y >= offset)
        {
            transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
        }
    }
}
