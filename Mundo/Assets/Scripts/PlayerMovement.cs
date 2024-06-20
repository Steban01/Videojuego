using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Public_Variables
    [Header("Movement")]
    public float acelerationSpeed;
    public float desacelerationSpeed;
    public float maxSpeed;

    [Header("Jump")]
    public float jumpForce;

    [Header("Raycast - Ground")]
    public LayerMask groundMask;
    public float rayLenght;
    #endregion
    #region  Private_variables
    private Vector2 horizontalMovement;
    private Vector3 slowDown;
    private bool isGrounded;
    private bool jumpPressed;
    private Ray ray;
    private RaycastHit hit;
    private Rigidbody rb;
    private float horizontal;
    private float vertical;
    #endregion


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        InputPlayer();        
    }
    void FixedUpdate()
    {
        IsGrounded();
        
    }
    void InputPlayer()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }
    void IsGrounded()
    {
        ray.origin =  transform.position;
        ray.direction = -transform.up;

        if(Physics.Raycast(ray, out hit, rayLenght, groundMask))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        Debug.DrawRay(ray.origin, ray.direction * rayLenght, Color.red);
    }
}
