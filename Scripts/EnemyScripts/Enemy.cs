using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    protected AudioSource deathAudio;
    // Start is called before the first frame update
    void Start()
    {
        deathAudio = GetComponent<AudioSource>();
        
    }
    public void Death(){
        deathAudio.Play();
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
