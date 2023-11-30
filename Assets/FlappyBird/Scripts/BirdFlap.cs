using UnityEngine;

public class BirdFlap : MonoBehaviour
{
    [SerializeField] float velocity;
    private AudioSource flapSound;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        flapSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0)
        {
            flapSound.Play();
            rb.velocity = Vector2.up * velocity;            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
            Destroy(gameObject);
    }
}
