using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{


    SettlementUI settlementUI;
    Timer timer;
    PlayerMovement player1;
    PlayerMovement2 player2;
    EnableDisable tick;

    private bool done = false;


    void Awake()
    {
        settlementUI = FindObjectOfType<SettlementUI>();
        timer = FindObjectOfType<Timer>();
        tick = FindObjectOfType<EnableDisable>();
        settlementUI.gameObject.SetActive(false);

    }


    void Update()
    {
        // if the game is over

        if (timer.CheckTimer() && !done)
        {
            settlementUI.gameObject.SetActive(true);
            settlementUI.ShowFinalReport();
            tick.gameObject.SetActive(false);
            done = true;
        }



    }

    // Replay the game
    public void OnReplay()
    {
        SceneManager.LoadScene(1);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

}
