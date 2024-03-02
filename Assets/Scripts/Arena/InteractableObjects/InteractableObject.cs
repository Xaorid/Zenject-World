using TMPro;
using UnityEngine;

public abstract class InteractableObject : MonoBehaviour, IInteractable
{
    [SerializeField] protected TMP_Text _notificationText;
    protected bool PlayerInRange;

    public abstract void Interact();

    public void RemoveNotification(Collider2D collision, TMP_Text notification)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerInRange = false;
            notification.gameObject.SetActive(false);
        }
    }

    public void ShowNotification(Collider2D collision, TMP_Text notification)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerInRange = true;
            notification.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ShowNotification(collision, _notificationText);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        RemoveNotification(collision, _notificationText);
    }
}
