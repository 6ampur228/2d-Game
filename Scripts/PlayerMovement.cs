using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private AudioSource _soundJump;
    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private Player _player;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _checkerRadius;

    private Rigidbody2D _playerRigidbody;
    private SpriteRenderer _playerSpriteRenderer;
    private Animator _playerAnimator;

    private bool _isGrounded;

    private void Start()
    {
        _playerRigidbody = _player.GetComponent<Rigidbody2D>();
        _playerSpriteRenderer = _player.GetComponent<SpriteRenderer>();
        _playerAnimator = _player.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundChecker.position, _checkerRadius, _whatIsGround);

        Jump();
    }

    private void Update()
    {
        Walk();
    }

    private void Walk()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal") * _speed;

        if (Input.GetKey(KeyCode.A))
        {
            _playerSpriteRenderer.flipX = true;

            transform.Translate(Time.deltaTime * horizontalMove, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            _playerSpriteRenderer.flipX = false;

            transform.Translate(Time.deltaTime * horizontalMove, 0, 0);
        }

        _playerAnimator.SetFloat("Speed", Mathf.Abs(horizontalMove));
    }

    private void Jump()
    {
        if (_isGrounded)
        {
            _playerAnimator.SetBool("IsJumping", false);

            if (Input.GetKey(KeyCode.Space))
            {               
                _playerRigidbody.velocity = Vector2.up * _jumpForce;

                _soundJump.Play();
            }
        }
        else
        {
            _playerAnimator.SetBool("IsJumping", true);
        }
    }
}
