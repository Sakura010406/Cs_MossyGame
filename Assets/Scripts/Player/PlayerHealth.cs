using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("hurt")]
    protected SpriteRenderer sr;

    public float hurtTime;
    protected float hurtCounter;
    public int health;
    [HideInInspector]
    public bool isAttacked;
    // Start is called before the first frame update
    void Start()
    {
        HealthBar.healthMax = health;
        HealthBar.healthCurrent = health;
        sr = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        if (hurtCounter <= 0)
            sr.material.SetFloat("_FlashAmount", 0);
        else
            hurtCounter -= Time.deltaTime;
    }
    public void DamagePlayer(int damage)
    {

        isAttacked = true;
        StartCoroutine(IsAttackCo());
        health -= damage;
        Debug.Log(health);
        HealthBar.healthCurrent = health;
        HurtShader();
        if (health <= 0)
        {
            health = 0;
            Destroy(gameObject);
        }
    }
    protected void HurtShader()
    {
        Debug.Log("ÊÜÉË");
        sr.material.SetFloat("_FlashAmount", 0.8f);
        hurtCounter = hurtTime;
    }
    IEnumerator IsAttackCo()
    {
        yield return new WaitForSeconds(0.5f);
        isAttacked = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BottomAirWall")
            DamagePlayer(health);
    }
}
