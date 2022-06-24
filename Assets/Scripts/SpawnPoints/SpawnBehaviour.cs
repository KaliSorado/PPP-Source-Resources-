using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBehaviour : MonoBehaviour
{
    public GameObject plague1;
    private bool canSpawn = true;

    public float timeToSpawn;
    private float fCountDownP1;
    private int spawnP1CountDown;
    
    void Start()
    {
        fCountDownP1 = timeToSpawn;
    }

    void Update()
    {
        fCountDownP1 -= Time.deltaTime;
        spawnP1CountDown = (int)fCountDownP1;

        if (spawnP1CountDown == 0 && canSpawn)
        {
            SpawnPlague1();
            canSpawn = false;
        }else{
            canSpawn = true;
        }
    }

    void SpawnPlague1()
    {
        fCountDownP1 = timeToSpawn;
        Instantiate(plague1, transform.localPosition, Quaternion.identity);
    }

}
