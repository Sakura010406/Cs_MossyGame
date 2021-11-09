using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Poison :Enemy
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float waitTime;
    [SerializeField]
    private Transform[] movePos;

    private int i;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        i = 1;
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        transform.position = Vector2.MoveTowards(transform.position, movePos[i].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, movePos[i].position) < 0.1f)
        {
            if (waitTime < 0.0f)
            {
                if (i == 0)
                {
                    i = 1;
                }
                else
                {
                    i = 0;
                }
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}
