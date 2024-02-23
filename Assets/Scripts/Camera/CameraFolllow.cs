using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CameraFolllow : MonoBehaviour
{
    private Camera _camera;
    private PlayerBrains _player;

    [Inject]
    private void Construct(PlayerBrains player)
    {
        _player = player;
    }

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        var playerPos = _player.transform.position;
        playerPos.z = -10;
        _camera.transform.position = playerPos;
    }
}
