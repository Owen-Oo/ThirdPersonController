using System;
using Unity.Cinemachine;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private CinemachineCamera freeLookCamera;

    [SerializeField] private float speed;
    [SerializeField] private float jumpHeight;

    private Rigidbody playerRB;
    private Boolean canJump;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        canJump = true;

        inputManager.OnMove.AddListener(MovePlayer);
        inputManager.OnSpacePressed.AddListener(Jump);
        
    }

    void Update()
    {
        //Rotates the player to match the direction of the camera
        transform.forward = freeLookCamera.transform.forward;
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }

    private void MovePlayer(Vector2 direction)
    {
        Vector3 moveDirection = new(direction.x, playerRB.linearVelocity.y/5, direction.y);
        playerRB.linearVelocity = transform.rotation * moveDirection * speed;
    }

    private void Jump()
    {
        if (canJump)
        {
            Vector3 jumpDirection = new(0f, 1f, 0f);
            playerRB.AddForce(jumpDirection * jumpHeight);
            //canJump = false;
        }
    }
}
