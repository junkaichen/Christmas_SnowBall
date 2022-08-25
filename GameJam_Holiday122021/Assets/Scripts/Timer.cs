using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{

    float timeValue = 120;
    float fillFraction;


    
    [SerializeField] Image timerImage;
    bool isOver = false;
    void Update()
    {
        // Time Infomation update and display
        if (!isOver)
        {
            timeValue -= Time.deltaTime;
            fillFraction = timeValue / 120f;
            timerImage.fillAmount = fillFraction;
            if (timerImage.fillAmount == 0)
            {
                isOver = true;

            }
        }


    }

    // check the time is run out or not
    public bool CheckTimer()
    {
        
        return isOver;
    }

}
