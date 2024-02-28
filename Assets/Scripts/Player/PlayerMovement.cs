using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class PlayerMovement : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private PlayerAnimController _playerAnimController;
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private bool _canMove = true;
    [SerializeField] private float _speedMovement;
    private float _speedByAgility = 15;

    private PlayerStats _playerStats;
    private InputController _controls;

    public static UnityEvent<float> UpdateSpeedUI = new();
    
    [Inject]
    private void Construct(PlayerStats playerStats, InputController controls)
    {
        _playerStats = playerStats;
        _controls = controls;
    }

    private void Start()
    {
        _playerAnimController.IsAttack.AddListener(HandleMove);
        _speedMovement = _playerStats.Speed;
        UpdateSpeedUI.Invoke(_speedMovement);
    }

    private void FixedUpdate()
    {
        if (_canMove && _playerHealth.IsAlive)
        {
            Move();
        }
    }

    private void Move()
    {
        var moveInput = new Vector2(_controls.Player.MoveX.ReadValue<float>(), _controls.Player.MoveY.ReadValue<float>());  
        _rb.velocity = moveInput * (_speedMovement * Time.deltaTime);        
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

    public void IncreaseSpeed(float additionalSpeed)
    {
        _speedMovement += additionalSpeed;
        UpdateSpeedUI.Invoke(_speedMovement);
    }

    public void IncreaseSpeedFromAgility(int agility)
    {
        var bonusSpeed = agility * _speedByAgility;
        IncreaseSpeed(bonusSpeed);
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
