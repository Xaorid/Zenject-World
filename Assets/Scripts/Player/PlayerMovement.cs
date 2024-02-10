using System.Collections;
using UnityEngine;
using Zenject;

public class PlayerMovement : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private PlayerAnimController _playerAnimController;
    [SerializeField] private PlayerHealth _playerHealth;

    private PlayerStats _playerStats;
    private InputController _controls;
    [SerializeField] private bool _canMove = true;
    
    [Inject]
    private void Construct(PlayerStats playerStats, InputController controls)
    {
        _playerStats = playerStats;
        _controls = controls;
    }

    private void Start()
    {
        _playerAnimController.IsAttack.AddListener(HandleMove);

    }

    private void FixedUpdate()
    {
        if (_canMove && _playerHealth.IsAlive)
        {
            Move();
            Run();
        }
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

    private void OnEnable()
    {
        _controls.Enable();
    }
    private void OnDisable()
    {
        _controls.Disable();
    }

    private void HandleMove(bool isAttack)
    {
        if (isAttack)
        {
            _rb.velocity = Vector2.zero;
            _canMove = false;
        }
        else
        {
            _canMove = true;
        }
    }
}
