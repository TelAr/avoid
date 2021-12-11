using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCannon : MonoBehaviour
{
    public AudioClip ching;
    public GameObject[] finderRotation;
    public GameObject armRotation;
    public GameObject targetting;
    public GameObject spike;
    private AudioSource audioSource;
    private bool is_shoot;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        is_shoot = false;
        if (gameObject.transform.position.x > 0)
        {

            gameObject.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else {

            gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        audioSource.panStereo = gameObject.transform.localPosition.x * 0.1f;
        audioSource.volume = 0.5f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!audioSource.isPlaying) {

            if (!is_shoot)
            {
                
                is_shoot = true;
                audioSource.clip = ching;
                audioSource.Play();
                
                spike.active = true;
                spike.GetComponent<Spike>().Shoot();
                Destroy(targetting);
                for (int t = 0; t < finderRotation.Length; t++) {

                    finderRotation[t].GetComponent<FingerReboundMove>().Rebound();
                }
                armRotation.GetComponent<ArmMotion>().Shoot();
            }
            else {
                Destroy(gameObject);
            }
        }
        if (is_shoot) {
            if (gameObject.transform.position.x > 0)
            {
                gameObject.transform.Translate(new Vector3(10 * Time.deltaTime, 0));
            }
            else {
                gameObject.transform.Translate(new Vector3(-10 * Time.deltaTime, 0));
            }
            
        }
    }
}
