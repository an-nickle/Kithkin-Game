using UnityEngine;
using System.Collections;

public class CapsuleControl : MonoBehaviour
{
	public const float Speed = 2.5f;

	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.Translate (new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical")) * Time.deltaTime * Speed);
	}
}
