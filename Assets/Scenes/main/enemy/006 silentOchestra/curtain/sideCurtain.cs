using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sideCurtain : MonoBehaviour
{
    private float timer;
    private float curtainTime;
    // Start is called before the first frame update
    void Start()
    {
        GameObject obj;
        if ((obj = GameObject.Find("06_silentOchestra Phase(Clone)")) != null)
        {
            curtainTime = obj.GetComponent<silentOchestraPhase>().CurtainTime_get();
        }
        else if ((obj = GameObject.Find("06_silentOchestra Phase")) != null)
        {
            curtainTime = obj.GetComponent<silentOchestraPhase>().CurtainTime_get();
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > curtainTime+2f) {

            Destroy(gameObject);
        }
    }
}
