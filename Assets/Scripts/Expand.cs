using System.Collections;
using UnityEngine;

public class Expand : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Transform platform = collision.gameObject.transform;
        Transform  normalPlatform = collision.gameObject.transform;
        if (collision.gameObject.CompareTag("Platform"))
        {
            platform.localScale += new Vector3(0.3f, 0, 0);
            StartCoroutine (PlatformExpand(2));
            Destroy(gameObject);
        }
        IEnumerator PlatformExpand(int value)
        {
            yield return new WaitForSeconds(value);
            platform.localScale = normalPlatform.localScale;
        }
    }
}
