using Moblik.Core.Singleton;

public class ItemManager : Singleton<ItemManager>
{
    public SOInt coins;

    void Start()
    {
        Reset();
    }

    void Reset()
    {
        coins.value = 0;
    }

    public void AddCoins(int amount = 1)
    {
        coins.value += amount;
        UpdateUI();
    }

    void UpdateUI()
    {
        //UIInGameManager.Instance.UpdateTextCoins(coins.value.ToString());
    }
}