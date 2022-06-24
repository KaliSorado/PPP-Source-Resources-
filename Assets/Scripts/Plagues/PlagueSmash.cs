using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlagueSmash : MonoBehaviour
{
    private bool initTimer;
    private float currentTime = 2;
    private float spVisibility = 1;

    public GameObject thisPlague;
    public ParticleSystem splashEffect;

    Score scoreSystem;
    SpriteRenderer spriteRenderer;
    BoxCollider2D hitBox;
    ParticleSystem tenPoints;
    Animator animManager;
    // Random Splash Sound System 
    private int selectedSound;
    public AudioSource currentSS;
    public AudioSource splashSound1;
    public AudioSource splashSound2;
    public AudioSource splashSound3;

    void Start()
    {
        selectedSound = Random.Range(1,4);
        scoreSystem = FindObjectOfType<Score>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        hitBox = GetComponent<BoxCollider2D>();
        tenPoints = GetComponent<ParticleSystem>();
        animManager = GetComponent<Animator>();
    }

    void Update()
    {
       switch (selectedSound) {
            case 1:
                currentSS = splashSound1;
                break;
            case 2:
                currentSS = splashSound2;
                break;
            case 3:
                currentSS = splashSound3;
                break;
            default: currentSS = splashSound3;
                break;
       }
    }

    void OnCollisionEnter2D(Collision2D hited)
    {
        if (hited.gameObject.tag == "Mallet")
        {
            currentSS.Play();
            tenPoints.Play();
            splashEffect.Play();
            animManager.SetBool("pushed", true);
            hitBox.enabled = false;
            initTimer = true;
            scoreSystem.score += 10;
        }

        if (hited.gameObject.tag == "Arrow")
        {
            currentSS.Play();
            tenPoints.Play();
            splashEffect.Play();
            animManager.SetBool("pushed", true);
            hitBox.enabled = false;
            initTimer = true;
            scoreSystem.score += 10;
        }
        
        if (hited.gameObject.tag == "Tree")
        {
            currentSS.Play();
            splashEffect.Play();
            spriteRenderer.enabled = false;
            hitBox.enabled = false;
            initTimer = true;
        }
    }

    void FixedUpdate()
    {
        spriteRenderer.color = new Color(1,1,1,spVisibility);
        if (initTimer)
        {
            currentTime -= Time.deltaTime;
            spVisibility -= 0.01f;
            if (currentTime <= 0)
            {
                Destroy(thisPlague);
            }
        }
    }

}
