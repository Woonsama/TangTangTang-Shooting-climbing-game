using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffect : MonoBehaviour
{
    int angle;
    Rigidbody2D rigid;
    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.AddForce(new Vector2(0, -Random.Range(100, 300)) * Time.deltaTime, ForceMode2D.Impulse);
        GameObject.Destroy(gameObject, 15);
    }
    void Update()
    {
        if(angle >= 360)
        {
            angle = 0;
        }
        else
        {
            angle++;
        }

        transform.Rotate(0, 0, angle * Random.Range(3,15) * Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground" || collision.tag == "Bullet")
        {
            GameObject.Destroy(gameObject);
        }
    }
}
