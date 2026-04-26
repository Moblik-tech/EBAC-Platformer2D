using UnityEngine;

public class HealthBase : MonoBehaviour
{
    public bool destroyOnKill = false;
    public float delayToKill = 2f;

    public int startLife = 10;
    private int _currentLife;

    private bool _isDead = false;

    public FlashColor flashColor;

    void Awake()
    {
        Init();
    }

    void Init()
    {
        _isDead = false;
        _currentLife = startLife;
    }

    public void Damage(int damage)
    {
        if (_isDead) return;

        _currentLife -= damage;

        if (_currentLife <= 0)
        {
            Kill();
        }

        if (flashColor != null)
        {
            flashColor.Flash();
        }
    }

    void Kill()
    {
        _isDead = true;

        if (destroyOnKill)
        {
            Destroy(gameObject, delayToKill);
        }
    }
}