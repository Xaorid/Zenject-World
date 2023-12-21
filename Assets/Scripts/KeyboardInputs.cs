using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInputs : IInputs
{
    public Vector2 input { get => new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); }
}
