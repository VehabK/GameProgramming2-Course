using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

   public Vector3 GravityDirection;
   public Vector3 PlayerVelocity;
   public bool IsGrounded;
   public float MouseSensitivity = 5.0f;
   private float JumpHeight = 1f;
   private float GravityValue = -9.81f;
   private CharacterController Controller;
   private float WalkSpeed = 5;
   private float RunSpeed = 8;
    
 
private void Start()
{
    Controller = GetComponent<CharacterController>();
}

public void Update()
{
   UpdateRotation();
   ProcessMovement();
}
void UpdateRotation()
{
    transform.Rotate(0, Input.GetAxis("Mouse X")* MouseSensitivity, 0, Space.Self);

}

void ProcessMovement()
{ 
    float Speed = GetMovementSpeed();

    Vector3 MoveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    IsGrounded = Controller.isGrounded;
    if (IsGrounded)
    {
        if (Input.GetButtonDown("Jump") )
        {
            GravityDirection.y += Mathf.Sqrt(JumpHeight * -3.0f * GravityValue);
        }
        else 
        {
            GravityDirection.y = -1.0f;
        }
    }
    else 
    {
        GravityDirection.y += GravityValue * Time.deltaTime;
    }  
    Vector3 Movement = MoveDirection.z * transform.forward  + MoveDirection.x * transform.right;
    PlayerVelocity = GravityDirection * Time.deltaTime + Movement * Time.deltaTime * Speed;
    Controller.Move(PlayerVelocity);
}

float GetMovementSpeed()
{
    if (Input.GetButton("Fire3"))// Left shift
    {
        return RunSpeed;
    }
    else
    {
        return WalkSpeed;
    }
}
}
