using UnityEngine;

public class SheepAnimController : MonoBehaviour
{
    [SerializeField] private SheepController _sheepController;
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private readonly int Jumping = Animator.StringToHash("Jumping");

    private void Start()
    {
        _sheepController.OnJump.AddListener(SheepJumpAnim);
    }

    private void SheepJumpAnim(float dir)
    {
        _animator.SetTrigger(Jumping);
        UpdateFlipState(dir);
    }

    private void UpdateFlipState(float dir)
    {
        if (dir > 0)
        {
            _spriteRenderer.flipX = false;
        }
        else if (dir < 0)
        {
            _spriteRenderer.flipX = true;
        }
    }
}
