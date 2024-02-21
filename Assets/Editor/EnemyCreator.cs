using UnityEditor;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    [MenuItem("Assets/Create/NewEnemyPrefab")]
    public static void CreateNewEnemy()
    {
        GameObject parentObject = new ("New Enemy");

        GameObject childObject = new ("Visual");
        childObject.transform.parent = parentObject.transform;

        childObject.AddComponent<SpriteRenderer>();
        childObject.AddComponent<Animator>();
        childObject.AddComponent<EnemyAnimController>();

        parentObject.AddComponent<CircleCollider2D>();
        parentObject.AddComponent<Rigidbody2D>();
        parentObject.AddComponent<EnemyHealth>();

        PrefabUtility.SaveAsPrefabAsset(parentObject, "Assets/Prefabs/Enemies/New Enemy.prefab");

        DestroyImmediate(parentObject);
    }
}
