using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bbolbboleMovement : MonoBehaviour
{
    private float timer;
    private float speed;
    private int direction;
    private bool is_send;
    private int level;
    // Start is called before the first frame update
    void Start()
    {
        timer = 2.0f;
        speed = 20.0f;
        is_send = false;
        gameObject.tag = "Untagged";
        if (gameObject.transform.localScale.x > 0)
        {

            direction = 1;
        }
        else {

            direction = -1;
        }
        level = GameObject.Find("EventSystem").GetComponent<default_rule>().Get_level();
        timer -= 1.0f * ((float)level / 4.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer -= Time.deltaTime;
        if (timer < 0) {
            if (!is_send) {
                is_send = true;
                GetComponent<bbolbboleSprite>().set_speed(30);
                gameObject.GetComponent<setBrightOrDark>().Convert();
                GetComponent<bbolbboleSound>().change_audio();
                gameObject.tag = "damage";
            }
            transform.Translate(new Vector3(direction, 0) * speed * Time.deltaTime);
        }

        if (gameObject.transform.position.x > 10f || gameObject.transform.position.x < -10f) {

            Destroy(gameObject);
        }
    }
}
