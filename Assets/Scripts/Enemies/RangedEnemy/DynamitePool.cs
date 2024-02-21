using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamitePool : MonoBehaviour
{
    [SerializeField] private Dynamite _dynamitePref;
    [SerializeField] private int _poolSize;

    private Queue<Dynamite> dynamites = new();

    public Dynamite SpawnDynamiteFromPool()
    {
        if(dynamites.Count > 0)
        {
            var dynamite = dynamites.Dequeue();
            dynamite.gameObject.SetActive(true);
            return dynamite;
        }
        else
        {
            return CreateNewDynamite();
        }
    }

    private Dynamite CreateNewDynamite()
    {
        var newDynamite = Instantiate(
            _dynamitePref,
            transform.position,
            Quaternion.identity, 
            transform);
        newDynamite.SpawnFromPool(this);
        return newDynamite;
    }

    public void ReturnToPool(Dynamite dynamite)
    {
        dynamite.gameObject.SetActive(false);
        dynamites.Enqueue(dynamite);
    }
}
