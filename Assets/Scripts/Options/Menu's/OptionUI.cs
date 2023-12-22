using TMPro;
using UnityEngine;

public class OptionUI : MonoBehaviour
{
    [Header("Texts")]
    [SerializeField] private TMP_Text _soundVolumeText;
    [SerializeField] private TMP_Text _musicVolumeText;

    private void Start()
    {
        AudioMenu.MusicVolumeChanged.AddListener(UpdateMusicVolume);
        AudioMenu.SoundVolumeChanged.AddListener(UpdateSoundVolume);
    }
    private void UpdateMusicVolume(int musicVolume)
    {
        _musicVolumeText.text = musicVolume.ToString() + "%";
    }
    private void UpdateSoundVolume(int soundVolume)
    {
        _soundVolumeText.text = soundVolume.ToString() + "%";
    }
}
