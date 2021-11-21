using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmileOrange : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform leftpoint, rightpoint;
    private bool facedirection = true;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.DetachChildren();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Move()
    {
        if (facedirection)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            if (transform.position.x < leftpoint.position.x)
            {
                facedirection = false;
            }
        }
        else
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            if (transform.position.x > rightpoint.position.x)
            {
                facedirection = true;
            }
        }

    }
}
