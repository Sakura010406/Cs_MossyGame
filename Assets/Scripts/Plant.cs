using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public bool isCollected;
    public void Reload(bool isCollected)
    {
        if (isCollected)
            gameObject.SetActive(false);
        else
            gameObject.SetActive(true);
    }
}
