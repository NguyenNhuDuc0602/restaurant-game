using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 6f;
    Rigidbody2D rb;
    Vector2 input;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal"); // Input Manager
        float v = Input.GetAxisRaw("Vertical");   // Input Manager
        input = new Vector2(h, v).normalized;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = input * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Duck duck = other.GetComponent<Duck>();
        if (duck != null)
        {
            duck.Catch();
        }
    }
}
