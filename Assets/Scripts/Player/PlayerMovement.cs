using System.Collections;
using UnityEngine;
using Zenject;

public class PlayerMovement : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Rigidbody2D _rb;

    private PlayerStats _playerStats;
    private InputController _controls;

    [Inject]
    private void Construct(PlayerStats playerStats, InputController controls)
    {
        _playerStats = playerStats;
        _controls = controls;
    }

    private void FixedUpdate()
    { 
        Move();
        Run();
    }

    private void Move()
    {
        var moveInput = new Vector2(_controls.Player.MoveX.ReadValue<float>(), _controls.Player.MoveY.ReadValue<float>());  
        _rb.velocity = moveInput * (_playerStats.Speed * Time.deltaTime);        
    }

    private void Run()
    {
        if (_controls.Player.Run.ReadValue<float>() > 0)
        {
            _rb.velocity *= _playerStats.SpeedMultiplier;
        }
    }

    private void StopMove()
    {
        
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
