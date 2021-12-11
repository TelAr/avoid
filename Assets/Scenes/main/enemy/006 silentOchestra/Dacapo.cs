using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dacapo : MonoBehaviour
{
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        transform.Translate(new Vector3(-40f*Time.deltaTime,0f));
        if (timer > 3f) {

            Destroy(gameObject);
        }
    }
}
