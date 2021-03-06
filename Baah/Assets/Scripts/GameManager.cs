﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public float speed;
    float time;
    float scoreTime;
    float spawnTime;
    float timeInterval;

    public float difficulty = 0;
    public int scoreRate;
    public float scoreMultiplier;
    int score = 0;
    int sheepCount = 0;

    public Danger danger1;
    Transform dangers;
    Herd herd;

    Canvas uiCanvas;
    Text scoreText;
    Text sheepCountText;

    // Use this for initialization
    void Start () {
        uiCanvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        scoreText = uiCanvas.transform.GetChild(0).Find("ScoreText").GetComponent<Text>();
        sheepCountText = uiCanvas.transform.GetChild(0).Find("SheepCountText").GetComponent<Text>();

        dangers = GameObject.Find("Dangers").transform;

        herd = GameObject.Find("Herd").GetComponent<Herd> ();
        herd.SetGameManager(this);
        sheepCount = herd.GetSheepCount();

        NewTimeInterval();

        UpdateUI();
    }
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        spawnTime += Time.deltaTime;

        if (spawnTime >= timeInterval)
        {
            SpawnDanger();

            NewTimeInterval();
            spawnTime = 0f;
        }

        if (time >= 20)
        {
            difficulty += 0.1f;
            difficulty = Mathf.Clamp01(difficulty);

            time = 0;
        }
    }

    private void LateUpdate()
    {
        scoreTime += Time.deltaTime;

        if(time >= 0.5f)
        {
            score += GetScore();

            scoreTime = 0f;
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

    void NewTimeInterval()
    {
        float modifier = 2f - difficulty;
        timeInterval = Random.Range(1 * modifier, 3 * modifier);
    }

    void SpawnDanger()
    {
        Danger danger = Instantiate(danger1, dangers.transform.position + Vector3.right * Random.Range(-1, 2) * 4, Quaternion.identity, dangers);
        danger.speed = speed * (1 + difficulty);
    }
}
