using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public GameObject bullet;
    public GameObject player;
    public float playerOffset_x, playerOffset_y;

    AudioSource source;
    public AudioClip shot;

    public float Delay;
    private float currentTime;

    private bool isShotReady;

    void Start()
    {
        currentTime = 0;
        source= GetComponent<AudioSource>();
        source.clip = shot;
    }

    void Update()
    {
        DelayCheck();

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Fire();
        }

    }

    public void Fire()
    {
        if (PlayerCtrl.isShotReady)
        {
            if (isShotReady)
            {
                //총발사 효과음 재생
                source.Play();

                Instantiate(bullet, player.transform.position + new Vector3(playerOffset_x * PlayerCtrl.playerLookDirection, playerOffset_y), Quaternion.identity);
                currentTime = 0;
                isShotReady = false;
            }
        }
    }

    public void DelayCheck()
    {
        if(currentTime >= Delay)
        {
            isShotReady = true;
        }
        else
        {
            currentTime += Time.deltaTime;
        }
    }
}
