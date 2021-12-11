using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class expressPhase : MonoBehaviour
{
    private float timer, droptimer, ticketTimer, boothTimer;
    private const float MAINTIME = 15f;
    public GameObject booth, express;
    public GameObject bullet, ticket;
    private GameObject controlBooth;
    private bool is_get, finish_flag;
    private bool[] step;
    private int level;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        droptimer = 0;
        ticketTimer = 0;
        boothTimer = 0;
        Instantiate(booth);
        controlBooth = GameObject.Find("booth(Clone)");
        is_get = false;
        finish_flag = false;
        step = new bool[4];
        level = GameObject.Find("EventSystem").GetComponent<default_rule>().Get_level();
        if (level < 2)
        {
            Instantiate(ticket, new Vector3(0f, -2.3f), Quaternion.identity, transform);
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer < MAINTIME) {
            boothTimer += Time.deltaTime * (1.0f + (float)level / 10.0f);
        }
        droptimer -= Time.deltaTime;
        ticketTimer -= Time.deltaTime;
        if (droptimer < 0) {   
            if (timer < MAINTIME-3f)
            {
                Instantiate(bullet, new Vector3(Random.Range(-8.5f, 8.5f), 5.5f), Quaternion.identity);
                droptimer = Random.Range(0.05f, 0.10f);
            }
            else {

                droptimer = 999f;
            }
        }
        if (ticketTimer < 0)
        {
            
            if (timer < MAINTIME-3f)
            {
                Instantiate(ticket, new Vector3(Random.Range(-8.5f, 8.5f), 5.5f), Quaternion.identity);
                ticketTimer = Random.Range(0.5f, 2f);
            }
            else
            {

                ticketTimer = 999f;
            }
        }

        if ((!step[0]) && boothTimer > 2f)
        {
            controlBooth.GetComponent<booth>().ChangeST(1);
            step[0] = true;
        }
        if ((!step[1]) && boothTimer > 4f)
        {
            controlBooth.GetComponent<booth>().ChangeST(2);
            step[1] = true;
        }
        if ((!step[2]) && boothTimer > 6f)
        {
            controlBooth.GetComponent<booth>().ChangeST(3);
            step[2] = true;
        }
        if ((!step[3]) && boothTimer > 8f)
        {
            controlBooth.GetComponent<booth>().ChangeST(4);
            step[3] = true;
        }


        if (boothTimer > 9f&& (!finish_flag)&& timer<MAINTIME) {
            Instantiate(express);
            timer = MAINTIME;
            finish_flag = true;
        }

        if (timer > MAINTIME+1f) {
            GameObject.Find("EventSystem").GetComponent<default_rule>().Recv_endOfPhase();
            Destroy(controlBooth);
            Destroy(gameObject);
        }
    }

    public void get_ticket() {

        is_get = true;

        boothTimer = 0;
        for (int k = 0; k < 4; k++)
        {
            step[k] = false;
        }
        controlBooth.GetComponent<booth>().ChangeST(0);
    }
}
