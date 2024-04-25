using System.Collections;
using System.Collections.Generic;
using KinematicCharacterController;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterMovement characterMovement;
    public void Update(){
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        var wantsToJump = Input.GetKeyDown(KeyCode.Space);

        characterMovement.SetInput(new CharacterMovementInput(){
            MoveInput = new Vector2(h, v),
            wantsToJump = wantsToJump
        });
    }
}
