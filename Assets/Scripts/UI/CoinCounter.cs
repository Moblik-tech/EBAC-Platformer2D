using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    public TextMeshProUGUI coinCounterText;

    private void Start()
    {
        UpdateCoinCounter();
    }

    public void UpdateCoinCounter()
    {
        coinCounterText.text = $"x {ItemManager.Instance.coins}";
    }
}