using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody2D))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    private bool _isRightView;
    private bool _isGround;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        _isRightView = true;
        _isGround = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            _animator.SetBool("isRunning", true);

            if (!_isRightView)
                Flip();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            _animator.SetBool("isRunning", true);

            if (_isRightView)
                Flip();
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(_speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(_speed * Time.deltaTime * (-1), 0, 0);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            _animator.SetBool("isRunning", false);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            _animator.SetBool("isRunning", false);
        }

        if (_isGround)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _rigidbody2D.AddForce(Vector2.up * _jumpForce);
            }
            _animator.SetBool("isJumping", false);
        }
        else
        {
            _animator.SetBool("isJumping", true);
        }
        
    }

    private void Flip()
    {
        Vector3 direction;

        if (_isRightView)
        {
            direction = new Vector3(-1, 1, 1);
        }
        else
        {
            direction = new Vector3(1, 1, 1);
        }

        transform.localScale = direction;
        _isRightView = !_isRightView;
    }

    public void SetGround(bool value)
    {
        _isGround = value;
    }
}
