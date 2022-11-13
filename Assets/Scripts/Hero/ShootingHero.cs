using UnityEngine;

[RequireComponent(typeof(GameObject))]
[RequireComponent(typeof(Transform))]
public class ShootingHero : MonoBehaviour
{
    [Header("Пуля/Стрела")]
    [SerializeField] private GameObject bullet;
    [Header("Точка создания пули")]
    [SerializeField] private Transform pointBullet;
    float speedBullet = 5f;

    /// <summary>
    /// Метод создании пули
    /// </summary>
    void CreateBullet() 
    {
        if (gameObject.transform.localScale.x >= 0) 
        {
            bullet.transform.localScale = new Vector2(1f, 1f); // Направление картинки, взависимости от того, куда смотрит игрок

            GameObject currentBullet = Instantiate(bullet, pointBullet.position, Quaternion.identity); // Создаем пулю

            Rigidbody2D currentBulletVelocity = currentBullet.gameObject.GetComponent<Rigidbody2D>(); // У созданной пули получает Rigibody

            currentBulletVelocity.velocity = new Vector2(speedBullet * 1f, currentBulletVelocity.velocity.y); // Придаем скорость данной пули
        }
        else 
        {
            bullet.transform.localScale = new Vector2(-1f, 1f);

            GameObject currentBullet = Instantiate(bullet, pointBullet.position, Quaternion.identity);

            Rigidbody2D currentBulletVelocity = currentBullet.gameObject.GetComponent<Rigidbody2D>();

            currentBulletVelocity.velocity = new Vector2(speedBullet * -1f, currentBulletVelocity.velocity.y);
        }
    }
}
