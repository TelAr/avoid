using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullWeaponTarget : MonoBehaviour
{
    public GameObject weapon;
    private GameObject player;
    private float timer;
    private Vector3 default_scale;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        timer = 0f;
        gameObject.transform.position = new Vector3(player.transform.position.x, 0f);
        default_scale = gameObject.transform.localScale;
        gameObject.transform.localScale = new Vector3(0, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer < 2f) {
            gameObject.transform.position = new Vector3(player.transform.position.x, 0f);
            gameObject.transform.localScale = new Vector3(timer * 0.5f * default_scale.x, default_scale.y);
        }
        if (timer > 3f) {

            Instantiate(weapon, new Vector3(gameObject.transform.position.x, 7.5f), Quaternion.Euler(0,0,90f));
            Destroy(gameObject);
        }
    }
}
