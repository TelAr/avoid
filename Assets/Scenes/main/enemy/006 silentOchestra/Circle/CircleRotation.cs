using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleRotation : MonoBehaviour
{
    public bool is_left;
    public float speed= 15;
    private float timer;
    private int turn_way;
    private float startAngle;

    // Start is called before the first frame update
    void Start()
    {
        if (is_left)
        {
            turn_way = 1;
        }
        else 
        {
            turn_way = -1;
        }

        startAngle = Random.Range(0f, 360f);

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        timer += Time.deltaTime;
        gameObject.transform.localEulerAngles = new Vector3(0, 0, startAngle + timer * 15) * turn_way;
    }

}
