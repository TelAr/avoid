using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleScale : MonoBehaviour
{
    private Vector3 startScale;
    private float timer;
    private bool finale, last, send_once=false;
    // Start is called before the first frame update
    void Awake()
    {
        startScale = gameObject.transform.localScale;
        finale = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (finale) {
            timer+=Time.deltaTime;
            if (timer < 5f)
            {
                gameObject.transform.localScale = (new Vector3(1.3f, 1.3f, 1.3f) * (timer) + startScale * (5f - timer))*0.2f;
                
            }

            if (!send_once) {
                send_once = true;
                for (int i = 0; i < transform.childCount; i++)
                {
                    GameObject gobj = transform.GetChild(i).gameObject;
                    if (gameObject.name == "4th" || gameObject.name == "4th(Clone)")
                    {
                        gobj.GetComponent<Note_spawner>().frequency = 0.3f;

                    }
                    else if (gobj.GetComponent<Note_spawner>() != null)
                    {
                        gobj.GetComponent<Note_spawner>().is_spawn = false;
                    }
                    

                }
            }

            if (timer > 9.7f&&timer<10.2f) {
                gameObject.transform.localScale = (new Vector3(8f, 8f, 8f) * (timer-9.7f)*2f + new Vector3(1.3f, 1.3f, 1.3f) * (0.5f - (timer-9.7f))) * 2f;
            }
        }
        if (timer > 10f) {
            for (int i = 0; i < transform.childCount; i++)
            {
                GameObject gobj = transform.GetChild(i).gameObject;
                if (gobj.GetComponent<Note_spawner>() != null)
                {
                    gobj.GetComponent<Note_spawner>().is_spawn = false;
                }


            }
        }

        
    }

    public Vector3 DefaultScale() {

        return startScale;
    }
    public void SetFinale() {

        finale = true;
    }

}
