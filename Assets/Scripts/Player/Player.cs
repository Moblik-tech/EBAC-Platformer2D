using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rigidbody;

    public float speed = 5f;
    public float forceJump = 3f;
    public Vector2 friction = new(0.1f, 0);

    void Update()
    {
        HandleJump();
        HandleMovement();
    }

    void HandleMovement()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // opção 1
            //rigidbody.MovePosition(rigidbody.position - velocity * Time.deltaTime);

            // opção 2
            rigidbody.velocity = new Vector2(-speed, rigidbody.velocity.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            // opção 1
            //rigidbody.MovePosition(rigidbody.position + velocity * Time.deltaTime);

            // opção 2
            rigidbody.velocity = new Vector2(speed, rigidbody.velocity.y);
        }

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