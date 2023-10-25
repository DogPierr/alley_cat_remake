using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class example : MonoBehaviour
{
    // Start is called before the first frame update

    private Animator _animator;
    private Rigidbody2D _rigidbody;
    public float speed = 3;
    private static readonly int IsWalk = Animator.StringToHash("isWalk");
    private static readonly int IsIdle = Animator.StringToHash("isIdle");
    public float _jumpSpeed = 9.8f;
    private bool _isFlying = false;
    private BoxCollider2D _collider;

    private void Awake() // executes before instancing. In another words, it executes before start().
    {
        throw new NotImplementedException();
    }

    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();

        var t = transform;
        var local = t.localPosition;
        var globla = t.position;
        var rotation = t.rotation; // quaternion
        
        // rotation.SetLookRotation();
    }

    private void Move()
    {
        var input = Input.GetAxis("Horizontal");
        var directionVector = new Vector3(input > 0 ? -1 : 1, 1, 1);
        var translation = speed * Time.deltaTime * input;

        if (input != 0)
        {
            transform.localScale = directionVector;
        }

        transform.Translate(new Vector3(translation, 0, 0));
        _animator.SetBool(IsWalk, (Math.Abs(input) > 0.1));
    }

    private void Jump()
    {
        var input = Input.GetKeyDown("space");
        if (input && IsGrounded())
        {
            _rigidbody.velocity = Vector2.up * _jumpSpeed;
        }
    }

    private bool IsGrounded()
    {
        var rayCast = Physics2D.BoxCast(_collider.bounds.center, _collider.bounds.size,
            0f, Vector2.down * 0.1f);
        return rayCast.collider is not null;
    }

    private void UpdateFlyingSpeed()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    // executes just after update. rarely needed but when needed its really needed.
    private void LateUpdate()
    {
        throw new NotImplementedException();
    }

    // fixed constant amount of tics in every second 
    private void FixedUpdate()
    {
        Jump();
    }

    // there is a flag in unity. you can 
    private void OnEnable()
    {
        throw new NotImplementedException();
    }
    
    // for action after pressing home button on phone
    private void OnApplicationPause(bool pauseStatus)
    {
        throw new NotImplementedException();
    }
    
    private void OnGUI()
    {
        throw new NotImplementedException();
    }
    
    // executes when changed some values in behaviours
    private void OnValidate()
    {
        throw new NotImplementedException();
    }
}