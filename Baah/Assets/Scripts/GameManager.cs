using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public float speed;
    float time;

    int difficulty = 0;
    public int scoreRate;
    public float scoreMultiplier;
    int score = 0;
    int sheepCount = 0;

    public Danger danger1;
    Herd herd;

    Canvas uiCanvas;
    Text scoreText;
    Text sheepCountText;

	// Use this for initialization
	void Start () {
        uiCanvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        scoreText = uiCanvas.transform.GetChild(0).Find("ScoreText").GetComponent<Text>();
        sheepCountText = uiCanvas.transform.GetChild(0).Find("SheepCountText").GetComponent<Text>();

        herd = GameObject.Find("Herd").GetComponent<Herd> ();
        herd.SetGameManager(this);
        sheepCount = herd.GetSheepCount();

        UpdateUI();
    }
	
	// Update is called once per frame
	void Update () {
        danger1.speed = speed;
	}

    private void LateUpdate()
    {
        time += Time.deltaTime;

        if(time >= 0.5f)
        {
            time = 0f;
            score += GetScore();
        }

        UpdateUI();
    }

    int GetScore()
    {
        return scoreRate;
    }

    void UpdateUI()
    {
        scoreText.text = score.ToString().PadLeft(6, '0');
        sheepCountText.text = sheepCount.ToString();
    }

    public void SetSheepCount(int count)
    {
        sheepCount = count;

        UpdateUI();
    }
}
