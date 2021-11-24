using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().position.x + 9, GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().position.y + 3, -10f);
    }
}
