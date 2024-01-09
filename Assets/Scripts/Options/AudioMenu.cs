using UnityEngine;
using UnityEngine.Events;

public class AudioMenu : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _soundSource;

    [Header("ClickSound")]
    [SerializeField] private AudioClip _clickSound;

    private float _musicVolume = 100;
    private float _soundVolume = 100;

    public static UnityEvent<int> MusicVolumeChanged = new UnityEvent<int>();
    public static UnityEvent<int> SoundVolumeChanged = new UnityEvent<int>();


    public void MusicVolumeUp()
    {
        if(_musicVolume < 100) 
        {
            _musicVolume += 10;
            _musicSource.volume = _musicVolume / 100;
            MusicVolumeChanged.Invoke((int)_musicVolume);

            PlayClickSound();

        }

    }
    public void MusicVolumeDown()
    {
        if (_musicVolume > 0)
        {
            _musicVolume -= 10;
            _musicSource.volume = _musicVolume / 100;
            MusicVolumeChanged.Invoke((int)_musicVolume);
            PlayClickSound();
        }
    }
    public void SoundVolumeUp()
    {
        if (_soundVolume < 100)
        {
            _soundVolume += 10;
            _soundSource.volume = _soundVolume / 100;
            SoundVolumeChanged.Invoke( (int)_soundVolume);
            PlayClickSound();

        }
    }
    public void SoundVolumeDown()
    {
        if (_soundVolume > 0)
        {
            _soundVolume -= 10;
            _soundSource.volume = _soundVolume / 100;
            SoundVolumeChanged.Invoke((int)_soundVolume);
            PlayClickSound();
        }
    }   
    public void PlayClickSound() => _soundSource.PlayOneShot(_clickSound);
    
}
