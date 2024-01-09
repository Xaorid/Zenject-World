using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerAttack : PlayerCore
{
    public static UnityEvent OnAttack = new UnityEvent();


    private void Awake()
    {
        _controls = new InputController();
        _controls.Main.AttackX.performed += AttackPerformed;
    }

    private void AttackPerformed(InputAction.CallbackContext context)
    {
        OnAttack.Invoke();
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
