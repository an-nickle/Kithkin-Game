using UnityEngine;
using System.Collections;

public class TestCapsuleControl : MonoBehaviour
{
    public const float Speed = 2.5f;
    public const float CameraHeight = 10f;
    private GameObject camera;

    void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        camera.transform.parent = gameObject.transform;
    }

    void Update()
    {
        transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * Time.deltaTime * Speed);
        camera.transform.position = new Vector3(transform.position.x, transform.position.y + CameraHeight, transform.position.z);
    }
}
