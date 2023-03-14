using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
   Rigidbody playerRigidbody;
   public GameObject respawnObject;
   public float moveSpeed = 10f;
   public float mouseSensitivity = 2f;
   public float jumpVelocity = 10f;
   private Vector2 mouseInput;
    void Start()
    {
        
       playerRigidbody = GetComponent<Rigidbody>();
       respawnObject = GameObject.FindGameObjectWithTag("Respawn");
       Cursor.visible = false;
       Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

    mouseInput.x = Input.GetAxis("Mouse X");
    mouseInput.y = Input.GetAxis("Mouse Y");

    Vector3 movement = ((vertical * transform.forward * moveSpeed) + (horizontal * transform.right * moveSpeed));
    playerRigidbody.velocity = new Vector3(movement.x, playerRigidbody.velocity.y, movement.z);
    transform.Rotate(0, mouseInput.x * mouseSensitivity, 0, Space.Self);

    if (Input.GetKeyDown(KeyCode.R))
    {
        RespawnPlayer();
        }
    }
    public void RespawnPlayer()
    {
        transform.position = respawnObject.transform.position;
    }
}
