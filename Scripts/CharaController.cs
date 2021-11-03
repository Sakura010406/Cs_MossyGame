using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharaController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField]
    private Collider2D coll;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpforce;
    [SerializeField]
    private bool jump = false;
    [SerializeField]
    private bool fall = false;
    [SerializeField]
    private  int plant;
    [SerializeField]
    private LayerMask ground;
    [SerializeField]
    private int total;
    [SerializeField]
    private Text plantNum;
    [SerializeField]
    private bool isHurt = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        total = 1;
    }

    void FixedUpdate()
    {
        if (!isHurt)
        {
            MoveMent();
        }
        if(Mathf.Abs(rb.velocity.x) < 0.1)
        {
            isHurt = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
        if (rb.velocity.y<0)
        {
            fall = true;
        }
    }
  
    void MoveMent()
    {
        anim.SetBool("walking", false);
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        float horizontalMove = Input.GetAxis("Horizontal");
        float facedDirection = Input.GetAxisRaw("Horizontal");

        if (!Input.anyKey)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

            if (horizontalMove != 0) {
            rb.velocity = new Vector2(horizontalMove * speed * Time.deltaTime, rb.velocity.y);
            anim.SetBool("walking", true);
            anim.SetFloat("dash3", Mathf.Abs(horizontalMove));
        }

        if (facedDirection != 0)
        {
            transform.localScale = new Vector3(facedDirection, 1, 1);
        }
        if (jump && total>0){
            rb.velocity = new Vector2(rb.velocity.x, jumpforce * Time.deltaTime);
            jump = false;
            total--;
        }
        if (coll.IsTouchingLayers(ground))
        {
            total = 1;
            jump = false;
            fall = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Plants")
        {
            Destroy(collision.gameObject);
            plant++;
            plantNum.text = plant.ToString();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (fall)
            {
            Destroy(collision.gameObject);
            rb.velocity = new Vector2(rb.velocity.x, jumpforce * Time.deltaTime);
             jump = true ;
             }else if (transform.position.x < collision.gameObject.transform.position.x)
             {
                rb.velocity = new Vector2(-1, rb.velocity.y);
                isHurt = true;
            }
            else
            {
                rb.velocity = new Vector2(1, rb.velocity.y);
                isHurt = true;
            }
        }
     }
}
