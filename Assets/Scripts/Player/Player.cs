using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    [Header("Setup")]
    public Rigidbody2D playerRigidbody;
    //public Animator animator;
    public HealthBase healthBase;

    public SOPlayerSetup sOPlayerSetup;

    private float _currentSpeed;
    private Animator _currentPlayer;

    private void Awake()
    {
        if (healthBase != null)
        {
            healthBase.OnKill += OnPlayerKill;
        }

        _currentPlayer = Instantiate(sOPlayerSetup.playerAnimator, transform);
    }

    void OnPlayerKill()
    {
        healthBase.OnKill -= OnPlayerKill;

        _currentPlayer.SetTrigger(sOPlayerSetup.triggerDeath);
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
            _currentSpeed = sOPlayerSetup.speedRun;
            _currentPlayer.speed = 2;
        }
        else
        {
            _currentSpeed = sOPlayerSetup.speed;
            _currentPlayer.speed = 1;
        }

        // Captação de input e aplicação de velocidade ao personagem
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _currentPlayer.SetBool(sOPlayerSetup.boolRun, true);
            playerRigidbody.velocity = new Vector2(-_currentSpeed, playerRigidbody.velocity.y);

            if (playerRigidbody.transform.localScale.x != -1)
            {
                playerRigidbody.transform.DOScaleX(-1, sOPlayerSetup.playerSwipeDuration);
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            _currentPlayer.SetBool(sOPlayerSetup.boolRun, true);
            playerRigidbody.velocity = new Vector2(_currentSpeed, playerRigidbody.velocity.y);

            if (playerRigidbody.transform.localScale.x != 1)
            {
                playerRigidbody.transform.DOScaleX(1, sOPlayerSetup.playerSwipeDuration);
            }
        }
        else
        {
            _currentPlayer.SetBool(sOPlayerSetup.boolRun, false);
        }

        // Aplicação de fricção ao personagem
        if (playerRigidbody.velocity.x > 0)
        {
            playerRigidbody.velocity += sOPlayerSetup.friction;
        }
        else if (playerRigidbody.velocity.x < 0)
        {
            playerRigidbody.velocity -= sOPlayerSetup.friction;
        }
    }

    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRigidbody.velocity = Vector2.up * sOPlayerSetup.forceJump;
            playerRigidbody.transform.localScale = Vector2.one;

            DOTween.Kill(playerRigidbody.transform);

            HandleScaleJump();
        }
    }

    void HandleScaleJump()
    {
        playerRigidbody.transform.DOScaleY(sOPlayerSetup.jumpScaleY, sOPlayerSetup.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(sOPlayerSetup.ease);
        playerRigidbody.transform.DOScaleX(sOPlayerSetup.jumpScaleX, sOPlayerSetup.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(sOPlayerSetup.ease);
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}