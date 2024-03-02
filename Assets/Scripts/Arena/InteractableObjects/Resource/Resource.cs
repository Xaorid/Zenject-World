using UnityEngine;
using UnityEngine.Events;

public abstract class Resource : InteractableObject, IPoolable<DropController>
{
    [SerializeField] protected string _itemName;
    [SerializeField] protected int _itemCount;
    protected DropController _dropController;
    public string GetItemName => _itemName;
    public abstract float DropChance { get; }

    public static UnityEvent<string, int> ItemPicked = new ();

    private void Start()
    {
        UpdateNotificationText();
    }

    private void Update()
    {
        if(PlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    public override void Interact()
    {
        ItemPicked.Invoke(_itemName, _itemCount);
        ReturnToPool();    
    }

    public void UpdateNotificationText()
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

    public void OnSpawnFromPool(DropController pool)
    {
        _dropController = pool;
    }

    public void ReturnToPool()
    {
        _dropController.ReturnResourceToPool(this);
    }
}
