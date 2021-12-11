using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bbolbboleSound : MonoBehaviour
{

    public AudioClip ini, ready, run;
    private AudioSource AS;
    private bool moving = false;
    private bool ini_end=false;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0.8f;
        AS = gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if ((!AS.isPlaying)&&(!ini_end)) {

            AS.Stop();
            AS.clip = ready;
            AS.Play();
            ini_end = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        AS.panStereo = gameObject.transform.position.x / 7f;
        if (moving) {

            timer -= Time.deltaTime;
            AS.volume = timer * 2 < 1 ? timer * 4 : 1;
        }
    }

    public void change_audio() {

        AS.Stop();
        AS.clip = run;
        AS.loop = true;
        AS.Play();
        moving = true;
    }

}
