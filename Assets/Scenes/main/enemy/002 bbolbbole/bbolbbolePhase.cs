using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bbolbbolePhase : MonoBehaviour
{
    public GameObject BBEl2r, BBEr2l, tempGround, temp;
    private const float sp=7.5f;
    private float timer;
    private bool[] pattern;
    private int final, level;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        pattern = new bool[15];
        for (int k = 0; k < pattern.Length; k++) {
            pattern[k] = true;
        }
        Instantiate(tempGround, new Vector3(-7, -0.5f, 0), Quaternion.identity);
        Instantiate(tempGround, new Vector3(7, -0.5f, 0), Quaternion.identity);
        Instantiate(tempGround, new Vector3(0, -0.5f, 0), Quaternion.identity);
        final = Random.Range(0, 2);
        level = GameObject.Find("EventSystem").GetComponent<default_rule>().Get_level();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime*(1.0f+(float)level/10.0f);

        //0=dl->dr
        //1=dr->dl
        //2=ul->ur
        //3=ur->ul
        if (pattern[0] && timer > 2f) {

            pattern[0] = false;
            createBBE(Random.Range(0, 4));
        }

        if (pattern[1] && timer > 4f)
        {

            pattern[1] = false;
            createBBE(Random.Range(0, 4));
        }

        if (pattern[2] && timer > 6f)
        {
            pattern[2] = false;
            createBBE(Random.Range(0, 2)); ;
        }
        if (pattern[3] && timer > 7f)
        {
            pattern[3] = false;
            createBBE(Random.Range(2, 4));
        }
        if (pattern[4] && timer > 9f)
        {
            pattern[4] = false;
            createBBE(0);
        }
        if (pattern[5] && timer > 9.5f)
        {
            pattern[5] = false;
            createBBE(1);
        }
        if (pattern[6] && timer > 10f)
        {
            pattern[6] = false;
            createBBE(2);
        }
        if (pattern[7] && timer > 10.5f)
        {
            pattern[7] = false;
            createBBE(3);
        }
        if (pattern[8] && timer > 12f)
        {
            pattern[8] = false;
            createBBE(0);
            createBBE(1);
        }
        if (pattern[9] && timer > 13.5f)
        {
            pattern[9] = false;
            if (final == 0)
            {
                createBBE(0);
                if (level >= 2) createBBE(3);
                
            }
            else {
                createBBE(1);
                if (level >= 2) createBBE(2);
            }
            
        }
        if (pattern[10] && timer > 14.5f&& level<2) {
            pattern[10] = false;
            if (final == 0)
            {
                createBBE(3);
            }
            else
            {
                createBBE(2);
            }

        }
        if (pattern[11] && timer > 15f&&level>=3)
        {
            pattern[11] = false;
            createBBE(2);
            createBBE(3);
        }
        if (pattern[12] && timer > 16.5f && level >= 4)
        {
            pattern[12] = false;
            createBBE(1);
            createBBE(0);
        }


        if (timer > (17f+(float)level/1.5f))  {
            if (null != (temp = GameObject.Find("tempground(Clone)")))
            {
                Destroy(temp);
            }
            else {
                GameObject.Find("EventSystem").GetComponent<default_rule>().Recv_endOfPhase();
                Destroy(gameObject);
            }
           
        }
    }
    private void createBBE(int type) {

        switch (type) {

            case 0:
                Instantiate(BBEl2r, new Vector3(-sp, -1.6f), Quaternion.identity);
                break;
            case 1:
                Instantiate(BBEr2l, new Vector3(sp, -1.6f), Quaternion.identity);
                break;
            case 2:
                Instantiate(BBEl2r, new Vector3(-sp, 0.9f), Quaternion.identity);
                break;
            case 3:
                Instantiate(BBEr2l, new Vector3(sp, 0.9f), Quaternion.identity);
                break;
        }
    }
}
