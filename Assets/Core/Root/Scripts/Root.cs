using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Root : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private MainSpawner _spawner;
    [SerializeField] private LevelLoader _levelLoader;
    [SerializeField] private UILoader _UILoader;
    [SerializeField] private Wallet _wallet;

    private IDataService _dataService;
    private PlayerInfo _playerInfo;

    private const string Key = "playerInfo";

    private void Awake()
    {
        DOTween.Init(false, true, LogBehaviour.Default);
    }

    private void Start()
    {
        _dataService = new LocalDataService();
        _dataService.Load<PlayerInfo>(Key, OnLoaded);
    }

    private void OnLoaded(PlayerInfo info)
    {
        _playerInfo = (info == null) ? new PlayerInfo(0, null) : info;

        _levelLoader.Load(_playerInfo.LevelInfo);
        
        _wallet.Count = _playerInfo.TotalCoins;

        SaveData();
    }

    public void StartGame()
    {
        _spawner.Run();
    }

    public void PauseGame(bool paused)
    {
        Time.timeScale = paused ? 0 : 1;
        _character.EnableMovement(!paused);
        
        if (paused) 
            _UILoader.ShowPauseView();
        else 
            _UILoader.ShowPauseView();
    }

    public void FinishGame(int coins)
    {
        _spawner.Stop();
        _levelLoader.UpdateInfo();
        _playerInfo.TotalCoins += coins; 
        _UILoader.ShowFinishView(coins);
        SaveData();
    }

    public void LoseGame()
    {
        _spawner.Stop();
        _UILoader.ShowLoseView();
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void SaveData()
    {
        _playerInfo.LevelInfo = _levelLoader.Info;
        _dataService.Save(_playerInfo, Key);
    }

    private void OnEnable()
    {
        _character.OnFinished += FinishGame;
        _character.OnDestroyed += LoseGame;
    }

    private void OnDisable()
    {
        _character.OnFinished -= FinishGame;
        _character.OnDestroyed -= LoseGame;
    }
}
