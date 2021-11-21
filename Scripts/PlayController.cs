using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public Collider2D coll;
    public LayerMask ground;
    public float jumpforce;
    private Animator anim;
    public int BlueAnimal;
    public Text BlueNum;
    private bool Ishurt;
    public Rigidbody2D[] arrow;
    
    
  
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        transform.DetachChildren();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Ishurt)
        {
            Move();
        }
        SwithAnim();
    }

    private void Move()
    {
        float Horizontalmove = Input.GetAxis("Horizontal");
        float facedirection=Input.GetAxisRaw("Horizontal");
        
        //½ÇÉ«ÒÆ¶¯
        if (Horizontalmove != 0)
        {
            rb.velocity = new Vector2(Horizontalmove * speed, rb.velocity.y);
            anim.SetFloat("running", Mathf.Abs(Horizontalmove));
  
        }

        if (facedirection != 0)
        {
            transform.localScale = new Vector3(facedirection * 1f, 1f, 1);
        }

        //½ÇÉ«ÌøÔ¾
        if (Input.GetButtonDown("Jump"))
        {
            //&&coll.IsTouchingLayers(ground)
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
            anim.SetBool("jumping", true);
        }

    }

    void SwithAnim()
    {
        anim.SetBool("idling", false);
        if (anim.GetBool("jumping"))
        {
            if (rb.velocity.y < 0)
            {
                anim.SetBool("jumping", false);
                anim.SetBool("falling", true);
            }
        }else if (Ishurt)
        {
            if (Mathf.Abs(rb.velocity.x) < 0.1f)
            {
                Ishurt = false;
            }

        }else if (coll.IsTouchingLayers(ground))
        {
            anim.SetBool("falling", false);
            anim.SetBool("idling", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Collection")
        {
            Destroy(collision.gameObject);
            BlueAnimal+=1;
            BlueNum.text =":  "+ BlueAnimal.ToString();
        }
        if (collision.tag == "Trap")
        {
            for (int i = 0; i < arrow.Length; i++)
            {
                arrow[i].velocity = new Vector2(arrow[i].velocity.x, -speed);
            }

        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
            if (collision.gameObject.tag == "Monster")
            {
            if (anim.GetBool("falling")) { 
                Destroy(collision.gameObject);
                rb.velocity = new Vector2(rb.velocity.x, jumpforce);
                anim.SetBool("jumping", true);
            }else if (transform.position.x < collision.gameObject.transform.position.x)
            {
                rb.velocity = new Vector2(-10, rb.velocity.y);
                Ishurt = true;
            }else if(transform.position.x > collision.gameObject.transform.position.x)
            {
                rb.velocity = new Vector2(10, rb.velocity.y);
                Ishurt = true;
            }
        }
        
    }

}
