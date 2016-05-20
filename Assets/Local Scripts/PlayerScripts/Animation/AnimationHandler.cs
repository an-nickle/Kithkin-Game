using UnityEngine;
using System.Collections;
using System;

public class AnimationHandler : MonoBehaviour
{
    public Animator animator;

    private float timer = 0.0f;

    private System.Random rand = new System.Random();

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (((Input.GetAxis(Constants.HORIZONTAL) + Input.GetAxis(Constants.VERTICAL)) == Constants.ZERO))
        {
            animator.SetBool("isMoving", false);
        }
        else
        {
            animator.SetBool("isMoving", true);
            timer = 0.0f;
        }

        HandleIdleAnimations();
    }

    void HandleIdleAnimations()
    {
        if (!animator.GetBool("isMoving"))
        {
            timer += Time.deltaTime;
        }

        if(timer >= 30.0f)
        {
            int coinFlip = rand.Next(0, 2);

            if (coinFlip == 1)
            {
                animator.SetFloat("idleChangeTimer", -2.0f);
            }
            else
            {
                animator.SetFloat("idleChangeTimer", 2.0f);
            }

            timer = 0.0f;
                      
        }        
    }

    void ResetFromLookAround()
    {
        animator.SetFloat("idleChangeTimer", 0.0f);
    }

    void ResetFromYawn()
    {
        animator.SetFloat("idleChangeTimer", 0.0f);
    }
}
