using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class window : MonoBehaviour
{
    [SerializeField] private int _windowNumber = 0;
    private Collider2D _collider;
    private float _timePeriod = 5;
    private float _currentTime;
    private float _timeOpen = 2;
    private float _currentTimeOpened;
    private SpriteRenderer _arrow;
    [SerializeField] public GameObject gameOver;
    
    void Start()
    {
        _collider = GetComponent<Collider2D>();
        _arrow = transform.Find("arrow").GetComponent<SpriteRenderer>();
        _arrow.enabled = false;
        _collider.enabled = false;
        _currentTime = _timePeriod;
        _currentTimeOpened = 0;
    }
    
    void Update()
    {
        if (!_collider.enabled)
        {
            _currentTime -= Time.deltaTime;
            if (_currentTime <= 0)
            {
                _currentTimeOpened = _timeOpen;
                _collider.enabled = true;
                Debug.Log("Opened");
                _arrow.enabled = true;
            }
        } else
        {
            _currentTimeOpened -= Time.deltaTime;
            if (_currentTimeOpened <= 0)
            {
                _currentTime = _timePeriod;
                _collider.enabled = false;
                _arrow.enabled = false;
                transform.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (gameOver) gameOver.SetActive(true);
        }
    }
}
