using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkedPathGenerator : MonoBehaviour
{
    [SerializeField] private float _pathTurningProbability = 0.4f;
    [SerializeField] private float _lowObstacleCreatingProbability = 0.25f;

    [SerializeField] private int _length;

    private void Start()
    {
        // var path = GeneratePath(_length);
        // var chunks = new List<string>();

        // foreach (var chunk in path)
        // {
        //     string line = string.Empty;
        //     foreach (var item in chunk.Items)
        //     {
        //         switch (item)
        //         {
        //             case ChunkType.Free:
        //                 line += "  ";
        //                 break;
        //             case ChunkType.LowObstacle:
        //                 line += "L ";
        //                 break;
        //             case ChunkType.HighObstacle:
        //                 line += "H ";
        //                 break;
        //             case ChunkType.BarCounter:
        //                 line += "B ";
        //                 break;
        //         }
        //     }
        //     Debug.Log(line);
        // }
    }

    public List<Chunk> GeneratePath(int length)
    {
        if (length < 0) throw new System.ArgumentException(nameof(length));

        var path = new List<Chunk>(length + 3);
        path.Add(new Chunk());

        for (int i = 0; i < length; i++)
            path.Add(CreateNextChunk(path[i]));

        path.Add(new Chunk());
        path.Add(new Chunk(1, ChunkType.Free, ChunkType.BarCounter, ChunkType.Free));

        return path;
    }

    private Chunk CreateNextChunk(Chunk chunk)
    {
        var items = new ChunkType[3];
        var pathIndex = chunk.PathItemIndex;

        var сhangePathIndex = Random.Range(0f, 1f) <= _pathTurningProbability;
        var newPathIndex = сhangePathIndex ? SwithPathIndex(pathIndex, items.Length - 1) : pathIndex;

        for (int i = 0; i < items.Length; i++)
        {
            if (i == pathIndex)
            {
                items[i] = Random.Range(0f, 1f) <= _lowObstacleCreatingProbability ? ChunkType.LowObstacle : ChunkType.Free;
                continue;
            }

            if (i == newPathIndex)
            {
                items[i] = ChunkType.Free;
                continue;
            }

            items[i] = (ChunkType)Random.Range((int)ChunkType.Free, (int)ChunkType.HighObstacle + 1);
        }

        return new Chunk(pathIndex, items);
    }

    private int SwithPathIndex(int currentIndex, int maxIndex)
    {
        if (currentIndex == 0) return currentIndex + 1;
        else if (currentIndex == maxIndex) return currentIndex - 1;
        else return Random.Range(-1f, 1f) >= 0 ? currentIndex + 1 : currentIndex - 1;
    }
}
