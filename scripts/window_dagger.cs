using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class window_dagger : MonoBehaviour
{
    private Transform _thiefPos;
    private Vector3 _direction;
    private float _speed = 2;
    private float _timePeriod = 1;
    private Camera _camera;
    private Vector3 _startPosition;
    private float _currentTime;
    private Collider2D _collider;

    void Start()
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        _collider = GameObject.FindGameObjectWithTag("grounder").GetComponent<Collider2D>();
        _thiefPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _startPosition = transform.position;
        _direction = _thiefPos.position - transform.position;
        _direction = _direction.normalized;
        _currentTime = _timePeriod;
        Quaternion toRotate = Quaternion.LookRotation(Vector3.forward, _direction);
        transform.rotation = toRotate;
    }

    void Update()
    {
        if (_currentTime > 0) _currentTime -= Time.deltaTime;
        if (_currentTime <= 0)
        {
            transform.position += (_speed * Time.deltaTime * _direction);
            if (!IsInWindow())
            {
                _currentTime = _timePeriod;
                transform.position = _startPosition;
                transform.gameObject.SetActive(false);
            }   
        }
    }

    bool IsInWindow()
    {
        var view = _camera.WorldToViewportPoint(transform.position);
        return view.x >= 0 && view.x <= 1 && view.y >= 0 && view.y <= 1;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _collider.enabled = false;
        }
    }
}