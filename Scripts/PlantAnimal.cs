using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantAnimal : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform toppoint, bottompoint;
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
            rb.velocity = new Vector2(rb.velocity.x, - speed);
            if (transform.position.y < bottompoint.position.y)
            {
                facedirection = false;
            }
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, speed);
            if (transform.position.y > toppoint.position.y)
            {
                facedirection = true;
            }
        }

    }
}
