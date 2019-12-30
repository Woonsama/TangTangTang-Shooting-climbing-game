using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public GameObject player;
    Rigidbody2D rigid;
    public float jumpPower;

    AudioSource source;
    public AudioClip jump;

    private void Start()
    {
        rigid = player.GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
        source.clip = jump;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            PlayerJump();
        }
    }

    public void PlayerJump()
    {
        //점프 효과음 재생
        source.Play();

        PlayerCtrl.isStick = false;
        PlayerCtrl.ani.Play("JUMP", -1, 0f);
        rigid.velocity = Vector2.zero;
        rigid.AddForce(new Vector2(0, jumpPower),ForceMode2D.Impulse);
    }
}
