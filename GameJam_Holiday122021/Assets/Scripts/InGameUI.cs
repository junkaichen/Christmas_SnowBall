using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InGameUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI scoreText2;
    ScoreKeeper scoreKeeper;
    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    // Updating Player's score
    void Update()
    {
        scoreText.text = scoreKeeper.getPlayer1Score().ToString() + " pt";
        scoreText2.text = scoreKeeper.getPlayer2Score().ToString() + " pt";
        
    }
}
