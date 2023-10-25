using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class handler : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Handler")) return;
        
        var thief = other.transform.parent.gameObject;
        thief.GetComponent<Rigidbody2D>().gravityScale = 0;
        if (thief) thief.transform.SetParent(transform);
        thief.GetComponent<Rigidbody2D>().velocity = new Vector2(thief.GetComponent<Rigidbody2D>().velocity.x, 0);
        thief.GetComponent<thief>().isGrounded = true;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Handler")) return;
        
        var input = Input.GetAxis("Vertical");
        var thief = other.transform.parent.gameObject;
        thief.GetComponent<Rigidbody2D>().gravityScale = input < 0 ? 1 : 0;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Handler")) return;
        
        var thief = other.transform.parent.gameObject;
        if (thief) thief.transform.SetParent(null);
        thief.GetComponent<Rigidbody2D>().gravityScale = 1;
        thief.GetComponent<thief>().isGrounded = false;
    }
}
