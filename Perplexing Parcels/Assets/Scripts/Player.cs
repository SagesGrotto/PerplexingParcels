using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 12f;
    float rbDrag = 6f;
    float horizontalMovement;
    float verticalMovement;
    Vector3 moveDirection;

    public Rigidbody playerRB; //rigidbody of projec
    // Start is called before the first frame update
    void Start()
    {
        playerRB = this.GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
//       Debug.Log(moveDirection);
        MyInput();
        ControlDrag();
    }

    void MyInput()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");

        moveDirection = transform.forward * verticalMovement + transform.right * horizontalMovement;
    }

    void ControlDrag()
    {
        playerRB.drag = rbDrag;
    }

    void FixedUpdate()
    {
        if (moveDirection == Vector3.zero) rbDrag = 100f;
        else rbDrag = 1f;
        MovePlayer();
    }

    void MovePlayer()
    {
        playerRB.AddForce(moveDirection * moveSpeed, ForceMode.Acceleration);
    }
}
