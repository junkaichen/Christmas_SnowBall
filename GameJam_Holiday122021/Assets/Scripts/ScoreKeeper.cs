using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    // SnowBall1 snowBall1;
    private int Player1_currentScore = 0;
    private int Player2_currentScore = 0;
    private int player1_Hit = 0;
    private int player2_Hit = 0;
    private int player1_Miss = 0;
    private int player2_Miss = 0;

    PlayerMovement playerMovement;
    PlayerMovement2 playerMovement2;
    private void Start()
    {
        // snowBall1 = FindObjectOfType<SnowBall1>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        playerMovement2 = FindObjectOfType<PlayerMovement2>();
    }

    public int getPlayer1MaxR()
    {
        return playerMovement.getMaxSnowballSize();
    }

    public int getPlayer2MaxR()
    {
        return playerMovement2.getMaxSnowballSize();
    }

    public void increasePlayer1Score(int value)
    {
        Player1_currentScore += value;
    }

    public int getPlayer1Score()
    {
        return Player1_currentScore;
    }


    public void increasePlayer2Score(int value)
    {
        Player2_currentScore += value;
    }

    public int getPlayer2Score()
    {
        return Player2_currentScore;
    }

    public void increasePlayer1Hit()
    {
        player1_Hit++;
    }



    public void increasePlayer1Miss()
    {
        player1_Miss++;
    }

    public void increasePlayer2Miss()
    {
        player2_Miss++;
    }
    public void increasePlayer2Hit()
    {
        player2_Hit++;
    }
    public int getPlayer1Hit()
    {
        return player1_Hit;
    }

    public int getPlayer1Miss()
    {
        return player1_Miss;
    }

    public int getPlayer2Miss()
    {
        return player2_Miss;
    }
    public int getPlayer2Hit()
    {
        return player2_Hit;
    }
    public int WinnerCheck()
    {
        if (Player1_currentScore > Player2_currentScore)
        {
            return 1;
        }
        else if (Player2_currentScore > Player1_currentScore)
        {
            return 2;
        }
        else
        {
            return 0;
        }
    }
}
