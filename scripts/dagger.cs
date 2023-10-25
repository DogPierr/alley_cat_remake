using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dagger : MonoBehaviour
{
    private float _timePeriod = 3;
    private float _currentTime;
    private float _speedAbs = 1;
    private float _direction = 1;
    [SerializeField] private float _startY;
    private float _endY;
    private bool _isMoving = false;
    private Collider2D _collider;

    void Start()
    {
        _collider = GameObject.FindGameObjectWithTag("grounder").GetComponent<Collider2D>();
        _startY = transform.localPosition.y;
        _endY = _startY + 0.8f;
        _currentTime = _timePeriod;
    }

    void Update()
    {
        if (!_isMoving)
        {
            _currentTime -= Time.deltaTime;
            if (_currentTime <= 0)
            {
                _isMoving = true;
            }
        }
        else
        {
            Move();
        }
    }

    void Move()
    {
        transform.Translate(new Vector3(0, _speedAbs * _direction * Time.deltaTime, 0));
        if (transform.localPosition.y >= _endY) _direction = -1;
        else if (transform.localPosition.y <= _startY)
        {
            _direction = 1;
            
            var pos = transform.localPosition;
            pos.y = _startY;
            transform.localPosition = pos;
            
            _currentTime = _timePeriod;
            _isMoving = false;
            
            transform.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _collider.enabled = false;
        }
    }
}