using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    public float speed;
    public GameObject UI;
    SpriteRenderer sprite;
    Color color;


    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        color = sprite.color;
    }

    void Update()
    {
        color.a = Mathf.Lerp(color.a, 0, speed * Time.deltaTime);
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, color.a);
        if (color.a <= 0.2f)
        {
            UI.SetActive(true);
        }
    }
}
