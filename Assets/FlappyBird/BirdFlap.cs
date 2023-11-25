using UnityEngine;

public class BirdFlap : MonoBehaviour
{
    [SerializeField] float velocity;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            rb.velocity = Vector2.up * velocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
            Destroy(gameObject);
    }
}
