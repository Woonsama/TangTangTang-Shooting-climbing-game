using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallItem : MonoBehaviour
{
    public GameObject player;
    public float y_offset;

    public GameObject[] item;
    int randomItem;
    int randomPos;


    [SerializeField] float throwDelay;

    private float currentTime;

    void Start()
    {
        currentTime = 0;     
    }

    
    void Update()
    {
        if(currentTime >= throwDelay)
        {
            Fall();
            currentTime = 0;
            throwDelay = Random.Range(0.2f, 0.6f);
        }
        else
        {
            currentTime += Time.deltaTime;
        }
    }

    public void Fall()
    {
        Instantiate(item[Random.Range(0, item.Length)], player.transform.position + new Vector3(Random.Range(-5,5), y_offset, 0), Quaternion.identity);
    }
}
