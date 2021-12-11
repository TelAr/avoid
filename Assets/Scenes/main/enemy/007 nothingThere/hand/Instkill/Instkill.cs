using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instkill : MonoBehaviour
{
    public AudioClip finish;
    private float timer;
    private AudioSource ads;
    private bool is_cast;
    private Vector3 defaultRotation;
    private GameObject player;
    // Start is called before the first frame update
    void Awake()
    {
        timer = 0f;
        is_cast = false;
        player = GameObject.Find("Player");
        if (player.transform.position.x > 0)
        {
            gameObject.transform.position = new Vector3(7, 0, 0);
        }
        else {

            gameObject.transform.position = new Vector3(-7, 0, 0);
        }
        if (gameObject.transform.position.x > 0)
        {

            gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else {

            gameObject.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        ads = gameObject.GetComponent<AudioSource>();
        ads.panStereo = gameObject.transform.position.x / 10f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!ads.isPlaying && !is_cast) {
            is_cast = true;
            ads.clip = finish;
            ads.Play();
        }
        if (is_cast) {

            for (int t = 0; t < transform.childCount; t++) {

                if (transform.GetChild(t).GetComponent<InstKillMove>() != null) {

                    transform.GetChild(t).GetComponent<InstKillMove>().Cast();
                }
                if (transform.GetChild(t).tag == "targetting") {
                    Destroy(transform.GetChild(t).gameObject);
                }
            }
        }

        if (timer > 1f) {

            Destroy(gameObject);
        }
    }
}
