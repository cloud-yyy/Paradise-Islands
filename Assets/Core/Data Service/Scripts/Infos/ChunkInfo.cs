[System.Serializable]
public class ChunkInfo
{
    public ChunkItemType[] Items;
    public int PathItemIndex;

    public ChunkInfo(Chunk chunk)
    {
        Items = chunk.Items;
        PathItemIndex = chunk.PathItemIndex;
    }

    public Chunk CreateChunk()
    {
        return new Chunk(PathItemIndex, Items);
    }
}
