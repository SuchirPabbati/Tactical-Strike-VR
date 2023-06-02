using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using TMPro;


public class connectToServer : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;
    public GameObject gunPrefab;
    public TextMeshProUGUI playerList;
    private GameObject player;
    private GameObject gun;
    public Transform[] spawnPoints;
    public GameObject XROrigin;

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void OnConnectedToMaster()
    {
        //PhotonNetwork.JoinLobby();
        //debug 
        Debug.Log("Connected to master");
        // set nickname
        PhotonNetwork.NickName = "Player " + Random.Range(0, 1000).ToString("0000");
        PhotonNetwork.JoinOrCreateRoom("room", new Photon.Realtime.RoomOptions { MaxPlayers = 4 }, TypedLobby.Default);





    }
    public override void OnJoinedLobby()
    {

        Debug.Log("Joined Lobby");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined room " + PhotonNetwork.CurrentRoom.Name);
        //debug    spawn points
        Debug.Log("Spawn points: " + PhotonNetwork.CurrentRoom.PlayerCount);
        Transform spawnPoint = spawnPoints[PhotonNetwork.CurrentRoom.PlayerCount - 1];
        XROrigin.transform.position = spawnPoint.position;
        XROrigin.transform.rotation = spawnPoint.rotation;
        player = PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint.position, spawnPoint.rotation);
        gun = PhotonNetwork.Instantiate(gunPrefab.name, player.transform.position + player.transform.forward * 2, Quaternion.identity);
    }

    public void SetPlayerList()
    {

        playerList.text = "Players: \n";
        foreach (Player player in PhotonNetwork.PlayerList)
        {
            playerList.text += player.NickName + ": " + player.GetScore() + "\n";
        }
    }



    void FixedUpdate()
    {
        if (PhotonNetwork.InRoom)
            SetPlayerList();
    }
    public override void OnLeftRoom()
    {
        PhotonNetwork.Destroy(player);
        PhotonNetwork.Destroy(gun);
    }
}
