using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Settlement UI
public class SettlementUI : MonoBehaviour
{


    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI scoreText2;
    [SerializeField] TextMeshProUGUI Player1Hit;
    [SerializeField] TextMeshProUGUI Player2Hit;
    [SerializeField] TextMeshProUGUI Player1Miss;
    [SerializeField] TextMeshProUGUI Player2Miss;
    [SerializeField] TextMeshProUGUI Player1R;
    [SerializeField] TextMeshProUGUI Player2R;
    ScoreKeeper scoreKeeper;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();

    }

    public void ShowFinalReport()
    {
        scoreText.text = scoreKeeper.getPlayer1Score().ToString();
        scoreText2.text = scoreKeeper.getPlayer2Score().ToString();
        Player1Hit.text = scoreKeeper.getPlayer1Hit().ToString();
        Player2Hit.text = scoreKeeper.getPlayer2Hit().ToString();
        Player1Miss.text = scoreKeeper.getPlayer1Miss().ToString();
        Player2Miss.text = scoreKeeper.getPlayer2Miss().ToString();
        Player1R.text = scoreKeeper.getPlayer1MaxR().ToString();
        Player2R.text = scoreKeeper.getPlayer2MaxR().ToString();

    }



}
