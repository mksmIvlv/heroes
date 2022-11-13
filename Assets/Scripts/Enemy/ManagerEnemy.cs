using UnityEngine;

public class ManagerEnemy : MonoBehaviour
{
    public int Damage { get => damage; }
    int damage = 5;
    int health = 8;

    /// <summary>
    /// Метод получения урока
    /// </summary>
    /// <param name="collision">Коллайдер врага</param>
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hero"))
        {
            health -= collision.gameObject.GetComponent<ManagerHero>().Damage;

            Debug.Log(health);
        }
    }
}