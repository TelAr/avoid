using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class matchGirlPhase : MonoBehaviour
{
    public GameObject match, matchGirl, flame;
    private float timer = 0f, level;
    private int count = 0;
    private bool is_flame = true;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(match, new Vector2(0.55f, 2f), Quaternion.identity);
        Instantiate(matchGirl);
        level = GameObject.Find("EventSystem").GetComponent<default_rule>().Get_level();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime * (1.0f + (float)level / 10f);

        if (timer > 1.2f&& is_flame) {

            if (count >= 9+level)
            {

                endPhase();

            }
            else {
                gameObject.GetComponent<AudioSource>().Play();
                count += 1;
                timer = 0;
                Instantiate(flame, new Vector2(0f, 2.7f), Quaternion.identity);
                Instantiate(flame, new Vector2(0f, 2.7f), Quaternion.identity);
                Instantiate(flame, new Vector2(0f, 2.7f), Quaternion.identity);
                Instantiate(flame, new Vector2(0f, 2.7f), Quaternion.identity);
                Instantiate(flame, new Vector2(0f, 2.7f), Quaternion.identity);
                Instantiate(flame, new Vector2(0f, 2.7f), Quaternion.identity);
                Instantiate(flame, new Vector2(0f, 2.7f), Quaternion.identity);
                Instantiate(flame, new Vector2(0f, 2.7f), Quaternion.identity);
                Instantiate(flame, new Vector2(0f, 2.7f), Quaternion.identity);
                Instantiate(flame, new Vector2(0f, 2.7f), Quaternion.identity);
                for (int k = 0; k < level; k++) {

                    Instantiate(flame, new Vector2(0f, 2.7f), Quaternion.identity);
                }
            }
            
        }


    }
    public void endPhase() {
        
        if (GameObject.Find("matchGirl(Clone)") != null) {

            Destroy(GameObject.Find("matchGirl(Clone)"));
        }
        if (GameObject.Find("match(Clone)") != null)
        {

            Destroy(GameObject.Find("match(Clone)"));
        }
        GameObject.Find("EventSystem").GetComponent<default_rule>().Recv_endOfPhase();
        Destroy(gameObject);
    }

    public void stopFlame() {
        is_flame = false;
    }
}
