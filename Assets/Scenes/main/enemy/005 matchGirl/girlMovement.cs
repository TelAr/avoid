using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class girlMovement : MonoBehaviour
{

    private GameObject player;
    private float xpos;
    private const float limit = 1.5f, speed=4f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        xpos = player.transform.position.x;

        if (gameObject.transform.position.x + limit < xpos)
        {

            transform.Translate(Vector3.right * speed * Time.deltaTime);
            transform.localScale = new Vector3(-1f, 1f, 1f);
            gameObject.GetComponent<girlSprite>().set_is_move(true);
        }
        else if (gameObject.transform.position.x - limit > xpos)
        {

            transform.Translate(Vector3.left * speed * Time.deltaTime);
            transform.localScale = new Vector3(1f, 1f, 1f);
            gameObject.GetComponent<girlSprite>().set_is_move(true);
        }
        else {
            gameObject.GetComponent<girlSprite>().set_is_move(false);
        }
    }
}
