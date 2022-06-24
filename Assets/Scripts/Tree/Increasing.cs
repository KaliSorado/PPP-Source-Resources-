using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Increasing : MonoBehaviour
{
    // Audio Sources
    private int selectedSound;
    private AudioSource hitSoundS;
    public AudioSource hitSound1;
    public AudioSource hitSound2;
    private int selectedHitSound;
    private AudioSource hitFSoundS;
    public AudioSource hitFSound1;
    public AudioSource hitFSound2;

    public GameObject thisTree;
    UIGOManager uIGOManager;

    private bool initTimer;
    private float currentTime = 0.75f;
    private float spVisibility = 1;

    public ParticleSystem destroyedParticles;
    public SpawnBehaviour2 spawnBehaviour2L;
    public SpawnBehaviour2 spawnBehaviour2R;

    Animator animator;
    ParticleSystem lessPoint;
    BoxCollider2D hitBox;
    SpriteRenderer spriteRenderer;

    public float increaseSpeed;
    public int healthPoints;
    public int timeElapsed;
    private float timeElapsedFloat;
    
    void Start()
    {
        uIGOManager = FindObjectOfType<UIGOManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        hitBox = GetComponent<BoxCollider2D>();
        lessPoint = GetComponent<ParticleSystem>();
        animator = GetComponent<Animator>();
        increaseSpeed = 0.015f;
    }

    void OnCollisionEnter2D(Collision2D hitedBy)
    {
        if (hitedBy.gameObject.tag == "Plague")
        {
            hitSoundS.Play();
            healthPoints -= 1;
            lessPoint.Clear();
            lessPoint.Play();
        }

        if (timeElapsed >= 45 && hitedBy.gameObject.tag == "Plague")
        {
            hitFSoundS.Play();
            destroyedParticles.Play();
        }
    }

    void Update()
    {
        selectedSound = Random.Range(1,3);
        // Select Sound
        switch (selectedSound) {
            case 1: hitSoundS = hitSound1;
                break;
            case 2: hitSoundS = hitSound2;
                break;
            default: hitSoundS = hitSound2;
                break;
        }
        selectedHitSound = Random.Range(1,3);
        switch (selectedHitSound) {
            case 1: hitFSoundS = hitFSound1;
                break;
            case 2: hitFSoundS = hitFSound2;
                break;
            default: hitFSoundS = hitFSound2;
                break;
        }

        animator.SetFloat("incH", increaseSpeed);

        timeElapsedFloat += Time.deltaTime;
        timeElapsed = (int)timeElapsedFloat;

        if (timeElapsed == 20)
        {
            increaseSpeed = 0.01f;
        }else if (timeElapsed == 30)
        {
            increaseSpeed = 0.005f;
        }else if (timeElapsed == 45)
        {
            increaseSpeed = 0.0025f;
        }

        if (timeElapsed == 68)
        {
            spawnBehaviour2L.altureReached = true;
            spawnBehaviour2R.altureReached = true;
        }

        //Disapear Tree
        spriteRenderer.color = new Color(1,1,1,spVisibility);
        if (initTimer)
        {
            currentTime -= Time.deltaTime;
            spVisibility -= 0.01f;
            if (currentTime <= 0)
            {
                uIGOManager.GameOver();
                Destroy(thisTree);
            }
        }

        if (healthPoints <= 0)
        {
            hitBox.enabled = false;
            initTimer = true;
        }
    }
}
