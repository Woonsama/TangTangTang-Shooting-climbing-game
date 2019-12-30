using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerCtrl : MonoBehaviour
{
    public float y_offset;
    public GameObject player;
    public float smooth;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x, player.transform.position.y + y_offset, transform.position.z), smooth);
    }
}
