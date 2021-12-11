using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class danaksusan_movement : MonoBehaviour
{
    private float timer;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        speed = 2;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        transform.Translate(Vector3.up * Mathf.Sin(timer*speed) *Time.deltaTime);
    }
}
