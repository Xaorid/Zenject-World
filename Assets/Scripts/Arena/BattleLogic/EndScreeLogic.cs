using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScreeLogic : MonoBehaviour
{
    [SerializeField] private Canvas[] _otherCanvas;
    [SerializeField] private Image _endScreen;
    [SerializeField] private Button[] _buttons;

    private void Start()
    {
        PlayerHealth.PlayerIsDead.AddListener(EndGame);
        _endScreen.DOFade(0, 0);
    }

    private void EndGame()
    {
        foreach (var canvas in _otherCanvas)
        {
            canvas.gameObject.SetActive(false);
        }

        EndScreenAnim();
    }

    public void RestartArena()
    {
        _endScreen.gameObject.SetActive(false);
        SceneManager.LoadScene("Arena");
    }
    
    public void ExitToMainMenu()
    {
        _endScreen.gameObject.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }

    private void EndScreenAnim()
    {
        _endScreen.gameObject.SetActive(true);

        Sequence endScreenSequence = DOTween.Sequence();
        endScreenSequence.Append(_endScreen.DOFade(1, 2f));
;
        foreach (var button in _buttons)
        {
            float currentYPosition = button.transform.position.y;

            button.transform.position = new Vector3(button.transform.position.x, Screen.height + button.GetComponent<RectTransform>().sizeDelta.y, button.transform.position.z);
            endScreenSequence.Append(button.transform.DOMoveY(currentYPosition, 0.5f).SetEase(Ease.OutBounce));
        }

        endScreenSequence.Play();
    }
}
