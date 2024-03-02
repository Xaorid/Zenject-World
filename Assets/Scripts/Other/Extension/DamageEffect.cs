using DG.Tweening;
using UnityEngine;

public static class DamageEffect
{
    public static void SetDamageColor(this SpriteRenderer spriteRenderer)
    {
        spriteRenderer.DOColor(Color.red, 0.1f).OnComplete(() =>
        {
            spriteRenderer.DOColor(Color.white, 0.1f);
        });
    }
}
