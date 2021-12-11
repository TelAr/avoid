using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit_sound : MonoBehaviour
{
    public AudioClip[] samples;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public AudioClip GetAudio() //default
    {
        return samples[0];
    }
    public AudioClip GetAudio(int typeofhit) //type
    {
        return samples[typeofhit];
    }
}
