using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit_type : MonoBehaviour
{
    public int n;

    public AudioClip[] ownclips;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getHitType() {

        return n;
        /*
         * 0: default case
         * 1: slash case
         * 
         * 
         * 
         * -1: own case
         */
    }

    public AudioClip[] get_clips() {

        return ownclips;
    }
}
