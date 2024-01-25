using UnityEngine;

public class PlayerAnimController : PlayerCore
{
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerCore _player;
    private Vector3 _scale;

    private static readonly int IsRunning = Animator.StringToHash("IsRunning");
    private static readonly int AttackX = Animator.StringToHash("AttackX");
    private static readonly int IsDead = Animator.StringToHash("IsDead");

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
            if (_player.transform.localScale.x > 0)
            {
                _scale = _player.transform.localScale;
                _scale.x *= -1;
                _player.transform.localScale = _scale;
            }
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            if (_player.transform.localScale.x < 0)
            {
                _scale = _player.transform.localScale;
                _scale.x *= -1;
                _player.transform.localScale = _scale;
            }
        }
    }

    private void DeathAnim()
    {
        _animator.SetTrigger(IsDead);
    }
}
