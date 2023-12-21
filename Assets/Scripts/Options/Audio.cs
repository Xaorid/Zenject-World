using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Audio : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _soundSource;

    [Header("Texts")]
    [SerializeField] private TMP_Text _soundVolumeText;
    [SerializeField] private TMP_Text _musicVolumeText;

    [Header("ClickSound")]
    [SerializeField] private AudioClip _clickSound;

    private float _musicVolume = 100;
    private float _soundVolume = 100;

    public void MusicVolumeUp()
    {
        if(_musicVolume < 100) 
        {
            _musicVolume += 10;
            _musicSource.volume = _musicVolume / 100;
            _musicVolumeText.text = _musicVolume.ToString() + "%";
            PlayClickSound();

        }

    }
    public void MusicVolumeDown()
    {
        if (_musicVolume > 0)
        {
            _musicVolume -= 10;
            _musicSource.volume = _musicVolume / 100;
            _musicVolumeText.text = _musicVolume.ToString() + "%";
            PlayClickSound();
        }
    }
    public void SoundVolumeUp()
    {
        if (_soundVolume < 100)
        {
            _soundVolume += 10;
            _soundSource.volume = _soundVolume / 100;
            _soundVolumeText.text = _soundVolume.ToString() + "%";
            PlayClickSound();

        }
    }
    public void SoundVolumeDown()
    {
        if (_soundVolume > 0)
        {
            _soundVolume -= 10;
            _soundSource.volume = _soundVolume / 100;
            _soundVolumeText.text = _soundVolume.ToString() + "%";
            PlayClickSound();
        }
    }   
    public void PlayClickSound() => _soundSource.PlayOneShot(_clickSound);
    
}
