using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class grounder : MonoBehaviour
{
    private float _startY;
    private Collider2D _collider;

    private void Start()
    {
        _startY = transform.position.y;
        _collider = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("platform"))
        {
            transform.parent.gameObject.GetComponent<thief>().isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("platform"))
        {
            transform.parent.gameObject.GetComponent<thief>().isGrounded = false;
        }
    }

    private void Update()
    {
        CheckIfGrounded();
    }

    void CheckIfGrounded()
    {
        if (transform.position.y <= _startY)
        {
            _collider.enabled = true;
        }
    }
}
