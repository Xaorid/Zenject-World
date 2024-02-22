using UnityEngine;

public class UIPauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (_pauseMenu.activeInHierarchy)
            {
                ClosePauseMenu();
            }
            else
            {
                OpenPauseMenu();
            }
        }
    }

    public void OpenPauseMenu()
    {
        _pauseMenu.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void ClosePauseMenu()
    {
        _pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
