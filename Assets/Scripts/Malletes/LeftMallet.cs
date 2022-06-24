using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMallet : MonoBehaviour
{
    // Audio Sources
    private int selectedSound;
    private AudioSource smashSoundS;
    public AudioSource smashSound1;
    public AudioSource smashSound2;
    public AudioSource smashSound3;
    // Objects & Components
    public GameObject message;
    public GameObject pushMessage;
    Rigidbody2D currentRB;
    SpriteRenderer spriteRenderer;
    private Color enabledColor = new Color(1,1,1);
    public Color disabledColor;
    // Parameters
    public float speed;
    private bool startDown;
    private bool startUp;
    private bool canPush = true;
    // Use
    public bool malletEnabled = true;
    public int timesValue;
    public int timesCanBeUsed;
    private float pushingTimeF = 2f;
    private int pushingTime;
    public int intTimeLeft;
    private bool startTimer;
    // Timer to Recover
    private bool canRecover;
    public float timeTSLeftValue = 2;
    private float timeTSRest;
    private int timeTSLeft;
    
    void Start()
    {
        timeTSRest = timeTSLeftValue;
        timesCanBeUsed = timesValue;
        currentRB = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D hitSome)
    {
        if (hitSome.gameObject.tag == "Ground")
        {
            smashSoundS.Play();
            startDown = false;
            startUp = true;
        }

        if (hitSome.gameObject.tag == "Margin")
        {
            startUp = false;
            canPush = true;
        }

    }

    void Update()
    {
        // Select Sound
        selectedSound = Random.Range(1,5);
        // Select Sound
        selectedSound = Random.Range(1,4);
        switch (selectedSound)
        {
            case 1: smashSoundS = smashSound1;
                break;
            case 2: smashSoundS = smashSound2;
                break;
            case 3: smashSoundS = smashSound3;
                break;
        }

        pushingTime = (int)pushingTimeF;
        timeTSLeft = (int)timeTSRest;

        if (startDown)
        {
            currentRB.velocity = new Vector2(0, -speed);
        }else if(startUp){
            currentRB.velocity = new Vector2(0, speed);
        }else{
            currentRB.velocity = new Vector2(0, 0);
        }

        if (timesCanBeUsed == 0)
        {
            malletEnabled = false;
            startTimer = true;
            spriteRenderer.color = disabledColor;
        }

        if (startTimer)
        {
            message.SetActive(true);
            pushMessage.SetActive(true);
            pushingTimeF -= Time.deltaTime;
            if (pushingTime == 0)
            {
                timesCanBeUsed += 2;
                pushingTimeF = 2f;
            }
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) && startTimer)
            {
                timesCanBeUsed += 1;
            }
            if (timesCanBeUsed == 50)
            {
                spriteRenderer.color = enabledColor;
                message.SetActive(false);
                pushMessage.SetActive(false);
                malletEnabled = true;
                startTimer = false;
            }
        }

        // Recover
        if (timesCanBeUsed >= timesValue)
        {
            canRecover = false;
        }else if (timesCanBeUsed < timesValue)
        {
            canRecover = true;
        }

        if (canRecover)
        {
            timeTSRest -= Time.deltaTime;
            if (timeTSLeft == 0)
            {
                timesCanBeUsed += 1;
                timeTSRest = timeTSLeftValue;
            }
        }

        // Not Pass Limit
        if (timesCanBeUsed > 50)
        {
            timesCanBeUsed = 50;
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A) && canPush && malletEnabled || Input.GetKey(KeyCode.LeftArrow) && canPush && malletEnabled)
        {
            timesCanBeUsed -= 1;
            startDown = true;
            canPush = false;
        }
    }

    public void Action()
    {
        if (canPush && malletEnabled)
        {
            timesCanBeUsed -= 1;
            startDown = true;
            canPush = false;
        }
        if (startTimer)
        {
            timesCanBeUsed += 1;
        }
    }

}
