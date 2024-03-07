using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _player;

    [SerializeField] protected Vector3 _currentPosition;

    private void Awake()
    {
        _currentPosition = transform.position;
    }
    void Update()
    {

    }
}
