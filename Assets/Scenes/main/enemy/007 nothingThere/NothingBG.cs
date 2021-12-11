using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NothingBG : MonoBehaviour
{

    private SpriteRenderer sr;
    private Light lt;
    private float timer;
    private bool is_over;
    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        lt = GameObject.Find("DefaultLight").GetComponent<Light>();
        sr.color = new Color(0, 0, 0);
        is_over = false;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        sr.color = lt.color;
        if (timer < 2) {
            timer += Time.deltaTime;
            sr.color = lt.color * (timer * 0.5f);
        }
        if (is_over) {

            timer -= Time.deltaTime;
            if (timer < 0) {
                Destroy(gameObject);
            }
            sr.color = lt.color * (timer * 0.5f);
            
        }
    }

    public void Over()
    {
        is_over = true;
    }
}
