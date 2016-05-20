using UnityEngine;
using System.Collections;

public class NetworkSettings : MonoBehaviour
{
    private static bool spawned = false;

    void Awake()
    {
        if (!spawned)
        {
            spawned = true;
            DontDestroyOnLoad(gameObject);
        }
        else
            DestroyImmediate(gameObject); 
    }

    private bool isNetworkGame = false;

    public bool IsNetworkGame
    {
        get { return isNetworkGame; }
        set { isNetworkGame = value; }
    }

    void Start()
    {
	
    }

    void Update()
    {
	
    }
}
