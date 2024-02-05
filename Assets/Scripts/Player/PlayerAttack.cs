using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using Zenject;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _attackRange;
    [SerializeField] private LayerMask _enemyLayers;

    [SerializeField] private int _damage;
    [SerializeField] private float _attackCooldown;

    public bool _canAttack = true;

    public static UnityEvent<Vector2> OnAttack = new();

    private PlayerStats _playerStats;
    private InputController _controls;

    [Inject]
    private void Construct(InputController controls, PlayerStats playerStats)
    {
        _controls = controls;
        _playerStats = playerStats;
    }

    private void Awake()
    {
        _controls = new InputController();
        _controls.Player.Attack.performed += AttackPerformed;
    }

    private void Start()
    {
        _damage = _playerStats.Damage;
        _attackCooldown = _playerStats.AttackCooldown;
    }

    private void AttackPerformed(InputAction.CallbackContext context)
    {
        if (_canAttack)
        {
            _canAttack = false;
            var dir = context.ReadValue<Vector2>();
            OnAttack.Invoke(dir);
            dir.x *= transform.localScale.x;
            _attackPoint.localPosition = (Vector3)dir * _attackRange;

            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange, _enemyLayers);

            foreach (Collider2D hit in hitColliders)
            {
                if (hit.TryGetComponent(out EnemyHealth enemy))
                {
                    enemy.TakeDamage(_damage);
                }
            }

            StartCoroutine(AttackCooldown(_attackCooldown));
        }
    }

    private IEnumerator AttackCooldown(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        _canAttack = true;
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
