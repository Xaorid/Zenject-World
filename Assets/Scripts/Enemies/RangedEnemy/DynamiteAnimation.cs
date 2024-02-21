using UnityEngine;
using UnityEngine.Events;

public class DynamiteAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Dynamite _dynamite;
    [SerializeField] private float _animSpeed;

    private readonly int Explosion = Animator.StringToHash("Explosion");

    [HideInInspector]
    public UnityEvent EndExplosion = new();

    private void Start()
    {
        _dynamite.OnExplosion.AddListener(SetExplosionAnim);
    }

    private void SetExplosionAnim()
    {
        _animator.SetTrigger(Explosion);
    }

    private void EndExplosionAnim()
    {
        EndExplosion.Invoke();
    }
}
