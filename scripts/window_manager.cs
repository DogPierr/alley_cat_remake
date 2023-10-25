using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class window_manager : MonoBehaviour
{
    private List<GameObject> _windows;
    private int _randomWindow;
    
    void Start()
    {
        _windows = new List<GameObject>();
        foreach (Transform child in transform)
        {
            _windows.Add(child.gameObject);
        }

        _randomWindow = Random.Range(0, _windows.Count - 1);    
        _windows[_randomWindow].SetActive(true);
    }
    
    void Update()
    {
        if (!_windows[_randomWindow].activeSelf)
        {
            _randomWindow = Random.Range(0, _windows.Count - 1);    
            _windows[_randomWindow].SetActive(true);
        }
    }
}
