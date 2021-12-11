using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class set_color : MonoBehaviour
{
    SpriteRenderer sp_render;
    Light lt;

    // Start is called before the first frame update
    void Awake()
    {
        sp_render = GetComponent<SpriteRenderer>();
        lt = GameObject.Find("DefaultLight").GetComponent<Light>();
        sp_render.color = lt.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (sp_render.color != lt.color)
        {
            sp_render.color = lt.color;
        }
    }
}
