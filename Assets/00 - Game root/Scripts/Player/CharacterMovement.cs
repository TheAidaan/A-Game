using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    float _moveSpeed = 6;

    [SerializeField] private AnimationCurve _jumpFalloff;   
    bool _isJumping = false;
    float _jumpMultiplier = 10;


    CharacterController _controller;

    void Start()
    {
        _controller =  GetComponent<CharacterController>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        float xMove = Input.GetAxis("Horizontal");
        float zMove = Input.GetAxis("Vertical");

        Vector3 forwardMovement = transform.forward * zMove;
        Vector3 rightMovement = transform.right * xMove;

        _controller.SimpleMove(Vector3.ClampMagnitude(forwardMovement + rightMovement, 1f) * _moveSpeed);

        if (Input.GetKeyDown(KeyCode.Space) && !_isJumping)
        {
            _isJumping = true;
            StartCoroutine(JumpEvent());
        }
    }

    IEnumerator JumpEvent()
    {
        float timeInAir = 0f;

        _controller.slopeLimit = 90f;

        do
        {
            float jumpforce = _jumpFalloff.Evaluate(timeInAir);
            _controller.Move(Vector3.up * jumpforce * _jumpMultiplier * Time.deltaTime);
            timeInAir += Time.deltaTime;
            yield return null;

        } while (!_controller.isGrounded && _controller.collisionFlags != CollisionFlags.Above);

        _controller.slopeLimit = 45f;
        _isJumping = false;
    }
}
