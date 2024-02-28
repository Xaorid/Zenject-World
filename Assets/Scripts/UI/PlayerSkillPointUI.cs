using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerSkillPointUI : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] private TMP_Text _skillPointCountText;
    [SerializeField] private TMP_Text _agilityText;
    [SerializeField] private TMP_Text _vitalityText;
    [SerializeField] private TMP_Text _strengthText;

    [Header("Buttons")]
    [SerializeField] private Button[] _upgradeButtons;
    [SerializeField] private Button _healButton;

    [Header("Componets")]
    [SerializeField] private GameObject _upgradeMenu;

    public static UnityEvent<int> OnRemoveSkillPoint = new();
    public static UnityEvent<string> OnSkillUp = new();
    public static UnityEvent HealPressed = new();

    private void Awake()
    {
        PlayerLevel.SkillPointOnUI.AddListener(UpdateSkillCountText);
        WaveController.WaveEnd.AddListener(OnUpgradeMenu);
        PlayerBrains.OnParametersChanged += UpdateSkillText;
    }

    public void HealButtonPressed()
    { 
        HealPressed.Invoke();
        OnRemoveSkillPoint.Invoke(2);
    }

    public void SkillUpgradePressed(string parameter)
    {
        OnRemoveSkillPoint.Invoke(1);
        OnSkillUp.Invoke(parameter);
    }
    private void UpdateSkillCountText(int skillPoints)
    {
        CheckAvailableSkillPoints(skillPoints);
        _skillPointCountText.text = "SkillPoint: " + skillPoints.ToString();      
    }

    private void CheckAvailableSkillPoints(int skillPointCount)
    {
        if (skillPointCount == 0)
        {
            foreach (var button in _upgradeButtons)
            {
                button.gameObject.SetActive(false);
            }
        }
        else
        {
            foreach (var button in _upgradeButtons)
            {                  
                button.gameObject.SetActive(true);
            }
        }

        _healButton.gameObject.SetActive(skillPointCount >= 2 ? true : false);
    }

    private void UpdateSkillText(PlayerBrains.Parameters parameters)
    {
        _agilityText.text = $"Agility: {parameters.Agility}";
        _vitalityText.text = $"Vitality: {parameters.Vitality}";
        _strengthText.text = $"Strength: {parameters.Strength}";
    }

    private void OnUpgradeMenu()
    {
        _upgradeMenu.gameObject.SetActive(true);
    }

}
