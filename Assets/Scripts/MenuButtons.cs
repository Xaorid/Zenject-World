using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    [Header("Texts")]
    [SerializeField] private TMP_Text _titleText;
    [SerializeField] private TMP_Text _secretText;

    [Header("Menu Buttons")]
    [SerializeField] private Button _startBtn;
    [SerializeField] private Button _continueBtn;
    [SerializeField] private Button _optionsBtn;

    [Header("OptionMenu")]
    [SerializeField] private Image _optiontsMenu;

    private int _clickCounter;

    public void CreateNewGame()
    {

    }
    public void SecretButton()
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
            _startBtn.gameObject.SetActive(false);
            _continueBtn.gameObject.SetActive(false);
            _optionsBtn.gameObject.SetActive(false);

            _secretText.text = "Please, get out of the game!";
        }
    }
    public void OpenOptions() => _optiontsMenu.gameObject.SetActive(true);
    public void CloseOptions() => _optiontsMenu.gameObject.SetActive(false);
    public void ExitGame() => Application.Quit();
}
