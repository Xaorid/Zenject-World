using System.Transactions;
using TMPro;
using UnityEngine;
using UnityEngine.Events;


public class Wood : InteractableObject
{
    [SerializeField] private TMP_Text _notificationText;
    [SerializeField] private string _itemText;
    
    private bool isPlayerInRange = false;

    public override TMP_Text NotificationText => _notificationText;
    public override string ItemText => _itemText;
    public override bool PlayerInRange => isPlayerInRange;

    public static UnityEvent OnPickUpWood = new();

    private void Start()
    {
        HideNotification(NotificationText);
        SetNotification(ItemText);
    }

    private void Update()
    {
        if (PlayerInRange && Input.GetKeyUp(KeyCode.E))
        {
            Interact();
        }
    }

    public override void Interact()
    {
        OnPickUpWood.Invoke();
        Debug.Log("Wood +1");
        Destroy(gameObject);
    }

    public override void SetNotification(string text)
    {
        _notificationText.text = text + "(E)";
    }
    public override void HideNotification(TMP_Text text)
    {
        _notificationText.gameObject.SetActive(false);
    }
    public override void ShowNotification(TMP_Text text)
    {
        _notificationText.gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ShowNotification(NotificationText);
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HideNotification(NotificationText);
            isPlayerInRange = false;
        }
    }
}
