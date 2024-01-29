using System.Xml.Serialization;
using Unity.VisualScripting;
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
        var moveInput = new Vector2(_controls.Main.MoveX.ReadValue<float>(), _controls.Main.MoveY.ReadValue<float>());  
        _rb.velocity = moveInput * (_playerStats.GetSpeed * Time.deltaTime);        
    }

    private void Run()
    {
        if (_controls.Main.Run.ReadValue<float>() > 0)
        {
            _rb.velocity = _rb.velocity * _playerStats.GetSpeedMultiplier;
        }
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
