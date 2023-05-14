using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    // Start is called before the first frame update
    public Text scoreText;
    public void Awake()
    {
        instance = this;
    }
    int score = 0;
    void Start()
    {
        scoreText.text = score.ToString() + " COINS";
    }

    // Update is called once per frame
    public void AddPoint()
    {
        score += 1;
        scoreText.text = score.ToString() + " COINS";
    }

    
}
