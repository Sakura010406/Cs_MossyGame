using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    protected AudioSource deathAudio;
    [SerializeField] public float maxHp;
    [Header("hurt")]
    protected SpriteRenderer sr;
    public float hp;

    protected float hurtTime;
    protected float hurtCounter;
    [HideInInspector]
    public bool isAttacked;
    private PlayerHealth playerHealth;
    public int damage;
    [HideInInspector]
    public bool isDead;
    // Start is called before the first frame update
    protected void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        hp = maxHp;
        sr = GetComponent<SpriteRenderer>();
        deathAudio = GetComponent<AudioSource>();
        if (isDead == true)
            gameObject.SetActive(false);
        else
            gameObject.SetActive(true);
    }
    public void Death(){
        deathAudio.Play();
    }
    // Update is called once per frame
    protected void Update()
    {
        if (hurtCounter <= 0)
            sr.material.SetFloat("_FlashAmount", 0);
        else
            hurtCounter -= Time.deltaTime;
    }
    public void TakenDamage(float amount)
    {
        isAttacked = true;
        StartCoroutine(IsAttackCo());
        hp -= amount;
        HurtShader();
        if (hp <= 0)
        {
            isDead = true;
            gameObject.SetActive(false);
        }
    }
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Attack")
        {
            if (!isAttacked)
            {
                Debug.Log("π•ª˜");
                TakenDamage(collision.gameObject.GetComponent<BubbleController>().attackDamage);
                Vector2 difference = transform.position - collision.transform.position;
                transform.position = new Vector2(transform.position.x + difference.x / 2
                    , transform.position.y);
            }
            Destroy(collision.gameObject);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("≈ˆ◊≤");
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log(" ‹…À");
            collision.gameObject.GetComponent<PlayerHealth>().DamagePlayer(damage);
        }
    }
    protected void HurtShader()
    {
        sr.material.SetFloat("_FlashAmount", 0.8f);
        hurtCounter = hurtTime;
    }
    IEnumerator IsAttackCo()
    {
        yield return new WaitForSeconds(0.5f);
        isAttacked = false;
    }

    public void Reload(bool isDead)
    {
        if (isDead)
            gameObject.SetActive(false);
        else
            gameObject.SetActive(true);
    }
}
