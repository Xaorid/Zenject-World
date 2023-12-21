using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _speed;

    private IInputs _inputs;

    private void Awake()
    {
        _inputs = new KeyboardInputs();       
    }


    private void FixedUpdate()
    {
        var inputs = _inputs.input;
        _rb.velocity = inputs * (_speed * Time.deltaTime);
    }
}
