using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour
{
    public Transform Stick;
    private Vector3 StickFirstPos;
    public static  Vector3 JoyVec;

    private float Radius;
    private static bool isDrag;

    //Change Direction
    public static int moveVec_x;
    public static int moveVec_y;


    void Start()
    {
        Radius = GetComponent<RectTransform>().sizeDelta.y * 0.5f;
        StickFirstPos = Stick.transform.position;

        //About Canvas size change to radius
        float Can = transform.parent.GetComponent<RectTransform>().localScale.x;
        Radius *= Can;

        moveVec_x = 0;
        moveVec_y = 0;
    }

    public void Drag(BaseEventData _Data)
    {
        isDrag = true;

        PointerEventData Data = _Data as PointerEventData;
        Vector3 Pos = Data.position;
        JoyVec = (Pos - StickFirstPos).normalized;
        float Dis = Vector3.Distance(Pos, StickFirstPos);

        if (Dis < Radius)
        {
            Stick.position = StickFirstPos + JoyVec * Dis;
        }
        else
        {
            Stick.position = StickFirstPos + JoyVec * Radius;
        }

        DirectionCheck(JoyVec);
    }

    public void DirectionCheck(Vector3 pos)
    {

        if (pos.x > 0.7f)
        {
            moveVec_x = 1;
        }
        else if (pos.x < -0.7f)
        {
            moveVec_x = -1;
        }
   

        if(pos.y > 0.7f)
        {
            moveVec_y = 1;
        }
        else if(pos.y < -0.7f)
        {
            moveVec_y = -1;
        }
    }

    public void DragEnd()
    {
        moveVec_x = 0;
        moveVec_y = 0;

        isDrag = false;
        Stick.position = StickFirstPos;
        JoyVec = Vector3.zero;
    }

    public static bool DragCheck()
    {
        return isDrag;
    }

    public static float GetMoveVecX()
    {
        return moveVec_x;
    }
    public static void SetMoveVec_x(int value)
    {
        moveVec_x = value;
    }

    public static float GetMoveVecY()
    {
        return moveVec_y;
    }
    public static void SetMoveVec_Y(int value)
    {
        moveVec_y = value;
    }

    public static Vector3 GetJoyVec()
    {
        return JoyVec;
    }
}
