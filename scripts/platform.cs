using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class platform : MonoBehaviour
{
    private thief _thief;
    private Collider2D _collider;
    private Collider2D _thiefCollider;
    private Collider2D _grounder;
    private float _timeToReset = 1f;
    private float _currentTime;
    private bool _isDisabled = false;
    void Start()
    {
        _collider = GetComponent<Collider2D>();
        _thief = GameObject.FindGameObjectWithTag("Player").GetComponent<thief>();
        _thiefCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
        _grounder = GameObject.FindGameObjectWithTag("grounder").GetComponent<Collider2D>();
        _currentTime = _timeToReset;
    }
    
    void Update()
    {
        if (Input.GetAxis("Vertical") < 0 && _thief.isGrounded)
        {
            _isDisabled = true;
            Physics2D.IgnoreCollision(_collider, _grounder);
        }

        if (_isDisabled)
        {
            _currentTime -= Time.deltaTime;
        }

        if (_currentTime <= 0)
        {
            _currentTime = _timeToReset;
            _isDisabled = false;
            Physics2D.IgnoreCollision(_collider, _grounder, false);
        }
    }
}
