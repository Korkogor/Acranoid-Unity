using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public float speed = 1f;
    private float horizontal;
    private Rigidbody2D rb;
    public Transform saveScale;
    
    
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
       saveScale = GetComponent<Transform>();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        
    }

    void FixedUpdate()
    {
        
        rb.linearVelocity = new Vector2(horizontal * speed, 0);
    }
    

}
