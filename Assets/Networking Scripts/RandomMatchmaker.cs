using UnityEngine;
using Photon;
using System.Collections;

public class RandomMatchmaker : Photon.PunBehaviour
{
    // Use this for initialization
    void Start()
    {
        // Connect Using Settings connects us to the Photon Network
        // "0.1" represents the version of the Game that we're using.
        // This prevents previous versions from connecting to more updated versions.
        PhotonNetwork.ConnectUsingSettings("0.1");
    }
	
    // Update is called once per frame
    void Update()
    {
	
    }

    void OnGUI()
    {
        // This prints out the current step of the connection.
        // This is usually for debug purposes.
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
    }

    public override void OnJoinedLobby()
    {
        // This is called as soon as we connect to the Photon Network, and we're
        // immediately thrown into a lobby. Here we would usually instantiate the main menu.
        PhotonNetwork.JoinRandomRoom();
    }

    public void OnPhotonRandomJoinFailed()
    {
        // This is called if we fail to join a random room. In this case, it's because there 
        // is no room created.
        Debug.Log("Can't Join Random Room!");
        PhotonNetwork.CreateRoom(null);
    }

    public override void OnJoinedRoom()
    {
        // This is what happens when we join the room. Instantiating by PhotonNetwork causes
        // one to be created on every computer connected on Photon. Any components that have
        // input scripts should be disabled in the prefab and enabled here. Otherwise, when
        // created, all machines will have control. This way, only the creator has control.
        GameObject obj = PhotonNetwork.Instantiate("TestCapsule", new Vector3(0, 2, 0), Quaternion.identity, 0);
        obj.GetComponent<CapsuleControl>().enabled = true;
    }
}
