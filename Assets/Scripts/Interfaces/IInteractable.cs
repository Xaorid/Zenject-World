using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public interface IInteractable
{
    public void ShowNotification(Collider2D collision, TMP_Text notification);
    public void RemoveNotification(Collider2D collision, TMP_Text notification);
}
