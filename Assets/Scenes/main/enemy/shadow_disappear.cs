using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shadow_disappear : MonoBehaviour
{
    public GameObject real;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        timer += Time.deltaTime;
        if (timer > 2f) {
            Debug.Log("time out");
            GameObject realobj = Instantiate(real);
            realobj.transform.position = gameObject.transform.position;
            Destroy(gameObject);
        }
    }
}
