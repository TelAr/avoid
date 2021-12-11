using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ticket : MonoBehaviour
{
    private GameObject phase;
    private int level;

    private void Awake()
    {
        level = GameObject.Find("EventSystem").GetComponent<default_rule>().Get_level();

        if (level > 2) {

            gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (level > 0)
        {
            gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        phase = GameObject.Find("03_expresstrain(Clone)");

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit");
        if (collision.gameObject.tag == "Player")
        {
            phase.GetComponent<expressPhase>().get_ticket();
            Destroy(gameObject);
        }
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
