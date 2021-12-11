using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletsize : MonoBehaviour
{
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = gameObject.GetComponent<drop>().get_realSpeed();
        gameObject.transform.localScale = new Vector3(0.3f, 0.3f)*(14f/speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
