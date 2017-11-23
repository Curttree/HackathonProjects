﻿using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {
    public int score=0;
    private GameObject scoreText;
	// Use this for initialization
	void Start () {
        scoreText = GameObject.FindGameObjectWithTag("ScoreText");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateScore(int change)
    {
        score += change;
        scoreText.GetComponent<Text>().text = "Score: " + score;
    }
}
