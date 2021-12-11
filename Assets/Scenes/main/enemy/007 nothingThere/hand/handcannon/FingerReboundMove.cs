using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerReboundMove : MonoBehaviour
{
    public float after;
    private float before;
    private bool is_shoot=false;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        before = transform.localEulerAngles.z-360f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (is_shoot) {

            timer += Time.deltaTime;
            if (timer <= 0.1f) {
                transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, after * timer * 10f + before * (0.1f - timer) * 10f));
            }   
        }
    }

    public void Rebound() {
        is_shoot = true;
    }
}
