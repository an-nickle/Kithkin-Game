using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * Time.deltaTime * Constants.PLAYER_MOVE_SPEED);

        if (((Input.GetAxis("Horizontal") + Input.GetAxis("Vertical")) == 0.0f))
        {
            animator.SetBool("isMoving", false);
        }
        else
        {
            animator.SetBool("isMoving", true);
        }
    }
}
