using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class set_shadow : MonoBehaviour
{
    SpriteRenderer sp_render;
    Light lt;

    // Start is called before the first frame update
    void Awake()
    {
        sp_render = GetComponent<SpriteRenderer>();
        lt = GameObject.Find("DefaultLight").GetComponent<Light>();
        sp_render.color = lt.color*0.5f+new Color(0,0,0,1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (sp_render.color != lt.color*0.5f + new Color(0, 0, 0, 1f)) {
            sp_render.color = lt.color*0.5f + new Color(0, 0, 0, 1f);
        }

    }
}
