using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using Photon;

public class ChoosingNetworkGameScript : Photon.PunBehaviour
{
    public Canvas MainCanvas;
    public InputField RoomNameInput;
    public Button CreateRoomButton;
    public Dropdown DropdownMenu;

    private RoomInfo[] rooms = null;

    // Camera Movement
    public GameObject MainCamera;
    public Vector3 CameraPositionToMoveTo;
    public Vector3 CameraRotationToRotateTo;
    private float timer = 0;
    private float timeToLerp = 2;
    private Vector3 originalPos;
    private Quaternion originalQuat;
    private bool finishedLerp = false;

    void Start()
    {
        MainCanvas.enabled = false;
        DropdownMenu = DropdownMenu.GetComponent<Dropdown>();

        originalPos = MainCamera.transform.position;
        originalQuat = MainCamera.transform.rotation;

        // Connect Using Settings connects us to the Photon Network
        // "0.1" represents the version of the Game that we're using.
        // This prevents previous versions from connecting to more updated versions.
        PhotonNetwork.ConnectUsingSettings("0.01");
    }

    void Update()
    {
        if (!finishedLerp)
        {
            timer += Time.deltaTime;
            MainCamera.transform.position = Vector3.Lerp(originalPos, CameraPositionToMoveTo, timer / timeToLerp);
            Quaternion quat = Quaternion.identity;
            quat.eulerAngles = CameraRotationToRotateTo;
            MainCamera.transform.rotation = Quaternion.Lerp(originalQuat, quat, timer / timeToLerp);

            if (MainCamera.transform.position == CameraPositionToMoveTo)
            {
                finishedLerp = true;
                MainCanvas.enabled = true;
            }
        }
        else
        {
            if (DropdownMenu.options.Count <= 1)
                OnJoinedLobby();
        }
    }

    public override void OnJoinedLobby()
    {
        DropdownMenu.ClearOptions();

        List<string> options = new List<string>();
        options.Add("Select Room");

        foreach (RoomInfo game in PhotonNetwork.GetRoomList())
        {
            Debug.Log("Game");
            string roomName = game.name;
            options.Add(roomName);
        }

        DropdownMenu.AddOptions(options);
    }

    public void CreateRoom()
    {
        if (RoomNameInput.text.Length == 0)
            return;

        RoomOptions options = new RoomOptions();
        options.isOpen = true;
        options.isVisible = true;
        PhotonNetwork.CreateRoom(RoomNameInput.text, options, null);
    }

    public void ConnectToRoom()
    {
        int index = DropdownMenu.value;
        if (index == 0)
            return;

        index--;

        string name = PhotonNetwork.GetRoomList()[index].name;

        Debug.Log(name);
        PhotonNetwork.JoinRoom(name);
    }

    public override void OnJoinedRoom()
    {
        SceneManager.LoadScene("TestGameScene");
        GameObject.Destroy(GameObject.Find("MainMenuDollPrefab"));
    }
}
