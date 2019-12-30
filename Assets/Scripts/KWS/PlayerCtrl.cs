using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public GameObject gun;

    Rigidbody2D rigid;

    public float sideSpeed;
    public float upSpeed;

    public static bool isStick; // 달라붙었는지 여부
    public static Animator ani;

    public static bool isDie;

    public static bool isShotReady;

    public bool isTreeCol;

    public bool isShield;

    public enum PLAYER_STATE
    {
        STOP,
        SIDE,
        UPDOWN,
        JUMP,
        DIE,
    }

    public static PLAYER_STATE playerState;

    public static int playerLookDirection;

    void Start()
    {
        playerLookDirection = -1;

        isTreeCol = true;
        rigid = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();

        playerState = PLAYER_STATE.STOP;
        isDie = false;
        isStick = true;

    }

    void Update()
    {
        LookDirectionCheck();

        //FlipCacing
        FacingCheck();

        //Move
        MoveMent();

        //StickCheck
        GravityCheck();


        //Animation
        StartCoroutine(State());
    }

    public void GravityCheck()
    {

        if (isStick)
        {
            gun.SetActive(false);
            isShotReady = false;
            rigid.velocity = Vector2.zero;
            rigid.gravityScale = 0;
            
}
        else
        {
            gun.SetActive(true);
            isShotReady = true;
            SetPlayerState(PLAYER_STATE.JUMP);             
            rigid.gravityScale = 3;
        }
    }
    public void MoveMent()
    {
        if(JoyStick.DragCheck() && !isStick && isTreeCol)
        {
            if (JoyStick.GetMoveVecY() == 1 || JoyStick.GetMoveVecY() == -1)
            {
                isStick = true;
            }

        }

        if (JoyStick.DragCheck() && isStick && isTreeCol)
        {
            if(JoyStick.GetJoyVec().y >= 0.5f || JoyStick.GetJoyVec().y <= 0.5f)
            {
                SetPlayerState(PLAYER_STATE.UPDOWN);
            }
            else
            {
                SetPlayerState(PLAYER_STATE.SIDE);
            }

            transform.position += new Vector3(0,JoyStick.GetJoyVec().y * upSpeed, 0) * Time.deltaTime;
        }
        else
        {
            SetPlayerState(PLAYER_STATE.STOP);
        }

        transform.position += new Vector3(JoyStick.GetJoyVec().x * sideSpeed,0, 0) * Time.deltaTime;
    }
    
    public IEnumerator State()
    {
        switch (playerState)
        {
            case PLAYER_STATE.STOP:
                ani.SetBool("JUMP", false);
                ani.SetBool("SADARI", false);
                ani.SetBool("IDLE", true);
                break;         
            case PLAYER_STATE.SIDE:
                if (isStick)
                {
                    ani.SetBool("JUMP", false);
                    ani.SetBool("IDLE", false);
                    ani.SetBool("SADARI", true);
                }
                else
                {
                    ani.SetBool("BASIC", true);
                }
                break;
            case PLAYER_STATE.UPDOWN:
                if (isStick)
                {
                    ani.SetBool("JUMP", false);
                    ani.SetBool("IDLE", false);
                    ani.SetBool("SADARI", true);
                }
                break;          
            case PLAYER_STATE.JUMP:
                ani.SetBool("SADARI", false);
                ani.SetBool("IDLE", false);
                ani.SetBool("JUMP", true);
                break;
            case PLAYER_STATE.DIE:
                ani.SetBool("SADARI", false);
                ani.SetBool("IDLE", false);
                ani.SetBool("JUMP", false);
                ani.SetBool("DIE", true);
                break;
        }
        yield return null;
    }

    public static void SetPlayerState(PLAYER_STATE value)
    {
        playerState = value;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Item")
        {
            if (!isShield)
            {
                isDie = true;
                isStick = false;
                SetPlayerState(PLAYER_STATE.DIE);
                ani.Play("DIE", -1, 0f);
            }

        }
        if(collision.tag == "tree")
        {
            isTreeCol = true;
        }
        if(collision.tag == "Ground")
        {
            if(!isShield)
            {
                isDie = true;
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "tree")
        {
            isStick = false;
            isTreeCol = false;
        }
    }

    public void LFacing()
    {
        transform.localScale = new Vector3(1, 1, 1);
    }

    public void RFacing()
    {
        transform.localScale = new Vector3(-1, 1, 1);
    }

    public void FacingCheck()
    {
        if(playerLookDirection == -1)
        {
            LFacing();
        }
        else if(playerLookDirection == 1)
        {
            RFacing();
        }
    }

    public void LookDirectionCheck()
    {
        if(JoyStick.GetJoyVec().x < 0)
        {
            playerLookDirection = -1;
        }
        else if(JoyStick.GetJoyVec().x > 0)
        {
            playerLookDirection = 1;
        }
    }

}
