using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Variables Movement et Rotation
    public float moveSpeed;
    public Rigidbody playerRigidbody;
    public Camera mainCam;
    private Vector3 moveVelocity;
    private Vector3 groundPoint;

    void Update()
    {
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveSpeed * moveInput.normalized * moveInput.normalized.magnitude;
        Ray pointRay = mainCam.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayDistance;

        if (groundPlane.Raycast(pointRay, out rayDistance) )
        {
            groundPoint = pointRay.GetPoint(rayDistance);
        }
        transform.LookAt(new Vector3(groundPoint.x, transform.position.y, groundPoint.z));

    }

    void FixedUpdate()
    {
        playerRigidbody.MovePosition(playerRigidbody.position + moveVelocity * Time.fixedDeltaTime);
        playerRigidbody.angularVelocity = Vector3.zero;
    }
}