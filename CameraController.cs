using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]

public class CameraController : MonoBehaviour
{
    public CharacterMovement characterMovement;
    public Transform cameraTarget;
    public float TargetHeight = 2;


    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        cameraTarget.transform.position = characterMovement.transform.position + Vector3.up * TargetHeight;
    }
}
