using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class expess : MonoBehaviour
{
    private float timer;
    public Sprite[] sprite;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer > 2f) {

            gameObject.GetComponent<AudioSource>().volume = 3 - timer;
        }
        if (timer > 3f) {
            Destroy(gameObject);
        }
        transform.Translate(Vector3.left * 50 * Time.deltaTime);
    }
}
