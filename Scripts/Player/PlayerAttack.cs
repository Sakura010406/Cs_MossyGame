using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float facedDirection;
    public GameObject bubble;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        facedDirection = GetComponent<CharaController>().facedDirection;
    }

    // Update is called once per frame
    void Update()
    {
        facedDirection = GetComponent<CharaController>().facedDirection;
        if (Input.GetKeyDown(KeyCode.J))
        {
            Launch();
        }
    }
    private void Launch()
    {
        
        GameObject _bubble = Instantiate(bubble, rb.position, Quaternion.identity);
        BubbleController bubbleController = _bubble.GetComponent<BubbleController>();
        bubbleController.Launch( 300);
    }
}
