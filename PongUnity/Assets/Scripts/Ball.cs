using UnityEngine;


public class Ball : MonoBehaviour
{
    public float speed = 30;

    void Start()
    {
        //Initial Velocity
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        // Note: 'col' holds the collision information. If the
        // Ball collided with a racket, then:
        //   col.gameObject is the racket
        //   col.transform.position is the racket's position
        //   col.collider is the racket's collider

        // Hit the left Raclet?
        if(col.gameObject.name == "RacketLeft")
        {
            // Calculate hit factor
            float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);

            // Calculate direction? make Length = 1 via .normalized
            Vector2 dir = new Vector2(1, y).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        // Hit the right Raclet?
        if (col.gameObject.name == "Racketright")
        {
            // Calculate hit factor
            float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);

            // Calculate direction? make Length = 1 via .normalized
            Vector2 dir = new Vector2(-1, y).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

    }

    private float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketHight)
    {
        // ascii art:
        // ||  1 <- at the top of the racket
        // ||
        // ||  0 <- at the middle of the racket
        // ||
        // || -1 <- at the bottom of the racket
        return (ballPos.y - racketPos.y) / racketHight;
    }
}
