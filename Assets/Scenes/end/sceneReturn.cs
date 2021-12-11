using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class sceneReturn : MonoBehaviour
{
    private Text myscore;
    private long score;
    private void Awake()
    {
        if (GameObject.Find("EventSystem") != null)
        {
            score = GameObject.Find("EventSystem").GetComponent<default_rule>().Get_score();
            Destroy(GameObject.Find("EventSystem").GetComponent<default_rule>());
            Destroy(GameObject.Find("EventSystem").GetComponent<life_checker>());
            Destroy(GameObject.Find("EventSystem").GetComponent<score_text>());
        }
        else {

            score = 0;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ScoreData sd = DataSave.Load();
        if (sd == null)
        {
            sd = new ScoreData(score);
        }
        else {
            sd.Input(score);
        }
        DataSave.Save(sd);
        myscore = GameObject.Find("Score").GetComponent<Text>();
        myscore.text = "SCORE: " + score+"\n"+ "HIGH SCORE: "+ sd.Get_list()[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) {
            Debug.Log("exit");
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit(); // 어플리케이션 종료
#endif
        }
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadSceneAsync("loading");
    }

    public long Get_end_score() {

        return score;
    }
}

[System.Serializable]
public class ScoreData {
    private List<long> scores;
    public ScoreData(List<long> scored) {

        scores = scored;
    }

    public ScoreData(long in_score)
    {
        scores = new List<long>();
        scores.Add(in_score);
    }

    public void Input(long in_score) {

        if (scores.Count == 10)
        {
            scores[9] = in_score;
        }
        else {

            scores.Add(in_score);
        }
        scores.Sort();
        scores.Reverse();
    }

    public List<long> Get_list() {
        List<long> temp = scores;
        return temp;
    }

}





public static class DataSave {

    public static void Save(ScoreData _data, string filePath = "log")
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(filePath, FileMode.Create);

        formatter.Serialize(stream, _data);
        stream.Close();
    }

    public static ScoreData Load(string filePath="log")
    {
        if (File.Exists(filePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(filePath, FileMode.Open);

            ScoreData data = formatter.Deserialize(stream) as ScoreData;

            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in" + filePath);
            return null;
        }
    }


}