using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public Rigidbody2D playerRigidbody;

    [Header("Speed Setup")]
    public float speed = 5f;
    public float speedRun = 25f;
    private float _currentSpeed;

    public Vector2 friction = new(0.1f, 0);

    public float forceJump = 3f;

    [Header("Animation Setup")]
    /*public float jumpScaleX = 0.7f;
    public float jumpScaleY = 1.5f;
    public float animationDuration = 0.3f;*/
    public SOFloat soJumpScaleY;
    public SOFloat soJumpScaleX;
    public SOFloat soAnimationDuration;

    public Ease ease = Ease.OutBack;

    [Header("Animation player")]
    public float playerSwipeDuration = 0.1f;
    public string boolRun = "Run";
    public string triggerDeath = "Death";
    public Animator animator;

    public HealthBase healthBase;

    private void Awake()
    {
        if (healthBase != null)
        {
            healthBase.OnKill += OnPlayerKill;
        }
    }

    void OnPlayerKill()
    {
        healthBase.OnKill -= OnPlayerKill;

        animator.SetTrigger(triggerDeath);
    }

    void Update()
    {
        HandleJump();
        HandleMovement();
    }

    void HandleMovement()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _currentSpeed = speedRun;
            animator.speed = 2;
        }
        else
        {
            _currentSpeed = speed;
            animator.speed = 1;
        }

        // Captação de input e aplicação de velocidade ao personagem
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetBool(boolRun, true);
            playerRigidbody.velocity = new Vector2(-_currentSpeed, playerRigidbody.velocity.y);

            if (playerRigidbody.transform.localScale.x != -1)
            {
                playerRigidbody.transform.DOScaleX(-1, playerSwipeDuration);
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool(boolRun, true);
            playerRigidbody.velocity = new Vector2(_currentSpeed, playerRigidbody.velocity.y);

            if (playerRigidbody.transform.localScale.x != 1)
            {
                playerRigidbody.transform.DOScaleX(1, playerSwipeDuration);
            }
        }
        else
        {
            animator.SetBool(boolRun, false);
        }

        // Aplicação de fricção ao personagem
        if (playerRigidbody.velocity.x > 0)
        {
            playerRigidbody.velocity += friction;
        }
        else if (playerRigidbody.velocity.x < 0)
        {
            playerRigidbody.velocity -= friction;
        }
    }

    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRigidbody.velocity = Vector2.up * forceJump;
            playerRigidbody.transform.localScale = Vector2.one;

            DOTween.Kill(playerRigidbody.transform);

            HandleScaleJump();
        }
    }

    void HandleScaleJump()
    {
        playerRigidbody.transform.DOScaleY(soJumpScaleY.value, soAnimationDuration.value).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        playerRigidbody.transform.DOScaleX(soJumpScaleX.value, soAnimationDuration.value).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}