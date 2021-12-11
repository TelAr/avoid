using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setBrightOrDark : MonoBehaviour
{
    SpriteRenderer sp_render;
    Light lt;
    Color ltColor, shdColor;
    public bool is_light;

    // Start is called before the first frame update
    void Start()
    {
        sp_render = GetComponent<SpriteRenderer>();
        lt = GameObject.Find("DefaultLight").GetComponent<Light>();
        ltColor = lt.color;
        shdColor = ltColor * 0.5f + new Color(0, 0, 0, 1f);
        if (is_light)
        {
            sp_render.color = ltColor;
        }
        else {
            sp_render.color = shdColor;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ltColor = lt.color;
        shdColor = ltColor * 0.5f + new Color(0, 0, 0, 1f);
        if (sp_render.color != shdColor || sp_render.color != ltColor) {

            if (is_light)
            {
                sp_render.color = ltColor;
            }
            else {
                sp_render.color = shdColor;
            }
        }
    }

    public void Convert() {

        if (is_light)
        {
            is_light = false;
            sp_render.color = shdColor;
        }
        else {
            is_light = true;
            sp_render.color = ltColor;
        }
    }

}
