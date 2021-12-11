using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flame : MonoBehaviour
{
    Rigidbody2D rb;
    private float size;
    private float timer;
    private float level;
    // Start is called before the first frame update
    void Awake()
    {
        rb=gameObject.GetComponent<Rigidbody2D>();
        timer = 0;
        level = GameObject.Find("EventSystem").GetComponent<default_rule>().Get_level();
        gameObject.transform.localPosition = gameObject.transform.localPosition - new Vector3(0, 0, Random.Range(0.01f, 1f));

        rb.AddForce(new Vector2(Random.Range(-300f, 300f), Random.Range(200f,300f))* (1.0f + (float)level / 8f));
        size = Random.Range(0.3f, 0.7f);
        gameObject.transform.localScale = new Vector2(size, size);

        rb.gravityScale = (1.0f + (float)level / 4f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (timer > 0.3f) {

            timer = 0;
            gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x*(-1f), gameObject.transform.localScale.y);
        }

        if (gameObject.transform.position.y < -6f) {

            Destroy(gameObject);
        }
    }
}
