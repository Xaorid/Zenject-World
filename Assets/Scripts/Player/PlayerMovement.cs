using System.Data;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : PlayerCore
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D _rb;

    private void Awake()
    {
       _controls = new InputController();
    }

    private void FixedUpdate()
    {
       Move();
    }

    private void Move()
    {
        var moveInput = new Vector2(_controls.Main.MoveX.ReadValue<float>(), _controls.Main.MoveY.ReadValue<float>());  
        _rb.velocity = moveInput * (_speed * Time.deltaTime);        
    }

    private void OnEnable()
    {
        _controls.Enable();
    }
    private void OnDisable()
    {
        _controls.Disable();
    }
}
