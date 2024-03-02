using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioCore : MonoBehaviour
{
    [Header("Sources")]
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _soundSource;

    [Header("Music")]
    [SerializeField] private AudioClip[] _lobbyMusic;
    [SerializeField] private AudioClip[] _arenaMusic;
    [SerializeField] private AudioClip _mainMenuMusic;

    [Header("SFX")]
    [SerializeField] private AudioClip _clickSFX;

    private AudioCore instance;

    private void Start()
    {
        Singleton();
        SceneManager.sceneLoaded += OnSceneLoaded;
        _musicSource.volume = PlayerPrefs.GetFloat("Music");
        _soundSource.volume = PlayerPrefs.GetFloat("Sound");
    }


    private void Singleton()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
    }

    void Update()
    {
        if (!_musicSource.isPlaying)
        {
            PlayMusic(SceneManager.GetActiveScene().name);
        }
    }

    private void PlayMusic(string sceneIndex)
    {
        switch (sceneIndex)
        {
            case "Arena":
                _musicSource.clip = _arenaMusic[Random.Range(0, _arenaMusic.Length)];
                _musicSource.Play();
                    break;

            case "Lobby":
                _musicSource.clip = _lobbyMusic[Random.Range(0, _lobbyMusic.Length)];
                _musicSource.Play();
                break;

            case "MainMenu":
                _musicSource.clip = _mainMenuMusic;
                _musicSource.Play();
                break;  
        }
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
    {
        PlayMusic(scene.name);
    }
    public void PlayClickSound() => _soundSource.PlayOneShot(_clickSFX);
}
