using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class ManagerEnemy : MonoBehaviour
{
    public int Damage { get => damage; }

    //Поля относящиееся к врагу
    protected Rigidbody2D enemy;
    protected Animator animatorEnemy;
    protected int health;
    protected float speedRunning;
    protected int damage;

    //Вспомогательные поля
    [Header("Колладер для нанесения урона")]
    [SerializeField] protected Collider2D attackCollider;
    protected Vector2 directionRun;
    protected float distanceHero;
    protected bool isDeath = false;
    protected bool isRun = true;
    protected bool isAttack = false;
    protected GameObject currentHero;
    protected float localScaleX;
    protected float localScaleY;

    #region Методы Unity

    /// <summary>
    /// Метод получения урока
    /// </summary>
    /// <param name="collision">Коллайдер объекта</param>
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        // Урон от игрока
        if (collision.CompareTag("AttackHero"))
        {
            health -= collision.gameObject.GetComponentInParent<ManagerHero>().Damage;
        }

        // Урон от стрелы
        if (collision.CompareTag("Arrow"))
        {
            health -= 2;

            Destroy(collision.gameObject);
        }
    }

    #endregion

    #region Управление врагом

    /// <summary>
    /// Метод движения врага
    /// </summary>
    protected void RunEnemy()
    {
        animatorEnemy.SetBool("isRun", isRun);

        if (isRun)
        {
            enemy.velocity = directionRun;
        }
    }

    /// <summary>
    /// Метод ближнего боя
    /// </summary>
    protected void AttackEnemy()
    {
        animatorEnemy.SetBool("isAttack", isAttack);
    }

    /// <summary>
    /// Метод смерти
    /// </summary>
    protected void DeathEnemy()
    {
        animatorEnemy.SetBool("isDeath", isDeath);

        if (health <= 0)
        {
            isAttack = false;

            isRun = false;

            isDeath = true;
        }
    }

    #endregion

    #region Вспомогательные методы

    protected void SetHero()
    {
        var indexHero = PlayerPrefs.GetInt("currentHero");

        var allHeroes = GameObject.Find("AllHeroes");

        currentHero = allHeroes.transform.GetChild(indexHero).gameObject;
    }

    /// <summary>
    /// Получаем размер текущего игрока. Это нужно, когда спрайты разных размеров нужно привести к одному
    /// </summary>
    protected void GetLocalScale()
    {
        localScaleX = gameObject.transform.localScale.x;
        localScaleY = gameObject.transform.localScale.y;
    }

    /// <summary>
    /// Включение коллайдера для атаки, ивент на анимации
    /// </summary>
    protected void ActiveColliderDamage()
    {
        attackCollider.gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
    }

    /// <summary>
    /// Выключение коллайдера для атаки, ивент на анимации
    /// </summary>
    protected void DisableColliderDamage()
    {
        attackCollider.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
    }

    /// <summary>
    /// Уничтожение объекта, ивент на анимации сметри
    /// </summary>
    protected void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    #endregion
}