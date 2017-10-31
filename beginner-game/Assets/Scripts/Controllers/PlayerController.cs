using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour {

    CharacterController controller;
    PlayerCamera camera;

    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;

    void Start () {
        controller = GetComponent<CharacterController>();
        camera = GetComponentInChildren<PlayerCamera>();
    }

	void Update () {
        
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), -0.75f, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }

        moveDirection.y -= gravity * Time.deltaTime;

        transform.rotation = Quaternion.Euler(0, camera.transform.rotation.eulerAngles.y, 0);

        controller.Move(moveDirection * Time.deltaTime);
    }
}
