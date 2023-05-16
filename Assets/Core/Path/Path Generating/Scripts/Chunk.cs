using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk
{
    public readonly ChunkItemType[] Items;
    public readonly int PathItemIndex;

    public Chunk(int pathItemIndex, params ChunkItemType[] items)
    {
        if (items.Length != 3) throw new ArgumentException(nameof(items));

        Items = items;
        PathItemIndex = pathItemIndex;
    }

    public Chunk()
    {
        Items = new[] { ChunkItemType.Free, ChunkItemType.Free, ChunkItemType.Free };
        PathItemIndex = 1;
    }
}
