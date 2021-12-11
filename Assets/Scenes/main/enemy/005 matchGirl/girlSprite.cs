using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class girlSprite : MonoBehaviour
{
    public Sprite[] sprites;
    public Light lt;
    private SpriteRenderer sr;
    public float timer, stop_timer, limit;
    private bool is_move;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        is_move = false;
        timer = 0f;
        stop_timer = 0f;
        limit = 2f;
        sr = gameObject.GetComponent<SpriteRenderer>();
        lt = GameObject.Find("DefaultLight").GetComponent<Light>();
        sr.color = lt.color - new Color(0f, 0f, 0f, 0.5f * (limit - stop_timer) / limit);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        sr.color = lt.color-new Color(0f,0f,0f,0.5f*(limit - stop_timer)/ limit);
        if (is_move) { 
            timer += Time.deltaTime;
            stop_timer = 0;
            sr.sprite = sprites[(int)(timer * 60f)%30];
        }
        else
        {
            timer = 0;
            stop_timer += Time.deltaTime;
            sr.sprite = sprites[0];
        }

        if (stop_timer > limit) {

            Instantiate(explosion, gameObject.transform.position + new Vector3(0, 1.59f+1.55f, 0), Quaternion.identity);
            
            Destroy(gameObject);
        }
    }

    public void set_is_move(bool tf) {

        is_move = tf;
    }

}
