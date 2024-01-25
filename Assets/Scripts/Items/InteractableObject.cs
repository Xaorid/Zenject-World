using TMPro;
using UnityEngine;

public abstract class InteractableObject : MonoBehaviour
{
    public abstract TMP_Text NotificationText { get; }
    public abstract string ItemText { get; }
    public abstract bool PlayerInRange { get; }
    public abstract void SetNotification(string text);
    public abstract void ShowNotification(TMP_Text text);
    public abstract void HideNotification(TMP_Text text);
    public abstract void Interact();
}
