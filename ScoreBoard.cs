using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{

    [SerializeField] Text scoreText;
    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText.text = score.ToString();
    }


    public void AddScore(int points)
    {
        score += points;
        scoreText.text = score.ToString();

    }


}
