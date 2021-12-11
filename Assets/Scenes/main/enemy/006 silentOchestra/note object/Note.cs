using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public Sprite[] sprites;
    Light lt;
    private SpriteRenderer sr;
    private int count;
    // Start is called before the first frame update
    void Awake()
    {
        count = 0;
        sr = gameObject.GetComponent<SpriteRenderer>();
        lt = GameObject.Find("DefaultLight").GetComponent<Light>();
        gameObject.tag = "damage";
        sr.color = lt.color;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        sr.sprite = sprites[count];
        sr.color = lt.color;
        count++;
        if (count >= sprites.Length) {
            count = 0;
        }
    }
}
