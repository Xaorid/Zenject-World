using UnityEngine;
using UnityEngine.Events;

public class AudioSetting : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _soundSource;
    [SerializeField] private AudioCore _audioCore;

    private float _musicVolume = 100;
    private float _soundVolume = 100;

    public static UnityEvent<float> MusicVolumeChanged = new UnityEvent<float>();
    public static UnityEvent<float> SoundVolumeChanged = new UnityEvent<float>();

    public void MusicVolumeUp()
    {
        if(_musicVolume < 100) 
        {
            _musicVolume += 10;
            _musicSource.volume = _musicVolume / 100;
            AudioSaver.SaveMusicVolume(_musicSource.volume);
            MusicVolumeChanged.Invoke(_musicVolume);
            _audioCore.PlayClickSound();
        }
    }

    public void MusicVolumeDown()
    {
        if (_musicVolume > 0)
        {
            _musicVolume -= 10;
            _musicSource.volume = _musicVolume / 100;
            AudioSaver.SaveMusicVolume(_musicSource.volume);
            MusicVolumeChanged.Invoke(_musicVolume);
            _audioCore.PlayClickSound();
        }
    }

    public void SoundVolumeUp()
    {
        if (_soundVolume < 100)
        {
            _soundVolume += 10;
            _soundSource.volume = _soundVolume / 100;
            AudioSaver.SaveSoundVolume(_soundSource.volume);
            SoundVolumeChanged.Invoke( _soundVolume);
            _audioCore.PlayClickSound();
        }
    }

    public void SoundVolumeDown()
    {
        if (_soundVolume > 0)
        {
            _soundVolume -= 10;
            _soundSource.volume = _soundVolume / 100;
            AudioSaver.SaveSoundVolume(_soundSource.volume);
            SoundVolumeChanged.Invoke(_soundVolume);
            _audioCore.PlayClickSound();
        }
    }   
}
