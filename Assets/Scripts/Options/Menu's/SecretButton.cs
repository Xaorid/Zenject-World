using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class SecretButton : MonoBehaviour
{
    [Header("Texts")]
    [SerializeField] private TMP_Text _titleText;
    [SerializeField] private TMP_Text _secretText;

    private int _clickCounter;

    public static UnityEvent SecretOn = new UnityEvent();
    public void SecretClick()
    {
        _clickCounter++;

        if (_titleText.fontSize > -120)
        {
            _titleText.fontSize -= 15;
        }

        if (_clickCounter == 17)
        {
            _secretText.gameObject.SetActive(true);
        }
        else if (_clickCounter == 25)
        {
            SecretOn.Invoke();
            _secretText.text = "Please, get out of the game!";
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
