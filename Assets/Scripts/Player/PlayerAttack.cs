using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerAttack : PlayerCore
{
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _attackRange;
    [SerializeField] private LayerMask _enemyLayers;

    public static UnityEvent OnAttack = new UnityEvent();

    private void Awake()
    {
        _controls = new InputController();
        _controls.Main.AttackX.performed += AttackPerformed;
    }

    private void AttackPerformed(InputAction.CallbackContext context)
    {
        OnAttack.Invoke();
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange, _enemyLayers);
        foreach (Collider2D hit in hitColliders)
        {
            Debug.Log("We hit " +  hit.name);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if(_attackPoint == null || _attackRange == 0)
        {
            return;
        }

        Gizmos.DrawWireSphere(_attackPoint.position, _attackRange);
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
