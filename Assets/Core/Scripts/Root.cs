using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private LevelLoader _levelLoader;
    [SerializeField] private MainSpawner _spawner;

    private IDataService _dataService;
    private PlayerInfo _playerInfo;
    private int _coins;

    private const string Key = "playerInfo";

    private void Start()
    {
        _dataService = new LocalDataService();
        _dataService.Load<PlayerInfo>(Key, OnLoaded);
    }

    public void StartGame()
    {
        _spawner.StartMovement();
        _spawner.Run();
    }

    private void OnLoaded(PlayerInfo info)
    {
        _playerInfo = (info == null) ? new PlayerInfo(0, null) : info;

        _levelLoader.Load(_playerInfo.LevelInfo);

        SaveData();
    }

    private void SaveData()
    {
        _playerInfo.LevelInfo = _levelLoader.Info;

        _dataService.Save(_playerInfo, Key);
        Debug.Log("saved");
    }

    private void OnEnable()
    {
        _character.OnFinished += _levelLoader.UpdateInfo;
        _levelLoader.OnUpdated += SaveData;
    }

    private void OnDisable()
    {
        _character.OnFinished -= _levelLoader.UpdateInfo;
        _levelLoader.OnUpdated -= SaveData;
    }
}
