using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_visual : MonoBehaviour
{

    float timer, subtimer;
    bool is_dark;
    player_controller pc;
    Renderer colored;
    public GameObject lt;
    public GameObject shdn;

    // Start is called before the first frame update
    void Start()
    {
        timer = -1;
        subtimer = -1;
        is_dark = false;
        pc = gameObject.GetComponent<player_controller>();
        colored = gameObject.GetComponent<Renderer>();
        colored.material.color = lt.GetComponent<Light>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            if (subtimer < 0) {
                subtimer = 0.15f;
                if (is_dark)
                {
                    colored.material.color = lt.GetComponent<Light>().color;
                    is_dark = false;
                }
                else {
                    colored.material.color = lt.GetComponent<Light>().color * 0.5f;
                    is_dark = true;
                }
            }
        }
        else if (is_dark) {

            colored.material.color = lt.GetComponent<Light>().color;
            is_dark = false;
        }
        timer -= Time.deltaTime;
        subtimer -= Time.deltaTime;
    }

    public void dmg(float n) {

        timer = n;
    }

    public void update_color() {

        colored.material.color = lt.GetComponent<Light>().color;
    }
}
