using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstKillMove : MonoBehaviour
{
    private float timer;
    private bool is_cast;
    private Vector3 defaultRotation;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        is_cast = false;
        gameObject.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, -247));
        defaultRotation = gameObject.transform.localRotation.eulerAngles;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (is_cast) {
            timer += Time.deltaTime;
            if (timer < 0.66f) {
                gameObject.transform.localRotation = Quaternion.Euler(0, 0, defaultRotation.z + 360f * timer*1.5f);
            }
        }
    }

    public void Cast() {

        is_cast = true;
    }
}
