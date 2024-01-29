using TMPro;
using UnityEngine;

public class OptionUI : MonoBehaviour
{
    [Header("Texts")]
    [SerializeField] private TMP_Text _soundVolumeText;
    [SerializeField] private TMP_Text _musicVolumeText;

    private void Start()
    {
        AudioSetting.MusicVolumeChanged.AddListener(UpdateMusicVolume);
        AudioSetting.SoundVolumeChanged.AddListener(UpdateSoundVolume);
    }
    private void UpdateMusicVolume(float musicVolume)
    {
        _musicVolumeText.text = musicVolume.ToString() + "%";
    }
    private void UpdateSoundVolume(float soundVolume)
    {
        _soundVolumeText.text = soundVolume.ToString() + "%";
    }
}
