using UnityEngine;

public class PlayerAnimController : PlayerCore
{
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private static readonly int IsRunning = Animator.StringToHash("IsRunning");
    private static readonly int AttackX = Animator.StringToHash("AttackX");

    private bool _isMovingLeft;
    private bool _wasMirrored;

    private void Start()
    {
        PlayerAttack.OnAttack.AddListener(AttackAnim);
    }

    private void Update()
    {
        RunAnim();
    }

    private void AttackAnim()
    {
        _animator.SetTrigger(AttackX);
    }

    private void RunAnim()
    {
        var isRunning = Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0 ? true : false;
        _animator.SetBool(IsRunning, isRunning);
        UpdateMirrorState();
    }
    private void UpdateMirrorState()
    {
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            _isMovingLeft = true;
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            _isMovingLeft = false;
        }

        if (_isMovingLeft != _wasMirrored)
        {
            _spriteRenderer.flipX = _isMovingLeft;
            _wasMirrored = _isMovingLeft;
        }
    }
}
