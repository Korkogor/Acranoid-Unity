using System.Collections;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.UIElements;

public class Expand : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Transform platform = collision.gameObject.transform;
        if (collision.gameObject.CompareTag("Platform"))
        {
            platform.localScale += new Vector3(0.3f, 0, 0);
            StartCoroutine (PlatformExpand(2));
        }
        IEnumerator PlatformExpand(int value)
        {
            yield return new WaitForSeconds(value);
            platform.localScale -= new Vector3(0.3f, 0, 0);
            Destroy(gameObject);
            
        }
    }
}
