using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class curtainMovement : MonoBehaviour
{
    private float curtainTime;
    private float timer;
    private float negative_flag = 1f;
    private GameObject obj;
    // Start is called before the first frame update
    void Awake()
    {
        timer = 0f;
        if ((obj = GameObject.Find("06_silentOchestra Phase(Clone)")) != null)
        {
            curtainTime = obj.GetComponent<silentOchestraPhase>().CurtainTime_get();
        }
        else if ((obj = GameObject.Find("06_silentOchestra Phase")) != null) {
            curtainTime = obj.GetComponent<silentOchestraPhase>().CurtainTime_get();
        }
        
        if (gameObject.transform.localScale.x < 0) {

            negative_flag = -1f;
        }
        gameObject.transform.position = new Vector3 (-7f * negative_flag, 0, -1f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer > curtainTime *0.1f) {

            gameObject.transform.position = new Vector3(-3.5f * negative_flag, 0, -1f);
        }
        if (timer > curtainTime *0.3f)
        {

            gameObject.transform.position = new Vector3(0, 0, -1f);
        }
        if (timer > curtainTime *0.7f)
        {

            gameObject.transform.position = new Vector3(-3.5f * negative_flag, 0, -1f);
        }
        if (timer > curtainTime *0.9f)
        {

            gameObject.transform.position = new Vector3(-7f * negative_flag, 0, -1f);
        }
        if (timer > curtainTime) {

            Destroy(gameObject);
        }
    }
}
