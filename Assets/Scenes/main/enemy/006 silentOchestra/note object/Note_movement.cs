using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note_movement : MonoBehaviour
{
    public int phase=1;
    public float speed = 3;
    public bool is_x = true;
    private float timer;
    private Vector3 scale;
    // Start is called before the first frame update
    void Awake()
    {
        scale = gameObject.transform.localScale;

    }

    void Start()
    {
        gameObject.transform.localScale = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer < 0.4f) {

            gameObject.transform.localScale = scale * 2.5f * timer;
        }

        if (is_x)
        {
            gameObject.transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime);
        }
        else {

            gameObject.transform.Translate(new Vector3(0, speed, 0) * Time.deltaTime);
        }
        if (timer > 5f) {

            Destroy(gameObject);
        }
    }
}
