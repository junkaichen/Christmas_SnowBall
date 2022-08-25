using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployPresent : MonoBehaviour
{

    [SerializeField] GameObject presentPrefab;
    [SerializeField] GameObject present2Prefab;
    [SerializeField] float regenerateTime = 1.2f;
    System.Random random;


    
    void Start()
    {
        StartCoroutine(presentWave());
        StartCoroutine(present2Wave());
    }


    IEnumerator presentWave()
    {
        while (true)
        {
            // How long the system create a present1
            yield return new WaitForSeconds(regenerateTime);
            regeneratePresents();
        }
    }


    IEnumerator present2Wave()
    {
        while (true)
        {
            // How long the system create a present2
            yield return new WaitForSeconds(regenerateTime);
            regeneratePresents2();
        }
    }



    void regeneratePresents()
    {
        GameObject a = Instantiate(presentPrefab) as GameObject;
        a.transform.position = new Vector2(Random.Range(-8.7f, 0f), 5f);  // Set up where present1 goes
    }


    void regeneratePresents2()
    {
        GameObject a = Instantiate(present2Prefab) as GameObject;

        // implement random for two types of presents
        random = new System.Random(100000);
        a.transform.position = new Vector2(Random.Range(0f, 8.7f), 5f); // Set up where present2 goes
    }

}
