using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeploySnowBall : MonoBehaviour
{
    [SerializeField] GameObject snowBall1Prefab;
    [SerializeField] GameObject snowBall2Prefab;
    [SerializeField] float regenerateTime = 0.5f;
    bool haveSnowball1 = true;
    bool haveSnowball2 = true;

    void Start()
    {
        StartCoroutine(snowBall1Wave());
        StartCoroutine(snowBall2Wave());
    }

    void regenerateSnowBall1()
    {
        if (!haveSnowball1)
        {
            GameObject a = Instantiate(snowBall1Prefab) as GameObject;
            haveSnowball1 = true;
        }

    }


    void regenerateSnowBall2()
    {
        if (!haveSnowball2)
        {
            GameObject b = Instantiate(snowBall2Prefab) as GameObject;
            haveSnowball2 = true;
        }

    }

    IEnumerator snowBall1Wave()
    {
        while (true)
        {

            yield return new WaitForSeconds(regenerateTime);
            regenerateSnowBall1();

        }
    }

    IEnumerator snowBall2Wave()
    {
        while (true)
        {

            yield return new WaitForSeconds(regenerateTime);
            regenerateSnowBall2();

        }
    }

    public void throwOut()
    {
        haveSnowball1 = false;
    }

    public void throwOut2()
    {
        haveSnowball2 = false;
    }
}
