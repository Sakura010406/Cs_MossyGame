using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;



public class NetworkLauncher : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject loginUI;
    [SerializeField]
    private GameObject nameUI;
    [SerializeField]
    private InputField roomName;
    [SerializeField]
    private InputField playerName;


    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        nameUI.SetActive(true);
        loginUI.SetActive(false);
    }

    public void PLayButton()
    {
        nameUI.SetActive(false);
        PhotonNetwork.NickName = playerName.text;
        loginUI.SetActive(true);
    }

    public void JoinOrCreateButton()
    {
        if(roomName.text.Length < 2)
        {
            return;
        }
        loginUI.SetActive(false);

        RoomOptions options = new RoomOptions { MaxPlayers = 2 };
        PhotonNetwork.JoinOrCreateRoom(roomName.text, options, default);
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel(1);
    }

}
