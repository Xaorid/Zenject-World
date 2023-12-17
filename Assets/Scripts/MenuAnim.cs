using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuAnim : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private TMP_Text _titleText;
    [Header("ShakeAnim")]
    [SerializeField] private GameObject[] _gameObjects;

    private void Start()
    {
        TitleAnim();
        ShakeAnim();
    }

    private void ShakeAnim()
    {
        foreach (var gameObj in _gameObjects)
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(gameObj.transform.DOShakePosition(1500f, 3, 1)
                    .SetLoops(-1));
        }
    }

    private void TitleAnim()
    {
        Vector3 startScale = transform.localScale;

        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(_titleText.transform.DOScale(transform.localScale * 1.2f, 2f))
                  .Append(_titleText.transform.DOScale(startScale, 2f))
                  .SetLoops(-1);
    }
}
