using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReload : MonoBehaviour
{
    public GameObject objectToClone ;
    public Transform platform;
    private int ballsCount = 3;
    // public Collider2D coll;

    void Start()
    {
    }
    void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Ball"))
            {
                ballsCount -= 1;
                Debug.Log("Минус одна жизнь");
                Vector3 spanwPos = platform.position + new Vector3(0, 0.5f, 0);
                GameObject clone = Instantiate(objectToClone, spanwPos, transform.rotation);
                
                
                if (ballsCount == 0)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }
        }
}
