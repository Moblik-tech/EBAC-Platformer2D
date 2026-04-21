using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rigidbody;

    public Vector2 velocity;
    public float speed;

    void Update()
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
    }
}