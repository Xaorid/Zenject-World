using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIResources : MonoBehaviour
{
    [SerializeField] private TMP_Text _goldCountText;
    [SerializeField] private TMP_Text _woodCountText;

    private Dictionary<string, TMP_Text> _resourceTexts;

    private void Start()
    {
        InitializeResourceTexts();
        PlayerInventory.UpdateOnUI.AddListener(ResourceTextUpdate);
    }

    private void ResourceTextUpdate(string resource, int value)
    {
        if (_resourceTexts.TryGetValue(resource, out var text))
        {
            text.text = $"{resource}: " + value.ToString();
        }
    }

    private void InitializeResourceTexts()
    {
        _resourceTexts = new Dictionary<string, TMP_Text>()
        {
            ["Gold"] = _goldCountText,
            ["Wood"] = _woodCountText
        };
    }
}
