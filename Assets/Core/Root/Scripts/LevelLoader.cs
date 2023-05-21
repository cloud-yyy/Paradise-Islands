using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private ChunkedPathGenerator _generator;
    [SerializeField] private MainSpawner _spawner;
    [SerializeField] private TextMeshProUGUI _levelHeader;

    private Chunk[] _path;
    public LevelInfo Info { get; private set; }

    public event Action OnUpdated;

    public void Load(LevelInfo info)
    {
        if (info == null)
            info = CreateInfo(1);
        Info = info;
        _path = new Chunk[info.ChunkInfos.Length];

        for (int i = 0; i < _path.Length; i++)
            _path[i] = info.ChunkInfos[i].CreateChunk();

        _levelHeader.text = $"Level {Info.LastLevelIndex}";
        _spawner.InitPath(_path);
    }

    private LevelInfo CreateInfo(int levelNumber)
    {
        _path = _generator.CreatePath(_generator.CalculatePathLengthByLevel(levelNumber));
        var chunkInfos = new ChunkInfo[_path.Length];

        for (int i = 0; i < chunkInfos.Length; i++)
            chunkInfos[i] = new ChunkInfo(_path[i]);

        return new LevelInfo(levelNumber, chunkInfos);
    }

    public void UpdateInfo()
    {
        Info = CreateInfo(++Info.LastLevelIndex);
        OnUpdated?.Invoke();
    }
}
