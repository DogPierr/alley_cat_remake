using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dagger_manager : MonoBehaviour
{
    private List<GameObject> _daggers;
    private int _randomDagger;
    
    void Start()
    {
        _daggers = new List<GameObject>();
        foreach (Transform child in transform)
        {
            _daggers.Add(child.gameObject);
        }

        _randomDagger = Random.Range(0, _daggers.Count - 1);
        _daggers[_randomDagger].SetActive(true);
    }
    
    void Update()
    {
        if (!_daggers[_randomDagger].activeSelf)
        {
            _randomDagger = Random.Range(0, _daggers.Count - 1);    
            _daggers[_randomDagger].SetActive(true);
        }
    }
}
