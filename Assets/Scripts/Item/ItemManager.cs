using Moblik.Core.Singleton;

public class ItemManager : Singleton<ItemManager>
{
    public int coins;

    void Start()
    {
        Reset();
    }

    void Reset()
    {
        coins = 0;
    }

    public void AddCoins(int amount = 1)
    {
        coins += amount;
        UpdateUI();
    }

    void UpdateUI()
    {
        UIInGameManager.Instance.UpdateTextCoins(coins.ToString());
    }
}