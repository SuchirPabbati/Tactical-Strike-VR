using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    public InputField createInput;
    public InputField joinInput;
    public InputField nickName;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createInput.text);
        //debug create
        Debug.Log("Created Room");
    }
    public void JoinRoom()
    {
        //debug join room
        Debug.Log("Joining Room");
        PhotonNetwork.JoinRoom(joinInput.text);

    }
    public override void OnJoinedRoom()
    {
        //load game scene
        PhotonNetwork.LoadLevel("Game");

        Debug.Log("Joined Room");
        //set nickname if not empty else set to default
        if (nickName.text != "")
        {
            PhotonNetwork.NickName = nickName.text;
        }
        else
        {
            PhotonNetwork.NickName = "Player " + Random.Range(0, 1000);
        }
        Debug.Log("Joined Room " + PhotonNetwork.NickName);
    }
}
