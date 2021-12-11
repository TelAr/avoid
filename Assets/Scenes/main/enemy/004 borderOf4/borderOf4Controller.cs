using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class borderOf4Controller : MonoBehaviour
{

    public Sprite[] sprites;
    public GameObject hitEffect;
    private SpriteRenderer sr;
    private float timer, term, level;
    private int counter;
    private Color tempColor;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        term = 0.5f;
        sr = gameObject.GetComponent<SpriteRenderer>();
        sr.color = GameObject.Find("DefaultLight").GetComponent<Light>().color*0.5f;
        sr.sprite = sprites[0];
        counter = 0;
        tempColor = sr.color;
        level = GameObject.Find("EventSystem").GetComponent<default_rule>().Get_level();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime * (1.0f + (float)level / 20f);

        
        if (timer >= term) {

            if (counter == 1) {
                Instantiate(hitEffect,gameObject.transform);
                counter++;
                if (counter/2 < 5) {
                    sr.sprite = sprites[counter];
                }
            }
        }
        else if (timer >= term * 0.5f)
        {
            counter = 1;
            sr.sprite = sprites[counter];
        }

        if (timer >= term + 1f) {
            if (GameObject.Find("04_BorderOf4 Phase(Clone)").GetComponent<borderOf4_Phase>() != null) {
                GameObject.Find("04_BorderOf4 Phase(Clone)").GetComponent<borderOf4_Phase>().add_counter();
            }
            Destroy(gameObject);
        }
        sr.color = GameObject.Find("DefaultLight").GetComponent<Light>().color*0.5f+new Color(0,0,0,0.5f);
        tempColor = sr.color;
        if (timer >= 1f){

            sr.color = tempColor - new Color(0, 0, 0, (timer - 1f) * 2);
        }

    }
}
