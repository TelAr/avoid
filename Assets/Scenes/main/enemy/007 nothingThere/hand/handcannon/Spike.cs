using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private bool is_shoot = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (is_shoot) {

            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.transform.Translate(new Vector3(80f * Time.deltaTime, 0, 0));
        }
    }
    public void Shoot() {

        is_shoot = true;
    }
}
