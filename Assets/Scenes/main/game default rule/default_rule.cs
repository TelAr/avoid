using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class default_rule : MonoBehaviour
{

    private long  score;
    private int count, index, last_index;
    private int level = 0;
    private float timer;
    private float score_tick;
    private bool is_next;
    private bool is_hurt;
    public GameObject[] phases;
    public GameObject heal;
    public GameObject player;
    public GameObject ground;
    private bool is_first;
    private bool run = false;


    private void Awake()
    {
        var obj = GameObject.FindGameObjectsWithTag("GameController"); 
        if (obj.Length == 1) { 
            DontDestroyOnLoad(gameObject); 
        } 
        else {
            for (int i = 0; i < obj.Length; i++) {

                if (obj[i].GetComponent<default_rule>()==null) {

                    Destroy(obj[i].gameObject);
                }
            }
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        count = 0;
        score = 0;
        score_tick = 0f;
        timer = 2f;
        is_next = true;
        is_hurt = false;
        is_first = true;
        last_index = 0;
        run = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //스코어 틱 보정
        score_tick += Time.deltaTime;
        if (1 < score_tick * 30f) {
            score++;
            score_tick = 0f;
        }

        //대기시간 돌기
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else {
            timer = -1;
        }

        //페이즈 시작
        if (is_next && timer < 0) {

            if (count >= 5) {//레벨 증가
                if (Get_level() < 4) {
                    Set_level(Get_level()+1);
                }
                count = 0;
            }
            if (is_first)//처음 실행시 단악수선 등장
            {
                index = 0;
                is_first = false;
            }
            else {
                while(true)
                {
                    index = Random.Range(0, phases.Length);
                    if (((index == 0) && (player.GetComponent<player_controller>().get_life() != 1)) //단악수선 확률 변동, 단 또 굴려도 단악수선이면 그때는 등장 허용
                        ) 
                    { //roll again
                        index = Random.Range(0, phases.Length);
                    }
                    if (phases[index].tag == "Aleph" && (level < 4))//알레프급 등장조건 조정
                    {

                        continue;
                    }
                    else if (index != last_index) {

                        break;
                    }
                }
            }
            Debug.Log(index);
            Instantiate(phases[index]);
            last_index = index;
            is_next = false;
            count++;
        }
        if (player.GetComponent<player_controller>().get_life() == 0)
        {
            SceneManager.LoadScene("end");
        }
        if (Input.GetKeyDown(KeyCode.Escape)) {

            SceneManager.LoadScene("start");
            Destroy(gameObject);
        }
    }

    public long Get_score() {

        return score;
    }
    public void Set_level(int value)
    {
        level = value;
    }
    public int Get_level() {

        return level;
    }

    public void Caculate_score(long point) {

        score += point;
    }

    public void Recv_endOfPhase() {

        timer = 2.0f;
        is_next = true;
        if (!is_hurt) {
            if (level < 3) {
                Set_heal();
            }
            if (phases[last_index].tag=="Aleph") {

                score += 2000;
            }
            
        }
        if (!ground.active) {

            ground.active = true;
        }
        is_hurt = false;
    }

    public void Set_heal() {

        if (!GameObject.Find("HEAL(Clone)"))
        {
            Instantiate(heal);
        }
    }

    public void Hurt() {

        is_hurt = true;
    }
    public bool Is_run() {

        return run;
    }
}
