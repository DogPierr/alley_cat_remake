using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class thief : MonoBehaviour
{
    // Start is called before the first frame update

    private Animator _animator;
    private Rigidbody2D _rigidbody;
    public float speed = 3;
    private static readonly int IsWalk = Animator.StringToHash("isWalk");
    private static readonly int IsIdle = Animator.StringToHash("isIdle");
    public int _jumpSpeed = 50;
    private BoxCollider2D _collider;
    [SerializeField] public bool isGrounded = true;
    
    
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
    }
    
    // TODO: вместо transform юзать rigidbody. иначе rigidbody сходит с ума.
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
        if (input && isGrounded)
        {
            _rigidbody.AddForce(new Vector2(0, _jumpSpeed), ForceMode2D.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Move();
    }

    // fixed constant amount of tics in every second 
    private void FixedUpdate()
    {
    }
}