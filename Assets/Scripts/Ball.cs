using UnityEngine;

public class Ball : MonoBehaviour
{
    public Transform platform;
    private Rigidbody2D rb;

    [SerializeField] private float thrust = 600f; 
    [SerializeField] private float angleForce = 200f;
    [SerializeField] private float ballSpeed = 10f; 

    private bool inPlay = false;
    private Vector2 lastVelocity; // запоминаем скорость перед столкновением

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
        transform.SetParent(platform);
    }
    
    void Update()
    {
        if (inPlay)
        {
            lastVelocity = rb.linearVelocity;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !inPlay)
        {
            inPlay = true;
            rb.bodyType = RigidbodyType2D.Dynamic;
            transform.SetParent(null);
            
            float horizontalDifference = transform.position.x - platform.position.x;
            Vector2 launchDirection = new Vector2(horizontalDifference * angleForce, thrust);
            rb.AddForce(launchDirection);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            float horizontalDifference = transform.position.x - collision.transform.position.x;
            Vector2 bounceDirection = new Vector2(horizontalDifference, 1).normalized;
            rb.linearVelocity = bounceDirection * ballSpeed;
        }
        else
        {
            Vector2 reflectDir = Vector2.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
            // collision.contacts[0].normal - это направление поверхности, о которую мы ударились
            rb.linearVelocity = reflectDir * ballSpeed;
            
        }
    }
}
