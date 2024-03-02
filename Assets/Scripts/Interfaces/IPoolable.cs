using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolable<T>
{
    public void ReturnToPool();
    public void OnSpawnFromPool(T pool);
}
