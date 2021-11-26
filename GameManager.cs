using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText.text = "Count:" + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Takes the score and updates it with the argument variable "scoreToBeAdded".
    public void UpdateScore(int scoreToBeAdded)
    {
        score = score + scoreToBeAdded;
        scoreText.text = "Count : " + score;
    }
}
