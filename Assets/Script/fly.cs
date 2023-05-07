using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    public float jumpPower = 0.7f;
    public bool isGravityOn = false;
    public float Gravity = 200f;
    public float normalSpeed = 20f;
    public float runSpeed = 40f;
    private float speed = 20f;
    private CharacterController _charController;
    private Rigidbody rb;
    //public bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        _charController = GetComponent<CharacterController>();
    }

   /* void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Govno")
            isGrounded = true;
    }*/

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) speed = runSpeed;
        if (Input.GetKeyUp(KeyCode.LeftShift)) speed = normalSpeed;
        if (Input.GetKeyDown(KeyCode.G)) isGravityOn = !isGravityOn;

        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);

        movement = Vector3.ClampMagnitude(movement, speed);
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        if (isGravityOn == true)
        {
            movement.y -= Gravity * Time.deltaTime;
        }
        else {
            if (Input.GetKey(KeyCode.Space))
                movement.y += jumpPower;

            if (Input.GetKey(KeyCode.LeftControl))
                movement.y -= jumpPower;
        }
        _charController.Move(movement);

    }
}