using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Dynamite : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private DynamiteAnimation _anim;
    [SerializeField] private float _explosionDelay;
    [SerializeField] private float _explosionRadius;
    private int _explosionDamage;
    public DynamitePool DynamitePool { get; private set; }

    [HideInInspector]
    public UnityEvent OnExplosion = new();

    private void OnEnable()
    {
        StartCoroutine(ExplodeAfterDelayRoutine(_explosionDelay));
    }

    private void Start()
    {
        _anim.EndExplosion.AddListener(ReturnToPool);
    }
    public void SpawnFromPool(DynamitePool pool)
    {
        DynamitePool = pool;
    }

    public void SetDamage(int damage)
    {
        _explosionDamage = damage;
    }

    private IEnumerator ExplodeAfterDelayRoutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        Explosion();
    }

    private void Explosion()
    {
        OnExplosion.Invoke();
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _explosionRadius);
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.CompareTag("Player"))
            {
                PlayerHealth playerHealth = collider.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(_explosionDamage);
                }
            }
        }
    }
    private void ReturnToPool()
    {
        DynamitePool.ReturnToPool(this);
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _explosionRadius);
    }
}
