using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmMotion : MonoBehaviour
{
    private float timer;
    private bool is_shoot;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        is_shoot = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
            if (timer < 0.5f && !is_shoot)
            {
                timer += Time.deltaTime;
            }
            if(is_shoot&&timer>0f) {

                timer -= Time.deltaTime*2;
            }
            
            
        gameObject.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 100 * (0.5f - timer)));

    }
    public void Shoot() {

        is_shoot = true;
    }
}
