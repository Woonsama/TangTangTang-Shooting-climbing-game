using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rigid;
    public float destroyTime;
    public float power;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.AddForce(new Vector2(power * PlayerCtrl.playerLookDirection * Time.deltaTime, 0), ForceMode2D.Impulse);
        GameObject.Destroy(gameObject, destroyTime);
    }

    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Item")
        {
            //점수 증가
            ScoreManager.hit++;
            GameObject.Destroy(gameObject);
        }
    }
}
