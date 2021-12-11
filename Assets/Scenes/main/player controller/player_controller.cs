using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour
{

    private int life;
    private float timer;
    private const int MAX_LIFE = 5;
    private AudioSource ads;
    bool is_ndmg;
    private float speed;
    private int jumpLevel;
    private int jumpStep;
    Rigidbody2D rb;
    public GameObject evc;
    // Start is called before the first frame update
    void Awake()
    {
        life = 5;
        speed = 5;
        jumpLevel = 0;
        jumpStep = 0;
        timer = 0;
        is_ndmg = false;
        rb = gameObject.GetComponent<Rigidbody2D>();
        ads = gameObject.GetComponent<AudioSource>();

        evc.GetComponent<life_checker>().set_life(life);
    }


    private void OnCollisionStay2D(Collision2D collision)//stuck clear
    {
        if (jumpStep >= 1) {
            jumpLevel = 0;
            jumpStep = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("damage") && !is_ndmg)
        {
            Debug.Log("demaged");
            Debug.Log(life);
            --life;
            Debug.Log(life);
            no_damaged(2);
            evc.GetComponent<default_rule>().Hurt();
            evc.GetComponent<life_checker>().set_life(life);
            if (other.gameObject.GetComponent<hit_type>() != null)
            {
                if (other.gameObject.GetComponent<hit_type>().getHitType() != -1)
                {
                    ads.clip = gameObject.GetComponent<hit_sound>().GetAudio(
                        other.gameObject.GetComponent<hit_type>().getHitType());
                }
                else
                {

                    ads.clip = other.gameObject.GetComponent<hit_type>().get_clips()[Random.Range(0, other.gameObject.GetComponent<hit_type>().get_clips().Length)];
                }
            }
            else
            {

                ads.clip = gameObject.GetComponent<hit_sound>().GetAudio();
            }
            ads.Play();

        }
        else if (other.CompareTag("heal"))
        {
            Debug.Log("heal");
            if (life < MAX_LIFE)
            {
                life++;
                evc.GetComponent<life_checker>().set_life(life);
            }
            evc.GetComponent<default_rule>().Caculate_score(500);
            Destroy(other.gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        

    }
    public int get_life() {

        return life;
    } 

    // Update is called once per frame
    void FixedUpdate()
    {
        float realSpeed = speed;
        timer -= Time.deltaTime;

        if (timer < 0) {

            timer = 0;
            is_ndmg = false;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            realSpeed /= 2;
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) 
        {
            transform.Translate(Vector3.left * realSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * realSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow)||Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W))
        {
            if (jumpLevel < 2 && jumpStep == 0)
            {
                if (jumpLevel == 0) {
                    rb.velocity -= new Vector2(0, rb.velocity.y);
                }
                jumpLevel++;
                rb.AddForce(new Vector3(0, 200 - jumpLevel * 40, 0)*1.5f);
            }
            else if (jumpLevel < 102 && jumpStep == 1) {
                if (jumpLevel == 100) {

                    rb.velocity -= new Vector2(0, rb.velocity.y);
                }
                jumpLevel++;
                rb.AddForce(new Vector3(0, 200 - (jumpLevel-100) * 40, 0)*1.5f);
            }
        }
        if (jumpLevel!=0)
            if(!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.Space) &&!Input.GetKey(KeyCode.W))
            {
                if (jumpLevel < 100)
                {
                    jumpLevel = 100;
                    jumpStep = 1;
                }
                else if(jumpLevel>100) {

                    jumpLevel = 200;
                    jumpStep = 2;
                }
            }

        if (Input.GetKey(KeyCode.DownArrow)||Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector2(0, -20f);
        }

        if (transform.position.y < -6.0f) {

            life--;
            no_damaged(2);
            evc.GetComponent<default_rule>().Hurt();
            evc.GetComponent<life_checker>().set_life(life);
            transform.SetPositionAndRotation(new Vector3(0, 0), new Quaternion());
            jumpLevel = 0;
            jumpStep = 0;
            rb.velocity = new Vector2(rb.velocity.x, 0f);
        }


    }

    public void no_damaged(float timed) {

        timer = timed;
        is_ndmg = true;
        GetComponent<player_visual>().dmg(timed);
    }
    public bool get_ndmg() {

        return is_ndmg;
    }
    public void jumpReset() {

        jumpLevel = 0;
        jumpStep = 0;
    }
}
