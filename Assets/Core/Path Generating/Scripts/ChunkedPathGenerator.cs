using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkedPathGenerator : MonoBehaviour
{
    [SerializeField] private int _length;

    [Header("Global Probabilities")]
    [SerializeField] private float _pathTurningProbability = 0.85f;

    [Header("Path Creation Probabilities")]
    [SerializeField] private float _onPathLowObstacleCreatingProbability = 0.2f;

    [Header("Non-path Creation Probabilities")]
    [SerializeField] private float _lowObstacleCreatingProbability = 0.3f;
    [SerializeField] private float _highObstacleCreatingProbability = 0.5f;


    //[Header("Enviroment Creation Probabilities")]

    public List<Chunk> GeneratePath(int length)
    {
        if (length < 0) throw new System.ArgumentException(nameof(length));

        var path = new List<Chunk>(length + 3);
        path.Add(new Chunk());

        for (int i = 0; i < length; i++)
            path.Add(CreateNextChunk(path[i]));

        path.Add(new Chunk(1, ChunkType.HighObstacle, ChunkType.Free, ChunkType.HighObstacle));
        path.Add(new Chunk(1, ChunkType.HighObstacle, ChunkType.Free, ChunkType.HighObstacle));

        path.Add(new Chunk(1, ChunkType.Free, ChunkType.BarCounter, ChunkType.Free));

        return path;
    }

    private Chunk CreateNextChunk(Chunk chunk)
    {
        var items = new ChunkType[chunk.Items.Length];
        var pathIndex = chunk.PathItemIndex;

        var newPathIndex = CheckProbability(_pathTurningProbability) ? SwithPathIndex(pathIndex, items.Length - 1) : pathIndex;

        for (int i = 0; i < items.Length; i++)
        {
            if (i == pathIndex)
            {
                items[i] = CreateRandomPathItem(chunk);
                continue;
            }
            if (i == newPathIndex)
            {
                items[i] = ChunkType.Free;
                continue;
            }
            items[i] = CreateRandomNonPathItem();
        }
        return new Chunk(newPathIndex, items);
    }

    private int SwithPathIndex(int currentIndex, int maxIndex)
    {
        if (currentIndex == 0) return currentIndex + 1;
        else if (currentIndex == maxIndex) return currentIndex - 1;
        else return CheckProbability(0.5f) ? currentIndex + 1 : currentIndex - 1;
    }

    private ChunkType CreateRandomPathItem(Chunk previos)
    {
        if (previos.Items[previos.PathItemIndex] == ChunkType.LowObstacle)
            return ChunkType.Free;

        return CheckProbability(_onPathLowObstacleCreatingProbability) ? ChunkType.LowObstacle : ChunkType.Free;
    }

    private ChunkType CreateRandomNonPathItem()
    {
        var probability = Random.Range(0f, 1f);

        if (probability <= _lowObstacleCreatingProbability)
            return ChunkType.LowObstacle;
        else if (probability <= _lowObstacleCreatingProbability + _highObstacleCreatingProbability)
            return ChunkType.HighObstacle;
        return ChunkType.Free;
    }

    private bool CheckProbability(float probability) => Random.Range(0f, 1f) <= probability;
}
