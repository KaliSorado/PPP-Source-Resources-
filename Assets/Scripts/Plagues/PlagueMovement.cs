using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlagueMovement : MonoBehaviour
{
    Rigidbody2D thisRB;
    public float speed;
    private int selectSpeed;
    public float speed1;
    public float speed2;
    public float speed3;
    
    void Start()
    {
        thisRB = GetComponent<Rigidbody2D>();
        selectSpeed = Random.Range(1,3);
    }

    void OnCollisionEnter2D(Collision2D hited)
    {
        if (hited.gameObject.tag == "Mallet" || hited.gameObject.tag == "Tree")
        {
            selectSpeed = 4;
        }

        if (hited.gameObject.tag == "Arrow")
        {
            selectSpeed = 4;
            thisRB.AddForce(Vector2.left * speed, ForceMode2D.Force);
        }
    }

    void Update()
    {
        if (selectSpeed == 1)
        {
            speed = speed1;
        }else if (selectSpeed == 2)
        {
            speed = speed2;
        }else if (selectSpeed == 3)
        {
            speed = speed3;
        }else{
            speed = 0;
        }

        thisRB.velocity = new Vector2(speed,0);
    }
}
