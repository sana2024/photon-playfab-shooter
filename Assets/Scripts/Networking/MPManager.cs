using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class MPManager : MonoBehaviourPunCallbacks
{
    public GameObject[] EnabableObjectsOnConnect;
    public GameObject[] DissableObjectsOnConnect;
    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        foreach(GameObject obj in EnabableObjectsOnConnect)
        {
            
            obj.SetActive(true);
        }
        foreach (GameObject obj in DissableObjectsOnConnect)
        {

            obj.SetActive(false);
        }

        Debug.Log("We Are Now Connected To Photon");
    }

    public void JoinF4A()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.JoinRandomRoom();
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        CreateF4A();
    }
    public void CreateF4A()
    {
        RoomOptions ro = new RoomOptions { MaxPlayers = 10, IsOpen = true, IsVisible = true };
        PhotonNetwork.CreateRoom("defaultF4A", ro, TypedLobby.Default);
        PhotonNetwork.AutomaticallySyncScene = true;
  
    }

    public override void OnJoinedRoom()
    {
        SceneManager.LoadScene("FreeForAll");
    }
}
