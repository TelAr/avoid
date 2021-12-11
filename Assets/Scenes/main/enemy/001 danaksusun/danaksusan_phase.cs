using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class danaksusan_phase : MonoBehaviour
{
    private float timer;
    public GameObject shadow_dan;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        Instantiate(shadow_dan, new Vector3(0, 1.5f, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
