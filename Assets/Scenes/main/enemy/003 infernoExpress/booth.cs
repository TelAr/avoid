using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class booth : MonoBehaviour
{
    public Sprite[] types;
    private SpriteRenderer sp;
    // Start is called before the first frame update
    void Start()
    {
        sp = gameObject.GetComponent<SpriteRenderer>();
        sp.sprite = types[0];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void ChangeST(int step) {

        if (step < 0) step = 0;
        if (step > 4) step = 4;
        sp.sprite = types[step];
    }
}
