using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResolutionSetting : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _resolutionDrop;
    [SerializeField] private TMP_Text _EXAMPLE;

    private List<string> options = new List<string>();
    private List<Resolution> uniqueResolutions = new List<Resolution>();

    private void Start()
    {
        _resolutionDrop.ClearOptions();

        for (int i = 0; i < Screen.resolutions.Length; i++)
        {
            Resolution resolution = Screen.resolutions[i];
            string option = resolution.width + "x" + resolution.height;

            if (!options.Contains(option))
            {
                options.Add(option);
                uniqueResolutions.Add(resolution);
            }
        }

        int currentResolutionIndex = uniqueResolutions.FindIndex(res => res.width == Screen.currentResolution.width && res.height == Screen.currentResolution.height);
        _resolutionDrop.AddOptions(options);
        _resolutionDrop.RefreshShownValue();
        _resolutionDrop.onValueChanged.AddListener(delegate
        {
            ApplyResolution(uniqueResolutions[_resolutionDrop.value].width, uniqueResolutions[_resolutionDrop.value].height, Screen.fullScreen);
        });

        Screen.SetResolution(uniqueResolutions[uniqueResolutions.Count - 1].width, uniqueResolutions[uniqueResolutions.Count - 1].height, Screen.fullScreen);
        _resolutionDrop.value = Screen.resolutions.Length - 1;
    }

    private void ApplyResolution(int width, int height, bool fullScreen)
    {
        Screen.SetResolution(width, height, fullScreen);
    }
}
