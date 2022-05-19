using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject smallEnemy;
    public GameObject bigEnemy;
    public float delayTime;
    public float currentTime;

    void Update()
    {
        float random2 = Random.Range(1, 10);
        currentTime += Time.deltaTime;
        float random = Random.Range(-8, 8);
        if (currentTime > delayTime)
        {
            if (random2 > 5)
            {
                currentTime = 0;
                Instantiate(bigEnemy).transform.position = new Vector2(random, 6);
            }
            else
            {
                currentTime = 0;
                Instantiate(smallEnemy).transform.position = new Vector2(random, 6);
            }
        }
    }
}
