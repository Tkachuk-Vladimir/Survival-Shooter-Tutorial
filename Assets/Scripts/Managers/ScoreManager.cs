using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    Text text;

    void Start()
    {
        text = GetComponent<Text>();// getting access to the text ui
        score = 0; // assign 0
    }

    void Update()
    {
        text.text = "Score: " + score;
    }
}
