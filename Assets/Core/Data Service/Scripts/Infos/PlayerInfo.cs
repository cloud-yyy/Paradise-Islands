[System.Serializable]
public class PlayerInfo
{
    public int TotalCoins;
    public LevelInfo LevelInfo;
    public PlayerInfo(int totalCoins, LevelInfo levelInfo)
    {
        TotalCoins = totalCoins;
        LevelInfo = levelInfo;
    }
}
