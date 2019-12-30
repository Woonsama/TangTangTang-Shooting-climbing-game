using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logo : MonoBehaviour
{
    public float x_offset;
    public float y_offset;

    public float pingpongTime;

    public void Update()
    {
        PingPong();
    }


    public void PingPong()
    {
        transform.localScale = new Vector3(0.8f + Mathf.PingPong(Time.time / pingpongTime, x_offset), 0.8f + Mathf.PingPong(Time.time / pingpongTime, y_offset), 1);
    }
}
