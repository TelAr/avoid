using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class life_checker : MonoBehaviour
{

    public GameObject lt;
    public GameObject player;


    public enum State { safe, first, second, third };
    State now, before;

    // Start is called before the first frame update
    void Start()
    {
        before = State.safe;
    }

    // Update is called once per frame
    void Update()
    {
        if (now != before) {

            if (now == State.safe) {

                lt.GetComponent<Light>().color = Color.green;
                Debug.Log("safe");
                before = now;
            }
            if (now == State.first)
            {

                lt.GetComponent<Light>().color = Color.yellow;
                Debug.Log("1st");
                before = now;
            }
            if (now == State.second)
            {

                lt.GetComponent<Light>().color = new Color(1f, 0.5f, 0f);
                Debug.Log("2nd");
                before = now;
            }
            if (now == State.third)
            {

                lt.GetComponent<Light>().color = Color.red;
                Debug.Log("3rd");
                before = now;
                gameObject.GetComponent<default_rule>().Set_level(4);
            }
            gameObject.GetComponent<BGM_Controller>().changeBGM(now);
            player.GetComponent<player_visual>().update_color();
        }

        
    }

    public void set_life(int life) {

        Debug.Log(life);
        switch (life) {

            case 5:
            case 4:
                before = now;
                now = State.safe;
                break;
            case 3:
                if (before == State.safe) {
                    before = now;
                    now = State.first;
                }
                break;
            case 2:
                if (before == State.first) {
                    before = now;
                    now = State.second;
                }
                break;
            case 1:
                if (before == State.second) {
                    before = now;
                    now = State.third;
                }
                break;
        }
    }

    public State now_state() {

        return now;
    }


}

