using UnityEngine;

public static class AudioSaver
{
    public static void SaveMusicVolume(float musicVolume) => PlayerPrefs.SetFloat("Music", musicVolume);
    public static void SaveSoundVolume(float soundVolume) => PlayerPrefs.SetFloat("Sound", soundVolume);
}
