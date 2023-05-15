using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk
{
    public readonly ChunkType[] Items;
    public readonly int PathItemIndex;

    public Chunk(int pathItemIndex, params ChunkType[] items)
    {
        if (items.Length != 3) throw new ArgumentException(nameof(items));

        Items = items;
        PathItemIndex = pathItemIndex;
    }

    public Chunk()
    {
        Items = new[] { ChunkType.Free, ChunkType.Free, ChunkType.Free };
        PathItemIndex = 1;
    }
}
