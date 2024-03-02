using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class CooldownIndicator : MonoBehaviour
{
    [SerializeField] private Image _indicator;

    private float _cooldown;
    private float _currentColldown;
    private PlayerBrains _player;

    [Inject]
    private void Construct(PlayerBrains player)
    {
        _player = player;
    }

    private void Awake()
    {
        PlayerAttack.AttackCooldownForUI.AddListener(SetAttackCooldownForUI);
        PlayerAttack.OnAttackCooldown.AddListener(ResetIndicatorFill);
    }

    private void FixedUpdate()
    {
        UpdateIndicator();
    }

    private void UpdateIndicator()
    {
        Vector2 indicatorPos = Camera.main.WorldToScreenPoint(_player.transform.position);
        indicatorPos.x += _indicator.rectTransform.rect.width;
        indicatorPos.y += _indicator.rectTransform.rect.height;
        _indicator.transform.position = indicatorPos;

        if(_currentColldown < _cooldown)
        {
            _currentColldown += Time.deltaTime;
            _indicator.fillAmount = _currentColldown / _cooldown;
        }

        _indicator.enabled = _indicator.fillAmount >= 1 ? false : true;
    }

    private void SetAttackCooldownForUI(float cooldown)
    {
        _cooldown = cooldown;
    }

    private void ResetIndicatorFill()
    {
        _indicator.fillAmount = 0;
        _currentColldown = 0;
    }
}
