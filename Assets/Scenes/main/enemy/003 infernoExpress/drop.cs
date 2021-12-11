using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drop : MonoBehaviour
{
    public int way=0;//0=down, 1=up, 2=legt, 3=right
    public float speed=10, randomRange=0;
    private float realSpeed;
    private Rigidbody2D rb;
    private float level;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        level = GameObject.Find("EventSystem").GetComponent<default_rule>().Get_level();
        realSpeed = (speed+Random.Range(-randomRange, randomRange))*(1.0f+(float)level/10.0f);
        if (gameObject.transform.parent!=null)
        {

            realSpeed = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (way == 0) {
            rb.AddForce(new Vector2(0, -realSpeed));
        }
        

        if (gameObject.transform.position.y < -5.5f) {

            Destroy(gameObject);
        }
    }

    public float get_realSpeed() {

        return realSpeed;
    }
}
