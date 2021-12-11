using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkUnit : MonoBehaviour
{
    public GameObject chunk;
    public GameObject target;

    private float timer;
    private Vector3 defaultTargetScale;
    // Start is called before the first frame update
    void Awake()
    {
        timer = 0f;
        defaultTargetScale = target.transform.localScale;
        target.transform.localScale = new Vector3(0, 0, 0);

        if (gameObject.transform.localPosition.x > 0) {

            gameObject.transform.localPosition = new Vector3(9.2f, 0);
        }
        else {
            gameObject.transform.localPosition = new Vector3(-9.2f, 0);
            gameObject.transform.localScale = new Vector3(-1, 1);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer < 0.5f) {

            target.transform.localScale = new Vector3(defaultTargetScale.x * timer *2f, defaultTargetScale.y);
        }

        if (timer > 1f) {
            target.active = false;
            chunk.active = true;
        }

        if (timer > 3f) {

            Destroy(gameObject);
        }
    }
}
