using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugChunkedPathSpawner : MonoBehaviour
{
    [SerializeField] private int _length = 30;
    [SerializeField] private Transform _startPoint;

    [Header("Items")]
    [SerializeField] private GameObject _barCounter;
    [SerializeField] private GameObject _lowObstacle;
    [SerializeField] private GameObject _highObstacle;

    private ChunkedPathGenerator _generator;

    private void Start()
    {
        _generator = GetComponent<ChunkedPathGenerator>();
        var path = _generator.GeneratePath(_length);

        DrawInConsole(path);
        Spawn(path);
    }

    private void DrawInConsole(List<Chunk> path)
    {
        foreach (var chunk in path)
        {
            string line = "|";

            for (int i = 0; i < chunk.Items.Length; i++)
            {
                if (i == chunk.PathItemIndex)
                {
                    line += " P |";
                    continue;
                }

                switch (chunk.Items[i])
                {
                    case ChunkType.Free:
                        line += " _ |";
                        break;
                    case ChunkType.LowObstacle:
                        line += " L |";
                        break;
                    case ChunkType.HighObstacle:
                        line += " H |";
                        break;
                    case ChunkType.BarCounter:
                        line += " B |";
                        break;
                }
            }

            Debug.Log(line);
        }
    }

    private void Spawn(List<Chunk> chunks)
    {
        var objects = new Dictionary<ChunkType, GameObject>()
        {
            { ChunkType.Free, null },
            { ChunkType.LowObstacle, _lowObstacle },
            { ChunkType.HighObstacle, _highObstacle },
            { ChunkType.BarCounter, _barCounter }
        };

        for (int i = 0; i < chunks.Count; i++)
        {
            for (int j = 0; j < chunks[i].Items.Length; j ++)
            {
                if (objects[chunks[i].Items[j]] == null) continue;

                Instantiate(objects[chunks[i].Items[j]], _startPoint.position + new Vector3(3.5f * -i, 0f, 3.5f * (j - 1)), Quaternion.identity);
            }
        }
    }
}
