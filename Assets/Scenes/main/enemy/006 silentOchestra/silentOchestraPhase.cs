using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class silentOchestraPhase : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ochestra;
    public GameObject BGMObject;
    public GameObject[] cutton;
    public GameObject[] circles;
    public GameObject[] sub;
    public GameObject high_note;
    public GameObject targetting;
    public GameObject dacapo;
    public AudioClip[] symphony;
    public GameObject[] movements;
    public GameObject backGround;

    public float timer = 0f, high_timer = 0f;
    private float curtainTime = 8f;
    private int high_counter=0;
    private bool is_ochestra;
    private bool is_finale;
    private bool dacapo_spawn;
    private bool endingCurtain;
    private AudioSource audioController;
    private int phase = 0;
    private GameObject player;
    private GameObject inst_target;
    private GameObject BGM;
    private GameObject MainController;
    void Start()
    {
        Instantiate(cutton[0], this.gameObject.transform);
        Instantiate(cutton[1], this.gameObject.transform);
        Instantiate(cutton[2], this.gameObject.transform);
        Instantiate(BGMObject, this.gameObject.transform);
        audioController = gameObject.GetComponent<AudioSource>();
        is_ochestra = false;
        is_finale = false;
        dacapo_spawn = false;
        endingCurtain = false;
        player = GameObject.Find("Player");
        MainController = GameObject.Find("EventSystem");
        MainController.GetComponent<BGM_Controller>().volumeDOWN();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (timer > curtainTime * 0.5f) {

            if (!is_ochestra) {
                Instantiate(ochestra, this.gameObject.transform);
                Instantiate(backGround, this.gameObject.transform);
                is_ochestra = true;
            }
        }

        if (!audioController.isPlaying) {
            Debug.Log("next"+ phase);
            if (phase < 4) {
                Instantiate(circles[phase], this.gameObject.transform);
                Instantiate(sub[phase], this.gameObject.transform);
            }
            Instantiate(movements[phase], this.gameObject.transform);
            phase++;
            audioController.clip = symphony[phase];
            audioController.Play();
        }

        if (phase > 0) {

            high_timer += Time.deltaTime;
            if (high_timer > 1.8f) {

                high_timer = 0;
                high_counter++;
                if (high_counter < 4)
                {
                    Instantiate(high_note, new Vector3(Random.Range(-8.5f, 8.5f), 6f, 0), Quaternion.identity);
                }
                else {

                    Instantiate(high_note, new Vector3(player.transform.position.x, 6f, 0), Quaternion.identity);
                    high_counter = 0;
                }
                
                
            }
        }

        if (timer > 77f&& !is_finale) {
            is_finale = true;
            Instantiate(targetting,gameObject.transform);
            for (int i = 0; i < transform.childCount; i++) {
                GameObject gobj = transform.GetChild(i).gameObject;
                if (gobj.tag == "circle") {
                    gobj.GetComponent<CircleScale>().SetFinale();
                }
                if (gobj.tag == "targetting") {
                    inst_target = gobj;
                }
                if (gobj.tag == "BGM") {

                    BGM = gobj;
                }
            }
        }
        if (timer > 85.75f) {
            if (inst_target != null) {
                inst_target.GetComponent<Targetting_y>().is_move = false;
            }
        }

        if (timer > 86.7f) {

            if (!dacapo_spawn) {
                Instantiate(dacapo, new Vector3(10f, inst_target.transform.position.y), Quaternion.identity);
                dacapo_spawn = true;
                Destroy(inst_target);
                inst_target = null;
            }
            
        }

        if (timer > 90f) {

            high_timer = -1000f;
        }
        if (timer > 92f) {

            if (!endingCurtain) {
                Instantiate(cutton[0], this.gameObject.transform);
                Instantiate(cutton[1], this.gameObject.transform);
                Instantiate(cutton[2], this.gameObject.transform);
                endingCurtain = true;
            }
            BGM.GetComponent<AudioSource>().volume = ((curtainTime * 0.5f)-(timer - 92f)) / (curtainTime*0.5f);
        }


        if (timer > 92f + curtainTime * 0.5) {

            End();
        }

    }

    public float CurtainTime_get() {

        return curtainTime;
    }
    public bool Finale() {

        return is_finale;
    }

    public void End() {

        MainController.GetComponent<BGM_Controller>().volumeUP();
        MainController.GetComponent<default_rule>().Recv_endOfPhase();
        Destroy(gameObject);
        return;
    }

}
