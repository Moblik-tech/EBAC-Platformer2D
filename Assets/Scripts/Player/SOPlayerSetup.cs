using UnityEngine;
using DG.Tweening;

[CreateAssetMenu]
public class SOPlayerSetup : ScriptableObject
{
    public Animator playerAnimator;
    public SOString sOPlayerName;

    [Header("Speed Setup")]
    public float speed = 5f;
    public float speedRun = 25f;

    public Vector2 friction = new(0.1f, 0);

    public float forceJump = 3f;

    [Header("Animation Setup")]
    public float jumpScaleX = 0.7f;
    public float jumpScaleY = 1.5f;
    public float animationDuration = 0.3f;

    public Ease ease = Ease.OutBack;

    [Header("Animation player")]
    public float playerSwipeDuration = 0.1f;
    public string boolRun = "Run";
    public string triggerDeath = "Death";
}