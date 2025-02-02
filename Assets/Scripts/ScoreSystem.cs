﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public Text scoreText;
    public float scoreAmount;
    public float pointIncreasedPerSec;
    // Start is called before the first frame update
    void Start()
    {
        scoreAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = " Score " + (int)scoreAmount;
        scoreAmount += pointIncreasedPerSec * Time.deltaTime;
    }
}
