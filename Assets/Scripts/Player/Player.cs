using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rigidbody;

    public float speed = 5f;
    public float speedRun = 25f;
    private float _currentSpeed;

    public Vector2 friction = new(0.1f, 0);

    public float forceJump = 3f;

    void Update()
    {
        HandleJump();
        HandleMovement();
    }

    void HandleMovement()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            _currentSpeed = speedRun;
        }
        else
        {
            _currentSpeed = speed;
        }

        // Captação de input e aplicação de velocidade ao personagem
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidbody.velocity = new Vector2(-_currentSpeed, rigidbody.velocity.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidbody.velocity = new Vector2(_currentSpeed, rigidbody.velocity.y);
        }

        // Aplicação de fricção ao personagem
        if (rigidbody.velocity.x > 0)
        {
            rigidbody.velocity += friction;
        }
        else if (rigidbody.velocity.x < 0)
        {
            rigidbody.velocity -= friction;
        }
    }

    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.velocity = Vector2.up * forceJump;
        }
    }
}