using UnityEngine;
using System.Collections;

public class TestGameScript : MonoBehaviour
{
    public GameObject PlayerPrefab;

    void Start()
    {
        if (GameObject.FindGameObjectWithTag("GameSettings").GetComponent<NetworkSettings>().IsNetworkGame == true)
        {
            GameObject obj = PhotonNetwork.Instantiate("PlayerPrefab", new Vector3(0, 2, 0), Quaternion.identity, 0);
            obj.GetComponent<TestCapsuleControl>().enabled = true;
        }
        else
        {
            GameObject obj = (GameObject)(Instantiate(PlayerPrefab, new Vector3(0, 2, 0), Quaternion.identity));
            obj.GetComponent<TestCapsuleControl>().enabled = true;
            obj.GetComponent<PhotonView>().enabled = false;
            obj.GetComponent<NetworkCharacter>().enabled = false;
        }
    }
	
    // Update is called once per frame
    void Update()
    {
	
    }
}
