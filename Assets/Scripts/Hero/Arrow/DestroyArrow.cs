using UnityEngine;

public class DestroyArrow : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) 
        {
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }
    }
}
