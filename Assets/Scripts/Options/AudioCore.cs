using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCore : MonoBehaviour
{
    [Header("Music")]
    [SerializeField] private AudioClip _mainMenuMusic;
    [SerializeField] private AudioClip[] _lobbyMusic;
    [SerializeField] private AudioClip[] _arenaMusic;

    [Header("SFX")]
    [SerializeField] private AudioClip _lobbySFX;

    void Update()
    {
               
    }
}
