using UnityEngine;

public class ItemCollectableCoin : ItemCollectableBase
{
    protected override void OnCollect()
    {
        ItemManager.Instance.AddCoins();
        base.OnCollect();
    }
}