using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleController : MonoBehaviour
{
    [SerializeField] public float attackDamage;
    private Rigidbody2D rigidbody2d;
    private Vector2 startPosition;
    private GameObject player;
    private Vector2 direction;
    private Vector2 distance;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rigidbody2d = GetComponent<Rigidbody2D>();
        startPosition = rigidbody2d.position;
        direction = new Vector2(player.transform.localScale.x, -0.01f);
    }

    // Update is called once per frame
    public void Launch(float force)
    {
        rigidbody2d.AddForce(direction * force);
    }
    private void Update()
    {
        distance.x = transform.position.x - startPosition.x;
        distance.y = transform.position.y - startPosition.y;
        if (distance.magnitude>10)
            Destroy(gameObject);
    }
}
