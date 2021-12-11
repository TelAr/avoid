using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitController : MonoBehaviour
{

    private float timer;
    private Transform tf;
    float dx, dy;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        tf = gameObject.transform;
        dx = tf.localScale.x;
        dy = tf.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer>=1f/3f) {

            Destroy(gameObject);
        }
        tf.localScale = new Vector3(dx, dy * (1 - 3 * timer) * (1 - 3 * timer));


    }
}
