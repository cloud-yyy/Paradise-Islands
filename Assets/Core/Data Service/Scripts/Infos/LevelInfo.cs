using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelInfo
{
    public int LastLevelIndex;
    public ChunkInfo[] ChunkInfos;

    public LevelInfo(int lastLevelIndex, ChunkInfo[] chunkInfos)
    {
        LastLevelIndex = lastLevelIndex;
        ChunkInfos = chunkInfos;
    }
}
