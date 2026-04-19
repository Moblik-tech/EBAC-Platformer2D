using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Moblik.Core.Singleton;

public class GameManager : Singleton<GameManager>
{
    [Header("Player")]
    public GameObject playerPrefab;

    [Header("Enemies")]
    public List<GameObject> enemies;

    [Header("References")]
    public Transform startPoint;
    private GameObject _currentPlayer;

    [Header("Animation")]
    public float duration = 0.2f;
    public float delay = 0.1f;
    public Ease easeType = Ease.OutBack;

    void Start()
    {
        Init();
    }

    public void Init()
    {
        SpawnPlayer();
    }

    void SpawnPlayer()
    {
        _currentPlayer = Instantiate(playerPrefab);
        _currentPlayer.transform.position = startPoint.position;
        _currentPlayer.transform.DOScale(0, duration).SetEase(easeType).From().SetDelay(delay);
    }
}