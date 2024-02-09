using TMPro;
using UnityEngine;
using UnityEngine.Events;

public abstract class Resource : MonoBehaviour
{
    [SerializeField] private TMP_Text _notificationText;
    [SerializeField] protected string _itemName;
    [SerializeField] protected int _itemCount;

    private bool PlayerInRange;

    public static UnityEvent<string, int> ItemPicked = new ();

    private void Start()
    {
        UpdateNotificationText();
    }

    private void Update()
    {
        if(PlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            PickUp();
        }
    }

    private void PickUp()
    {
        ItemPicked.Invoke(_itemName, _itemCount);
    }

    private void UpdateNotificationText()
    {
        if(_itemCount > 1) 
        {
            _notificationText.text = $"{_itemCount} {_itemName}(E)";
        }
        else
        {
            _notificationText.text = $"{_itemName}(E)";
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerInRange = true;
            _notificationText.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerInRange = false;
            _notificationText.gameObject.SetActive(false);
        }
    }

}
