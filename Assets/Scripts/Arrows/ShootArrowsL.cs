using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootArrowsL : MonoBehaviour
{
    // Audio Source
    public AudioSource shootSound;

    public GameObject arrow;
    public bool canShoot = true;
    private bool startCountDown;

    public float timeToShoot;
    private float fCountDown;
    private int spawnCountDown;
    // Wear
        // Uses
    public int timesValue;
    public int timesCanBeUsed;
    private bool shooterEnabled;
        // Time to Recover
    private bool initTimeToRecup;
    private float delayTime = 2.5f;
    private int delayTimeInt;
    
    void Start()
    {
        timesCanBeUsed = timesValue;
        fCountDown = timeToShoot;
    }

    void Update()
    {
        if (startCountDown)
        {
            fCountDown -= Time.deltaTime;
        }else{
            fCountDown -= 0;
        }

        if (fCountDown <= 0)
        {
            startCountDown = false;
            canShoot = true;
            fCountDown = timeToShoot;
        }

        // Limit
        if (timesCanBeUsed <= 0)
        {
            shooterEnabled = false;
        }else{
            shooterEnabled = true;
        }

        // Wear | Recover Points
        delayTimeInt = (int)delayTime;
        if (timesCanBeUsed == timesValue)
        {
            initTimeToRecup = false;
        }else if (timesCanBeUsed < timesValue){
            initTimeToRecup = true;
            if (initTimeToRecup)
            {
                delayTime -= Time.deltaTime;
                if (delayTimeInt == 0)
                {
                    initTimeToRecup = false;
                    timesCanBeUsed += 1;
                    delayTime = 2.5f;
                }
            }
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.J) && canShoot && shooterEnabled)
        {
            SpawnArrow();
            canShoot = false;
            startCountDown = true;
        }
    }

    public void Action()
    {
        if (canShoot && shooterEnabled)
        {
            SpawnArrow();
            canShoot = false;
            startCountDown = true;
        }
    }

    void SpawnArrow()
    {
        shootSound.Play();
        Instantiate(arrow, new Vector2(-2.7f,-0.14f), Quaternion.identity);
        timesCanBeUsed -= 1;
    }
}
