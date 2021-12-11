using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    private float timer, level;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        GameObject.Find("05 matchGirl phase(Clone)").GetComponent<matchGirlPhase>().stopFlame();
        level = GameObject.Find("EventSystem").GetComponent<default_rule>().Get_level();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime * (1.0f + (float)level / 10f);

        if (timer > 1.5f) {
            GameObject.Find("05 matchGirl phase(Clone)").GetComponent<matchGirlPhase>().endPhase();
            Destroy(gameObject);
        }
    }
}
