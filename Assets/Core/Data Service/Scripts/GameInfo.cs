using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfo
{
    public int TotalCoins { get; set; }
    public int LastLevelIndex { get; set; }
    public Chunk[] ChunkedLevel { get; set; }

    public GameInfo(int totalCoins, int lastLevelIndex, Chunk[] chunkedLevel)
    {
        TotalCoins = totalCoins;
        LastLevelIndex = lastLevelIndex;
        ChunkedLevel = chunkedLevel;
    }
}
