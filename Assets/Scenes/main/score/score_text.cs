using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score_text : MonoBehaviour
{

    private Text myscore;
    Light lt;
    // Start is called before the first frame update
    void Start()
    {
        myscore = GameObject.Find("Score").GetComponent<Text>();
        lt = GameObject.Find("DefaultLight").GetComponent<Light>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SetCountText();
    }

    void SetCountText() {

        myscore.color = lt.color;
        myscore.text = "SCORE: " + GameObject.Find("EventSystem").GetComponent<default_rule>().Get_score()
            +"\nLife: "+ GameObject.Find("Player").GetComponent<player_controller>().get_life()
            +"\nLevel: "+ GameObject.Find("EventSystem").GetComponent<default_rule>().Get_level();
    }
}
