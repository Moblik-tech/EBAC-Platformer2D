using UnityEngine;

public class ItemCollectableBase : MonoBehaviour
{
    public string compareTag = "Player";
    public ParticleSystem particleSystem;
    public float timeToHide = 5f;
    public GameObject graphicItem;

    //void Awake()
    //{
    //    if (particleSystem != null)
    //    {
    //        particleSystem.transform.SetParent(null);
    //    }
    //}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(compareTag))
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {
        if (graphicItem != null)
        {
            graphicItem.SetActive(false);
        }

        Invoke(nameof(HideObject), timeToHide);
        OnCollect();
    }

    void HideObject()
    {
        gameObject.SetActive(false);
    }

    protected virtual void OnCollect()
    {
        if (particleSystem != null)
        {
            particleSystem.Play();
        }
    }
}