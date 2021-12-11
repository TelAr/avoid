using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bbolbboleSprite : MonoBehaviour
{
    public Sprite[] sprites;
    private int speed;
    public float timer;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        speed = 40;
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime* speed*100;
        sr.sprite = sprites[((int)timer/60)%60];
    }

    public void set_speed(int n) {

        speed = n*4;
        return;
    }
}
