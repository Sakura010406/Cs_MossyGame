using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform chara;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(chara.position.x, chara.position.y, -10f);
    }
}
