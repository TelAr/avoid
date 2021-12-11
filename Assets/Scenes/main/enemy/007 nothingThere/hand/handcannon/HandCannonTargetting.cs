using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCannonTargetting : MonoBehaviour
{
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        gameObject.transform.localScale = new Vector3(20f, 0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if(timer<0.5f)
        gameObject.transform.localScale = new Vector3(20f, timer*0.4f);
    }
}
