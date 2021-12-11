using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sub_sym : MonoBehaviour
{
    private float timer;
    private Vector3 scale;
    // Start is called before the first frame update
    void Awake()
    {
        timer = 0;
        scale = gameObject.transform.localScale;
    }
    void Start()
    {
        gameObject.transform.localScale = new Vector3(0f, 0f, 1f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timer < 2f) {
            timer += Time.deltaTime;
            gameObject.transform.localScale = new Vector3(scale.x * (timer * 0.5f), scale.y, 1f);
        }
        
    }
}
