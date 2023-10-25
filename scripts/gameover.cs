using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameover : MonoBehaviour
{
    [SerializeField] public GameObject thief;
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    public void ButtonRestart()
    {
        thief.transform.SetParent(null);
        SceneManager.LoadScene("game");
    }
}
