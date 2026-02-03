using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public float speed = 1f;
    private float horizontal;
    private Rigidbody2D rb;
    public Transform saveScale;
    Vector3 originalScale;
    
    
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
       saveScale = GetComponent<Transform>();
       originalScale = new Vector3(0.7F, 0.7F, 0.7F);
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        
    }

    void FixedUpdate()
    {
        
        rb.linearVelocity = new Vector2(horizontal * speed, 0);
    }

    public void PlatformExpandM()
    {
        transform.localScale += new Vector3(0.3f, 0, 0);
        StartCoroutine(PlatformExpand(2f));
        
    }

    IEnumerator<WaitForSeconds> PlatformExpand(float value)
    {
        yield return new WaitForSeconds(value);
        transform.localScale = originalScale;
    }

}

