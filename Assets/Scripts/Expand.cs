using System.Collections;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.UIElements;

public class Expand : MonoBehaviour
{
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        var platform = collision.gameObject.GetComponent<PlatformController>();
        if (collision.gameObject.CompareTag("Platform"))
        {
            platform.PlatformExpandM();
            Destroy(gameObject);
        }
    }
}
