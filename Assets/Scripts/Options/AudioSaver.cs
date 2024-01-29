using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioSaver
{
    private static void SaveMusicVolume(float musicVolume) => PlayerPrefs.SetFloat("Music", musicVolume);
    private static void SaveSoundVolume(float soundVolume) => PlayerPrefs.SetFloat("Sound", soundVolume);
}
