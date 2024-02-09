using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem.XR;
using Zenject;

public class PlayerAnimController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Player _player;
    private Vector3 _scale;

    private readonly int IsRunning = Animator.StringToHash("IsRunning");
    private readonly int IsDead = Animator.StringToHash("IsDead");

    private readonly int AttackX = Animator.StringToHash("AttackX");
    private readonly int AttackUp = Animator.StringToHash("AttackUp");
    private readonly int AttackDown = Animator.StringToHash("AttackDown");

    private InputController _controls;
    private bool isAttackAnim;

    [HideInInspector]
    public UnityEvent<bool> IsAttack = new(); 

    [Inject]
    private void Construct(InputController controller)
    {
        _controls = controller;
    }
    
    private void Start()
    {
        PlayerAttack.OnAttack.AddListener(AttackAnim);
    }

    private void Update()
    {
        RunAnim();

        if (Input.GetKey(KeyCode.Space))
        {
            DeathAnim();
        }
    }

    private void AttackAnim(Vector2 dirAttack)
    {
        if(dirAttack.x > 0 || dirAttack.x < 0)
        {
            UpdateMirrorState();
            _animator.SetTrigger(AttackX);
        }

        if (dirAttack.y > 0)
        {
            _animator.SetTrigger(AttackUp);
        }
        else if(dirAttack.y < 0)
        {
            _animator.SetTrigger(AttackDown);
        }
    }

    private void RunAnim()
    {
        var moveX = _controls.Player.MoveX.ReadValue<float>();
        var moveY = _controls.Player.MoveY.ReadValue<float>();

        var isRunning = moveY != 0 || moveX != 0;

        _animator.SetBool(IsRunning, isRunning);
        UpdateMirrorState();
    }
    private void UpdateMirrorState()
    {
        if (!isAttackAnim)
        {
            if (_controls.Player.MoveX.ReadValue<float>() < 0 || _controls.Player.Attack.ReadValue<Vector2>().x < 0)
            {
                if (_player.transform.localScale.x > 0)
                {
                    _scale = _player.transform.localScale;
                    _scale.x *= -1;
                    _player.transform.localScale = _scale;
                }
            }
            else if (_controls.Player.MoveX.ReadValue<float>() > 0 || _controls.Player.Attack.ReadValue<Vector2>().x > 0)
            {
                if (_player.transform.localScale.x < 0)
                {
                    _scale = _player.transform.localScale;
                    _scale.x *= -1;
                    _player.transform.localScale = _scale;
                }
            }
        }
    }

    private void DeathAnim()
    {
        _animator.SetTrigger(IsDead);
    }

    private void StartAttackAnim()
    {
        isAttackAnim = true;
        IsAttack.Invoke(isAttackAnim);
    }

    private void EndAttackAnim()
    {
        isAttackAnim = false;
        IsAttack.Invoke(isAttackAnim);
    }
}
