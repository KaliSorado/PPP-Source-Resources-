using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehaviour : MonoBehaviour
{
    Rigidbody2D thisRB;
    public GameObject thisArrow;
    public float speedX;
    public float speedY;

    void OnCollisionEnter2D(Collision2D hitedBy)
    {
        if (hitedBy.gameObject.tag == "Plague")
        {
            Destroy(thisArrow);
        }
    }

    void Start()
    {
        thisRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        thisRB.velocity = new Vector2(speedX, speedY);

        if (transform.localPosition.y > 9)
        {
            Destroy(thisArrow);
        }
    }
}
