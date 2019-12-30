using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    public float speed;
    SpriteRenderer sprite;
    Color color;
    

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        color = sprite.color;
    }

    void Update()
    {
        color.a = Mathf.Lerp(color.a, 1,speed * Time.deltaTime);
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, color.a);
    }
}
