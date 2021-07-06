using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Passerby_2 : Passerby_1
{
    [SerializeField] protected float jumpForce;
    [SerializeField] protected float jumpRate;
    protected float timeToNextJump;

    protected ApplyGravity applyGravityScript;
    protected Rigidbody rb;
    protected float tempSpeed;
    protected float jumpTime;
    protected bool isSpeedChanged;
    protected bool isJumping;

    protected virtual void Start()
    {
        applyGravityScript = GetComponent<ApplyGravity>();
        rb = GetComponent<Rigidbody>();

        tempSpeed = speed;
        timeToNextJump = Time.time + jumpRate;
    }

    protected override void Update()    // POLYMORPHISM
    {
        Jump();

        base.Update();
    }

    protected override void Move()      // POLYMORPHISM
    {
        if (!isSpeedChanged)
        {
            tempSpeed = Random.Range(speed / 2, speed / 2 + speed);
            isSpeedChanged = true;
        }

        transform.Translate(Vector3.forward * tempSpeed * Time.deltaTime, Space.Self);
    }

    protected void Jump()
    {
        if (!applyGravityScript.isGrounded) return;

        if (isJumping && jumpTime < Time.time)
        {
            isSpeedChanged = false;
            isJumping = false;
            timeToNextJump = Time.time + Random.Range(jumpRate / 2, jumpRate / 2 + jumpRate);
        }

        if (!isJumping && timeToNextJump < Time.time)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);

            isJumping = true;
            jumpTime = Time.time + 1f;
        }
    }
}
