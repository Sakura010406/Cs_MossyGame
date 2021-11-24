using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject readyButton;


    public void ReadyPlay()
    {
        readyButton.SetActive(false);
        PhotonNetwork.Instantiate("Chara", new Vector3(-26, 3, 0), Quaternion.identity, 0);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
