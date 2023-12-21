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
}