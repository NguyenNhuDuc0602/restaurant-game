using UnityEngine;

public class Duck : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float changeDirTime = 1.2f;

    Rigidbody2D rb;
    Vector2 dir;
    float timer;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        PickRandomDir();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= changeDirTime)
        {
            timer = 0f;
            PickRandomDir();
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = dir * moveSpeed;
    }

    void PickRandomDir()
    {
        dir = Random.insideUnitCircle.normalized;
    }

    public void Catch()
    {
        if (GameManager.I != null) GameManager.I.OnDuckCaught();
        Destroy(gameObject);
    }
}
