using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public abstract class ManagerHero : MonoBehaviour
{
    public int Damage { get { return damage; } }

    [Header("Проверка игрока на земле")]
    [SerializeField] protected Transform objectContactGround;
    [SerializeField] protected LayerMask layerMaskGround;
    [SerializeField] protected AudioSource musicRun;
    [SerializeField] protected AudioSource musicJump;
    [SerializeField] protected AudioSource musicAttack;
    [SerializeField] protected Collider2D attackCollider;

    [Header("Спрайты для канваса")]
    [SerializeField] protected GameObject gameObjectHealth;
    protected Image fillHealth;
    [SerializeField] protected GameObject gameObjectArmor;
    protected Image fillArmor;

    //Поля относящиееся к игроку
    protected Rigidbody2D hero;
    protected Animator animatorHero;
    protected float health;
    protected float armor;
    protected float speedRunning;
    protected float speedJump;
    protected int damage;
    protected int ammunition;
    protected float radiusIsGround = 0.4f;

    //Вспомогательные поля
    protected Transform[] gameObjectLive;
    protected bool isJump = true;
    protected bool isGround;
    protected bool isShooting = true;
    protected bool isDeath = false;
    private float directionRunning;
    private float localScaleX;
    private float localScaleY;

    #region Методы Unity

    /// <summary>
    /// Метод получения урока
    /// </summary>
    /// <param name="collision">Коллайдер врага</param>
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("AttackEnemy"))
        {
            var damageEnemy = 5f;//collision.gameObject.GetComponent<ManagerEnemy>().Damage;

            if (armor > 0) 
            {
                fillArmor.fillAmount -= (0.02f * damageEnemy);

                armor -= (2f * damageEnemy);
            }
            else 
            {
                fillHealth.fillAmount -= (0.01f * damageEnemy);

                health -= damageEnemy;
            }
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

            animatorHero.SetBool("isRun", !isDeath);

            if (directionRunning > 0 && !isDeath)
            {
                hero.transform.localScale = new Vector2(localScaleX, localScaleY);
            }
            if (directionRunning < 0 && !isDeath)
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
        animatorHero.SetBool("isJump", (Input.GetKey(KeyCode.Space) && isGround && isJump));

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
            isDeath = true;

            gameObject.GetComponent<Rigidbody2D>().simulated = false;

            animatorHero.SetBool("isDeath", isDeath);
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
        if(Input.GetKey(KeyCode.F) && isGround) 
        {
            animatorHero.SetBool("isShoot", (Input.GetKey(KeyCode.F) && isShooting));
        }

        animatorHero.SetBool("isShoot", (Input.GetKey(KeyCode.F) && isShooting));
    }

    #endregion

    #region Вспомогательные методы

    /// <summary>
    /// Получаем размер текущего игрока. Это нужно, когда спрайты разных размеров нужно привести к одному
    /// </summary>
    protected virtual void GetLocalScale() 
    {
        localScaleX = gameObject.transform.localScale.x;
        localScaleY = gameObject.transform.localScale.y;
    }

    /// <summary>
    /// Метод активации спрайтов - жизни
    /// </summary>
    protected virtual void GetSpriteHero()
    {
        gameObjectHealth.SetActive(true);

        fillHealth = gameObjectHealth.transform.GetChild(1).gameObject.GetComponent<Image>();

        fillHealth.fillAmount = 1;

        gameObjectArmor.SetActive(true);

        fillArmor = gameObjectArmor.transform.GetChild(1).gameObject.GetComponent<Image>();

        fillArmor.fillAmount = 1;
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
    protected void DestroyHero()
    {
        Destroy(gameObject);
    }

    #endregion

    #region Методы для включения звука. Ивенты на анимации

    /// <summary>
    /// Воспроизведение бега
    /// </summary>
    void RunHeroPlayMusic() 
    {
        if (isGround) 
        {
            musicRun.Play();
        }
        
    }

    /// <summary>
    /// Воспроизведение прыжка
    /// </summary>
    void JumpHeroPlayMusic() 
    {
        musicJump.Play();
    }

    /// <summary>
    /// Воспроизведение звука атаки 
    /// </summary>
    void AttackHeroPlayMusic() 
    {
        musicAttack.Play();
    }

    /// <summary>
    /// Воспроизведение звука стрельбы. Классы наследники должные переопределить
    /// </summary>
    protected virtual void ShootHeroPlayMusic() { }

    #endregion
}
