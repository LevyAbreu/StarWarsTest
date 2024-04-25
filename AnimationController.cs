using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;

    void Start(){
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Forward", Input.GetKey(KeyCode.W));
        animator.SetBool("Backward", Input.GetKey(KeyCode.S));
        animator.SetBool("Left", Input.GetKey(KeyCode.A));
        animator.SetBool("Right", Input.GetKey(KeyCode.D));
        animator.SetBool("Jump", Input.GetKey(KeyCode.Space));
    }
}
