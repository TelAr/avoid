using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    private float timer;
    private float default_rotation;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ground")
        {
            collision.gameObject.active = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        default_rotation = gameObject.transform.localRotation.eulerAngles.z;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer < 0.5f) {

            gameObject.transform.localRotation = Quaternion.Euler(0, 0, default_rotation + 2f * timer * 360f);
        }
    }
}
