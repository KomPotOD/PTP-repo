using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyGravity : MonoBehaviour
{
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private float radiusToGround;

    private const float gravity = -9.81f;
    private Vector3 gVector;
    private bool _isGrounded;
    public bool isGrounded { get { return _isGrounded; } }

    private CharacterController cc;

    private void Start()
    {
        TryGetComponent(out cc);
    }

    private void Update()
    {
        GroundCheck();
        Gravity();
    }

    private void GroundCheck()
    {
        _isGrounded = Physics.CheckSphere(groundCheck.position, radiusToGround, groundLayerMask);

        if (_isGrounded && gVector.y < 0)
        {
            gVector.y = -1f;
        }
    }

    private void Gravity()
    {
        gVector.y += gravity * Time.deltaTime;

        if (cc != null)
        {
            cc.Move(gVector);
        }
    }
}
