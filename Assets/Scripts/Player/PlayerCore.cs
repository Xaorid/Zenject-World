using Unity.VisualScripting;
using UnityEngine;

public class PlayerCore : MonoBehaviour
{
    protected InputController _controls;

    private void Awake()
    {
        _controls = new InputController();                    
    }
}
