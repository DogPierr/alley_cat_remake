using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] public GameObject gameOver;
    private float _leftX = -10.203f;
    private float _leftY = 9.22f;
    private float _speed = 5;
    private float _direction = 1;
    void Start()
    {
        
    }
    
    void Update()
    {
        transform.position += new Vector3(_speed * Time.deltaTime * _direction, 0f, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (gameOver) gameOver.SetActive(true);
        }
    }
}
