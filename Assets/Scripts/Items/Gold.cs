using TMPro;
using UnityEngine;

public class Gold : InteractableObject
{
    [SerializeField] private TMP_Text _notificationText;
    [SerializeField] private string _itemText;
    private int _goldCount;

    private bool isPlayerInRange = false;

    public override TMP_Text NotificationText => _notificationText;
    public override string ItemText => _itemText;
    public override bool PlayerInRange => isPlayerInRange;

    private void Start()
    {
        SetGoldCount();
        HideNotification(NotificationText);
        SetNotification(ItemText);
    }
    private void Update()
    {
        if(PlayerInRange && Input.GetKeyUp(KeyCode.E))
        {
            Interact();
        }
    }
    public override void Interact()
    {
        Debug.Log($"{_goldCount} {_itemText}");
        Destroy(gameObject);
    }
    private void SetGoldCount()
    {
        _goldCount = Random.Range(1, 5);
    }
    public override void SetNotification(string text)
    {
        _notificationText.text = $"{_goldCount} " + text + "(E)";
    }
    public override void HideNotification(TMP_Text text)
    {
        NotificationText.gameObject.SetActive(false);
    }
    public override void ShowNotification(TMP_Text text)
    {
        NotificationText.gameObject.SetActive(true);
        
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
