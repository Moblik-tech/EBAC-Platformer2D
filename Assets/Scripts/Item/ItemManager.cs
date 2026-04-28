using Moblik.Core.Singleton;
using TMPro;

public class ItemManager : Singleton<ItemManager>
{
    public int coins;
    public TextMeshProUGUI uiTextCoins;

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
        uiTextCoins.text = "x " + coins.ToString();
    }
}