using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    [Header("Menu Buttons")]
    [SerializeField] private GameObject _offButtons;
    [SerializeField] private SecretButton _secretBtn;

    [Header("OptionMenu")]
    [SerializeField] private Image _optiontsMenu;

    private void Start()
    {
        _secretBtn.SecretOn.AddListener(MenuOff);
    }
    public void CreateNewGame()
    {
        SceneManager.LoadSceneAsync("Arena");
    }
    public void OpenOptions() => _optiontsMenu.gameObject.SetActive(true);
    public void CloseOptions() => _optiontsMenu.gameObject.SetActive(false);
    private void MenuOff() => _offButtons.gameObject.SetActive(false);
    public void ExitGame() => Application.Quit();
}
