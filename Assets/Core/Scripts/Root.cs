using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField] private Character _character;

    [SerializeField] private ChunkedPathGenerator _pathGenerator;
    [SerializeField] private MainSpawner _spawner;

    private IDataService _dataService;
    private GameInfo _gameInfo;
    private int _length = 20;

    private const string Key = @"GameInfo";

    private void Start()
    {
        _dataService = new LocalDataService();
        _dataService.Load<GameInfo>(Key, OnLoaded);
    }

    public void StartGame()
    {
        _spawner.StartSpawning();
    }

    private void OnLoaded(GameInfo info)
    {
        _gameInfo = (info == null) ? new GameInfo(0, 1, null) : info;

        if (_gameInfo.ChunkedLevel == null) 
            _gameInfo.ChunkedLevel = _pathGenerator.CreatePath(_length);

        _spawner.InitPath(_gameInfo.ChunkedLevel);
    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {

    }
}
