using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class borderOf4_Phase : MonoBehaviour
{
    private float timer, endTimer, finalAttack;
    private int unit_amount;
    private int counter, finalConter;
    public GameObject borderOf4;
    private GameObject player;
    private float level;
    Vector3[] set;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("borderOf4_Phase");
        timer = 0f;
        endTimer = 0f;
        finalAttack = 0f;
        unit_amount = 16;
        player = GameObject.Find("Player");
        counter = 0;
        finalConter = 0;
        set = new Vector3[3];
        set[0] = new Vector3(-5f, 3f);
        set[1] = new Vector3(0f, 3f);
        set[2] = new Vector3(5f, 3f);
        Instantiate(borderOf4, new Vector3(0f,0f,0f), Quaternion.identity);
        level = GameObject.Find("EventSystem").GetComponent<default_rule>().Get_level();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (counter < unit_amount) {
            timer += Time.deltaTime*(1.0f+(float)level/10f);
        }
        else {
            endTimer += Time.deltaTime * (1.0f + (float)level / 10f);
            if (level <= 2) {
                if (endTimer > 1.0f)
                {
                    GameObject.Find("EventSystem").GetComponent<default_rule>().Recv_endOfPhase();
                    Destroy(gameObject);
                }
            }
            else{
                finalAttack += Time.deltaTime;
                if (finalAttack > 0.5f) {
                    if (finalConter < 4)
                    {
                        finalAttack = 0f;
                        Vector3 randPos;
                        if (finalConter % 2 == 0)
                        {
                            randPos = new Vector3(Random.Range(-5.0f, 0f), Random.Range(0.0f, 5f));
                        }
                        else {
                            randPos = new Vector3(Random.Range(0f, 5.0f), Random.Range(0.0f, 5f));
                        }
                        
                        Vector3 randDirec = player.transform.position - randPos;
                        Instantiate(borderOf4, randPos, Quaternion.Euler(0f, 0f, Mathf.Rad2Deg * Mathf.Atan2(randDirec[1], randDirec[0])));
                        finalConter++;
                    }
                    else if(level>=4){
                        finalAttack = -100.0f;
                        Vector3[] direction = new Vector3[3];
                        direction[0] = player.transform.position - set[0];
                        direction[1] = player.transform.position - set[1];
                        direction[2] = player.transform.position - set[2];
                        Instantiate(borderOf4, set[0], Quaternion.Euler(0f, 0f, Mathf.Rad2Deg * Mathf.Atan2(direction[0][1], direction[0][0])));
                        Instantiate(borderOf4, set[1], Quaternion.Euler(0f, 0f, Mathf.Rad2Deg * Mathf.Atan2(direction[1][1], direction[1][0])));
                        Instantiate(borderOf4, set[2], Quaternion.Euler(0f, 0f, Mathf.Rad2Deg * Mathf.Atan2(direction[2][1], direction[2][0])));
                        Instantiate(borderOf4, new Vector3(0f, -2.2f, 0f), Quaternion.identity);
                    }
                }
                if (endTimer > 4.0f) {
                    GameObject.Find("EventSystem").GetComponent<default_rule>().Recv_endOfPhase();
                    Destroy(gameObject);
                }     
            }
        }

        if ((timer >= 2.5f)&&(counter<=unit_amount)) {

            timer -= 3f;
            
            if ((counter / 4) % 2 == 1)
            {
                Vector3[] direction = new Vector3[3];
                direction[0] = player.transform.position - set[0];
                direction[1] = player.transform.position - set[1];
                direction[2] = player.transform.position - set[2];
                Instantiate(borderOf4, set[0], Quaternion.Euler(0f, 0f, Mathf.Rad2Deg * Mathf.Atan2(direction[0][1], direction[0][0])));
                Instantiate(borderOf4, set[1], Quaternion.Euler(0f, 0f, Mathf.Rad2Deg * Mathf.Atan2(direction[1][1], direction[1][0])));
                Instantiate(borderOf4, set[2], Quaternion.Euler(0f, 0f, Mathf.Rad2Deg * Mathf.Atan2(direction[2][1], direction[2][0])));
                Instantiate(borderOf4, new Vector3(0f, -2.2f, 0f), Quaternion.identity);
            }
            else {
                Instantiate(borderOf4, set[0] + new Vector3(0, Random.Range(-0.5f, 0.5f)) * 4,
                    Quaternion.Euler(0, 0, Random.Range(-90f, 90f)));
                Instantiate(borderOf4, set[1] + new Vector3(0, Random.Range(-0.5f, 0.5f)) * 4,
                    Quaternion.Euler(0, 0, Random.Range(-90f, 90f)));
                Instantiate(borderOf4, set[2] + new Vector3(0, Random.Range(-0.5f, 0.5f)) * 4,
                    Quaternion.Euler(0, 0, Random.Range(-90f, 90f)));
                Instantiate(borderOf4, new Vector3(0f, -2.2f, 0f), Quaternion.identity);
            }
            
        }


    }

    public void add_counter() {
        counter++;
    }
}
