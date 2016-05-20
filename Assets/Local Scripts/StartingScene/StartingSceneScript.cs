using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartingSceneScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
	
    }
	
    // Update is called once per frame
    void Update()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
