using UnityEngine;

public class ItemCollectableBase : MonoBehaviour
{
    public string compareTag = "Player";

    private CoinCounter _coinCounter;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(compareTag))
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {
        OnCollect();
        gameObject.SetActive(false);
    }

    protected virtual void OnCollect()
    {
        _coinCounter = FindFirstObjectByType<CoinCounter>();
        _coinCounter.UpdateCoinCounter();
    }
}