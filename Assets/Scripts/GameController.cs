using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;
public class GameController : MonoBehaviour {

    enum STATE
    {
        START,
        END
    }

    public GameObject stateText, scoreText,timeText,textPrefab;
    public string[] a_dict;
    public string[] ki_dict;
    float time;
    int score;
    STATE currentState;

	// Use this for initialization
	void Start () {
        currentState = STATE.END;
        CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
	}
	
	// Update is called once per frame
	void Update () {
		if (currentState == STATE.START)
        {
            time-=Time.deltaTime;
            timeText.GetComponent<Text>().text = "Time : " + Mathf.RoundToInt(time);
            if (time < 0)
            {
                currentState = STATE.END;
                stateText.GetComponent<Text>().text = "";
                DestroyAllChildren();
            }
        }
    }

    public void StartGame(string name)
    {
        if (currentState == STATE.END)
        {
            stateText.GetComponent<Text>().text = "Current Task : "+name;
            scoreText.GetComponent<Text>().text = "Score : " + 0;
            timeText.GetComponent<Text>().text = "Time : " + 3;

            string[] correct = a_dict;
            string[] wrong = ki_dict;
            if (name == "ki")
            {
                correct = ki_dict;
                wrong = a_dict;
            }
            
            foreach (string w in correct){
                GameObject text = Instantiate(textPrefab, transform);
                text.GetComponent<TextMesh>().text = w;
                text.GetComponent<TextBehaviour>().isCorrect = true;
                text.transform.position += new Vector3(Random.Range(-1f, 1f), 0, 0) ;
            }

            foreach (string w in wrong)
            {
                GameObject text = Instantiate(textPrefab, transform);
                text.GetComponent<TextMesh>().text = w;
                text.transform.position += new Vector3(Random.Range(-1f, 1f), 0, 0);
            }

            currentState = STATE.START;
            time = 10;
            score = 0;
        }
    }

    public void UpdateScore(bool isCorrect)
    {
        if (isCorrect)
        {
            score++;
        }else
        {
            score--;
        }
       
        scoreText.GetComponent<Text>().text = "Score : " + score;
    }

    void DestroyAllChildren()
    {
        for (int i = 0; i < transform.childCount; i++) Destroy(transform.GetChild(i).gameObject);
    }
}
