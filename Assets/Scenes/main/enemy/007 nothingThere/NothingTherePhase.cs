using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NothingTherePhase : MonoBehaviour
{
    public GameObject handCannon, instKill, chunk;
    public GameObject backGround;
    public GameObject weaponTarget;
    public AudioClip noise;

    private float timer;
    private float subtimer;
    private int count;
    private GameObject player;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(backGround, transform);
        Instantiate(weaponTarget, transform);
        timer = 0f;
        subtimer = 0f;
        count = 0;
        player = GameObject.Find("Player");
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (!audioSource.isPlaying) {

            audioSource.clip = noise;
            audioSource.volume = 0.5f;
            audioSource.Play();
        }

        if (timer > 3f && timer < 27f) {
            if (count < 8)
            {

                subtimer += Time.deltaTime;
            }
            else if(count<16) {

                subtimer += Time.deltaTime*1.5f;
            }
            else
            {
                subtimer += Time.deltaTime * 2f;
            }
            if (subtimer > 1.5f) {

                subtimer = 0;
                count++;
                if (count % 2 == 1)
                {

                    Instantiate(handCannon, new Vector3(-7.8f, player.transform.position.y), Quaternion.identity);
                }
                else
                {

                    Instantiate(handCannon, new Vector3(7.8f, player.transform.position.y), Quaternion.identity);
                }
                if (count == 4||count == 8|| count == 12||count ==16) {

                    Instantiate(weaponTarget, transform);
                    if (count == 16) {

                        Instantiate(chunk, player.transform.position, Quaternion.identity);
                    }
                }
            }
        }
        if (timer > 27f&&timer<30f) {

            subtimer += Time.deltaTime;
            if (subtimer > 2f) {

                subtimer = 0f;
                Instantiate(instKill);
            }
        }

        if (timer > 32f) {
            End();
        }

    }
    private void End() {


        GameObject.Find("EventSystem").GetComponent<default_rule>().Recv_endOfPhase();
        Destroy(gameObject);
    }
}
