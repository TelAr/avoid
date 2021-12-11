using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullWeapon : MonoBehaviour
{
    private float timer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ground") {

            collision.gameObject.active = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        gameObject.GetComponent<AudioSource>().panStereo = gameObject.transform.position.x * 0.1f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        transform.Translate(new Vector3(-40f * Time.deltaTime,0));
        if (timer > 2f)
        {

            Destroy(gameObject);
        }
    }
}
