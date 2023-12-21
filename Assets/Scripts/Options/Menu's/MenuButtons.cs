using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    [Header("Menu Buttons")]
    [SerializeField] private Button _startBtn;
    [SerializeField] private Button _continueBtn;
    [SerializeField] private Button _optionsBtn;

    [Header("OptionMenu")]
    [SerializeField] private Image _optiontsMenu;

    private void Start()
    {
        SecretButton.SecretOn.AddListener(MenuOff);
    }

    public void CreateNewGame()
    {

    }
    public void OpenOptions() => _optiontsMenu.gameObject.SetActive(true);
    public void CloseOptions() => _optiontsMenu.gameObject.SetActive(false);
    public void ExitGame() => Application.Quit();
    private void MenuOff()
    {
        _startBtn.gameObject.SetActive(false);
        _continueBtn.gameObject.SetActive(false);
        _optionsBtn.gameObject.SetActive(false);
    }
}