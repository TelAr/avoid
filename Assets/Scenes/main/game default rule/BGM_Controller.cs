using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM_Controller : MonoBehaviour
{
    public AudioClip n, f, s, t;
    private bool is_event;
    private float timer;
    private bool volumeDown, volumeUp;
    // Start is called before the first frame update


    void Start()
    {
        is_event = false;
        volumeDown = false;
        volumeUp = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (volumeDown) {

            if (gameObject.GetComponent<AudioSource>().volume > 0.001f)
            {

                gameObject.GetComponent<AudioSource>().volume -= Time.deltaTime * 0.5f;
            }
            else {

                volumeDown = false;
            }
        }
        if (volumeUp)
        {

            if (gameObject.GetComponent<AudioSource>().volume < 0.999f)
            {

                gameObject.GetComponent<AudioSource>().volume += Time.deltaTime * 0.5f;
            }
            else
            {

                volumeUp = false;
            }
        }

    }

    public void changeBGM(life_checker.State state)
    {

        AudioClip nowBGM = n;
        AudioSource nowScource = this.gameObject.GetComponent<AudioSource>();

        if (is_event)
            return;

        nowScource.Stop();
        switch (state)
        {
            case life_checker.State.safe:
                nowBGM = n;
                break;
            case life_checker.State.first:
                nowBGM = f;
                break;
            case life_checker.State.second:
                nowBGM = s;
                break;
            case life_checker.State.third:
                nowBGM = t;
                break;
        }
        nowScource.clip = nowBGM;
        nowScource.Play();
    }

    public void eventBGM(AudioClip audioClip) {

        AudioSource nowScource = this.gameObject.GetComponent<AudioSource>();
        is_event = true;
        nowScource.Stop();
        nowScource.clip = audioClip;
        nowScource.Play();
    }

    public void eventOver() {

        is_event = false;
        changeBGM(this.gameObject.GetComponent<life_checker>().now_state());
    }

    public void volumeUP() {

        volumeUp = true;
    }
    public void volumeDOWN() {

        volumeDown = true;
    }
}
