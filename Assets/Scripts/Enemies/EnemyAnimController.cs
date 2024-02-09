using UnityEngine;
using Zenject;

public class EnemyAnimController : MonoBehaviour
{
    private readonly int IsRunning = Animator.StringToHash("IsRunning");

    [SerializeField] private Animator _animator;
    [SerializeField] private EnemyMelee _enemy; 

    private Player _target;
    private Vector3 _scale;

    [Inject]
    private void Construct(Player target)
    {
        _target = target;
    }
    private void Update()
    {
        RunAnim();
        UpdateMirrorState();
    }

    private void RunAnim()
    {
        _animator.SetBool(IsRunning, true);
    }

    private void UpdateMirrorState()
    {
        if (_target.transform.position.x < _enemy.transform.position.x)
        {
            if (_enemy.transform.localScale.x > 0)
            {
                _scale = _enemy.transform.localScale;
                _scale.x *= -1;
                _enemy.transform.localScale = _scale;
            }
        }
        else if (_target.transform.position.x > _enemy.transform.position.x)
        {
            if (_enemy.transform.localScale.x < 0)
            {
                _scale = _enemy.transform.localScale;
                _scale.x *= -1;
                _enemy.transform.localScale = _scale;
            }
        }
    }
}
