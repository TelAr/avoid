using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note_spawner : MonoBehaviour
{
    public GameObject note;
    public float frequency = 2f;
    public bool is_spawn = true;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (timer > frequency&& is_spawn) {

            timer = 0;
            Instantiate(note,gameObject.transform);
        }
    }
}
