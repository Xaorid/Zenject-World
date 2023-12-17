using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] private TMP_Text _titleText; 

    [SerializeField] private Button _startBtn;
    [SerializeField] private Button _continueBtn;
    [SerializeField] private Button _optionsBtn;



    [SerializeField] private TMP_Text _secretText;
    private int _clickCounter;

    public void CreateNewGame()
    {
        
        
    }

    public void OpenOptions()
    {

    }

    public void ExitGame() => Application.Quit();

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

}
