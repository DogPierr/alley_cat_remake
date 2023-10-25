using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class chain_movemnet : MonoBehaviour
{
    private float _timePeriod = 2;
    private float _timeLeft;
    [SerializeField] private float _moveDirection = 1;
    private bool _isMoving = false;
    private float _distance = 10;
    private float _speed = 3;
    private float _distanceLeft;

    void Start()
    {
        _timeLeft = _timePeriod;
        _distanceLeft = _distance;
    }

    void Update()
    {
        _timeLeft -= Time.deltaTime;
        if (_timeLeft <= 0) _isMoving = true;
        if (_isMoving) StartMovement();
    }

    void StartMovement()
    {
        var translation = _speed * _moveDirection * Time.deltaTime;
        transform.Translate(new Vector3(translation, 0, 0));
        _distanceLeft -= math.abs(translation);
        if (_distanceLeft <= 0)
        {
            _isMoving = false;
            _timeLeft = _timePeriod;
            _distanceLeft = _distance;
            _moveDirection *= -1;
        }
    }
}