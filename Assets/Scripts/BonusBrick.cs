using UnityEngine;

public class BonusBrick : MonoBehaviour
{
    public GameObject bonus;
        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ball"))
            {
                Destroy(gameObject);
                GameObject clone = Instantiate(bonus, transform.position, transform.rotation);
            }
        }
}
