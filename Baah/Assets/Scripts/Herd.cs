using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Herd : MonoBehaviour {

    GameManager gameManager;

    public int sheepCount = 5;
    public float herdSpread = 1.5f;

    public Sheep sheepPrefab;
    public Sheep[] herd;

	// Use this for initialization
	void Start () {
        SpawnSheep(sheepCount);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RemoveSheep()
    {
        sheepCount -= 1;

        gameManager.SetSheepCount(sheepCount);
    }

    public int GetSheepCount()
    {
        return sheepCount;
    }

    public void SetGameManager(GameManager manager)
    {
        gameManager = manager;
    }

    public void SpawnSheep(int count)
    {
        herd = new Sheep[sheepCount];

        float delta = 360f / (float)count;
        for (int i = 0; i < sheepCount; i++)
        {
            float angle = delta * i;

            Vector3 spawnPosition = new Vector3(Mathf.Cos(Mathf.Deg2Rad * angle), 0, Mathf.Sin(Mathf.Deg2Rad * angle)) * herdSpread;

            Sheep sheep = Instantiate(sheepPrefab, spawnPosition, Quaternion.identity, transform.parent);
            sheep.SetHerd(this);
            herd[i] = sheep;
        }
    }
}
