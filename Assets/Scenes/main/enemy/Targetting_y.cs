using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targetting_y : MonoBehaviour
{

    public bool is_move;
    private GameObject player;
    private Light lt;
    private SpriteRenderer sr;
    private float timer, disappearTimer;

    // Start is called before the first frame update
    void Start()
    {
        is_move = true;
        player =GameObject.Find("Player");
        lt = GameObject.Find("DefaultLight").GetComponent<Light>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        sr.color = new Color(0, 0, 0, 0);
        timer = 0f;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer <= 5f) {
            sr.color = lt.color*(timer)*0.1f;
        }
        if (is_move) {
            transform.position = new Vector3(0f, player.transform.position.y, -3f);
        }
    }

}
