using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class danaksusan_controller : MonoBehaviour
{
    private GameObject eventController;
    private AudioSource ads;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 8;
        eventController= GameObject.Find("EventSystem");
        ads = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            eventController.GetComponent<default_rule>().Recv_endOfPhase();
            Destroy(GameObject.Find("01_danaksusan_phase(Clone)"));
            Destroy(gameObject);
        }
        else if (timer <= 1) {

            ads.volume = timer;
        }
    }
}
