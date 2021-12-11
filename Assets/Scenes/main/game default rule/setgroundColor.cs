using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setgroundColor : MonoBehaviour
{
    private GameObject lt;
    Renderer colored;
    // Start is called before the first frame update
    void Start()
    {
        lt = GameObject.Find("DefaultLight");
        colored = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        colored.material.color = lt.GetComponent<Light>().color;
    }
}
