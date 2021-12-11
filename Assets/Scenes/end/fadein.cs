using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadein : MonoBehaviour
{
    public float term=1f;
    private float timer;
    private Color Color;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        Color = gameObject.GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (timer <= term)  {
            timer += Time.deltaTime;
            gameObject.GetComponent<SpriteRenderer>().color = Color - new Color(0, 0, 0, 1f) * (term - timer) / term;
        }
    }
}
