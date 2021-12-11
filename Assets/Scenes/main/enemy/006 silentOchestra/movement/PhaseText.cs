using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseText : MonoBehaviour
{
    private float timer;
    private SpriteRenderer sr;
    private Light lt;
    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        lt = GameObject.Find("DefaultLight").GetComponent<Light>();
        sr.color = new Color(0, 0, 0, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        sr.color = lt.color;
        timer += Time.deltaTime;
        if (timer < 2f)
        {
            sr.color = lt.color * (0.5f * timer);
        }

        if (timer > 6f) {

            sr.color = lt.color * (0.5f * (2f-(timer-6f)));
        }

        if (timer > 8f) {

            Destroy(gameObject);
        }
    }
}
