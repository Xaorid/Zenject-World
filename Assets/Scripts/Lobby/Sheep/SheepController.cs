using UnityEngine;
using UnityEngine.Events;

public class SheepController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _speed = 250f;

    [HideInInspector]
    public UnityEvent<float> OnJump = new(); 

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 inDir = collision.gameObject.transform.position - transform.position;
            Vector2 outDir = Vector2.Reflect(inDir, collision.contacts[0].normal);
            _rb.velocity += outDir * (_speed * Time.deltaTime);
            OnJump.Invoke(_rb.velocity.x);
        }
    }

    
}
