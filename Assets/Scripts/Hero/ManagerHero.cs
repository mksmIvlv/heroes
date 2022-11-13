using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(GameObject))]
public class ManagerHero : MonoBehaviour
{
    public int Damage { get { return damage; } }

    [Header("Проверка игрока на земле")]
    [SerializeField] protected Transform objectContactGround;
    [SerializeField] protected LayerMask layerMaskGround;
    protected float radiusIsGround = 0.4f;

    //Поля относящиееся к игроку
    protected Rigidbody2D hero;
    protected Animator animatorHero;
    protected float health;
    protected float speedRunning;
    protected float speedJump;
    protected int damage;
    protected int ammunition;

    //Вспомогательные поля
    protected bool isJump = true;
    private bool isGround;
    private float directionRunning;
    private float localScaleX;
    private float localScaleY;

    #region Методы Unity
    /// <summary>
    /// Метод получения урока
    /// </summary>
    /// <param name="collision">Коллайдер врага</param>
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            //health -= collision.gameObject.GetComponent<ManagerEnemy>().Damage;
        }
    }
    #endregion

    #region Управление игроком (4 - обязательных, 2 - нет)
    /// <summary>
    /// Метод бега
    /// </summary>
    protected void RunHero()
    {
        if (isGround)
        {
            directionRunning = Input.GetAxis("Horizontal");

            animatorHero.SetBool("isRun", true);

            if (directionRunning > 0)
            {
                hero.transform.localScale = new Vector2(localScaleX, localScaleY);
            }
            if (directionRunning < 0)
            {
                hero.transform.localScale = new Vector2(-(localScaleX), localScaleY);
            }

            hero.velocity = new Vector2(directionRunning * speedRunning, hero.velocity.y);

            if(directionRunning == 0) 
            {
                animatorHero.SetBool("isRun", false);
            }
        }
    }

    /// <summary>
    /// Метод прыжка
    /// </summary>
    protected void JumpHero()
    {
        animatorHero.SetBool("isJump", !isGround);

        if (Input.GetKey(KeyCode.Space) && isGround && isJump)
        {
            hero.velocity = new Vector2(directionRunning * speedRunning, speedJump);

            StartCoroutine(CoroutineIsJump());
        }
    }

    /// <summary>
    /// Метод ближнего боя
    /// </summary>
    protected void AttackHero() 
    {
        if (Input.GetKey(KeyCode.E) && isGround) 
        {
            animatorHero.SetBool("isRun", false);

            animatorHero.SetBool("isAttack", Input.GetKey(KeyCode.E));
        }

        animatorHero.SetBool("isAttack", Input.GetKey(KeyCode.E));
    }

    /// <summary>
    /// Метод сметри героя
    /// </summary>
    protected void DeathHero() 
    {
        if (health <= 0 && isGround)
        {
            animatorHero.SetBool("isDeath", true);
        }
    }

    /// <summary>
    /// Метод кувырка
    /// </summary>
    protected void SomersaultHero() 
    {
        if (Input.GetKey(KeyCode.LeftControl) && isGround) 
        {
            animatorHero.SetBool("isRun", false);

            animatorHero.SetBool("isSomersault", Input.GetKey(KeyCode.LeftControl));
        }

        animatorHero.SetBool("isSomersault", Input.GetKey(KeyCode.LeftControl));
    }

    /// <summary>
    /// Метод выстрела
    /// </summary>
    protected virtual void ShootHero() 
    {
        if(Input.GetMouseButtonDown(0) && isGround) 
        {
            animatorHero.SetBool("isShoot", Input.GetMouseButtonDown(0));
        }

        animatorHero.SetBool("isShoot", Input.GetMouseButtonDown(0));
    }
    #endregion

    #region Вспомогательные методы для управления игроком

    /// <summary>
    /// Получаем размер текущего игрока. Это нужно, когда спрайты разных размеров нужно привести к одному
    /// </summary>
    protected virtual void GetLocalScale() 
    {
        localScaleX = gameObject.transform.localScale.x;
        localScaleY = gameObject.transform.localScale.y;
    }

    /// <summary>
    /// Запрещает спамить прыжок
    /// </summary>
    /// <returns></returns>
    protected virtual IEnumerator CoroutineIsJump() 
    {
        isJump = false;

        yield return new WaitForSeconds(1f);

        isJump = true;
    }


    /// <summary>
    /// Метод проверки нахождении игрока на земле
    /// </summary>
    protected void CheckGround()
    {
        isGround = Physics2D.OverlapCircle(objectContactGround.position, radiusIsGround, layerMaskGround);
    }

    /// <summary>
    /// Включение коллайдера для атаки, ивент на анимации
    /// </summary>
    protected void ActiveColliderDamage() 
    {
        gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
    }

    /// <summary>
    /// Выключение коллайдера для атаки, ивент на анимации
    /// </summary>
    protected void DisableColliderDamage() 
    {
        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
    }

    /// <summary>
    /// Уничтожение объекта, ивент на анимации сметри
    /// </summary>
    protected void DestroyHero()
    {
        Destroy(gameObject);
    }
    #endregion
}
