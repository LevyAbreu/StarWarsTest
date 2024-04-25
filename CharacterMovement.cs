using System.Collections;
using System.Collections.Generic;
using KinematicCharacterController;
using UnityEngine;
 
public struct CharacterMovementInput
{
    public Vector2 MoveInput;
    public bool wantsToJump;
}

[RequireComponent(typeof(KinematicCharacterMotor))]
public class CharacterMovement : MonoBehaviour, ICharacterController
{
    public KinematicCharacterMotor Motor;
    public float moveSpeed = 5;
    public float jumpSpeed = 10;
    public float RotationSpeed = 15;
    public float Acceleration = 50;
    public float Gravity = 30;

    private Vector3 moveInput;
    private Vector3 moveDirection;
    private bool wantsToJump;

    public void Awake()
    {
        Motor.CharacterController = this;
    }

    public void SetInput(in CharacterMovementInput input)
    {
        moveInput = Vector3.zero;
        if (input.MoveInput != Vector2.zero){
            moveInput = new Vector3(input.MoveInput.x, 0, input.MoveInput.y).normalized;
        }

        if (Motor.GroundingStatus.IsStableOnGround){
            wantsToJump = input.wantsToJump;
        }
    }
    public void UpdateRotation(ref Quaternion currentRotation, float deltatime)
    {
        if (moveInput != Vector3.zero){
            var targetRotation = Quaternion.LookRotation(moveInput);
            currentRotation = Quaternion.Slerp(currentRotation, targetRotation, RotationSpeed * deltatime);
        }
    }
    public void UpdateVelocity(ref Vector3 currentVelocity, float deltatime)
    {
        if (Motor.GroundingStatus.IsStableOnGround){
            var targetVelocity = moveInput * moveSpeed;
            currentVelocity = Vector3.MoveTowards(currentVelocity, targetVelocity, Acceleration * deltatime);


            if (wantsToJump){
                currentVelocity.y = jumpSpeed;
                wantsToJump = false;
                Motor.ForceUnground();
            }
        } else {
            currentVelocity.y -= Gravity * deltatime;
        }
    }














    //region not implemented
    public void BeforeCharacterUpdate(float deltatime)
    {

    }
    public void PostGroundingUpdate(float deltatime)
    {

    }
    public void AfterCharacterUpdate(float deltatime)
    {

    }

    public bool IsColliderValidForCollisions(Collider coll)
    {
        return true;
    }
    public void OnGroundHit(Collider hitcollider, Vector3 hitnormal, Vector3 hitpoint, ref HitStabilityReport hitStabilityReport)
    {

    }
    public void OnMovementHit(Collider hitcollider, Vector3 hitnormal, Vector3 hitpoint,
    ref HitStabilityReport hitStabilityReport)
    {

    }
    public void ProcessHitStabilityReport(Collider hitcollider, Vector3 hitnormal, Vector3 hitpoint, Vector3 atCharacterPosition, 
    Quaternion atCharacterRotation, ref HitStabilityReport hitStabilityReport)
    {

    }
    public void OnDiscreteCollisionDetected(Collider hitcollider)
    {
        // Adicione aqui a lógica para lidar com a colisão discreta
        // Por exemplo, você pode realizar ações específicas quando uma colisão discreta for detectada
        Debug.Log("Discrete collision detected with collider: " + hitcollider.name);
    }
    //endRegion
}
