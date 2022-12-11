using UnityEngine;
using UnityEngine.UI;

public class ManagerArcher : ManagerHero
{
    [SerializeField] private AudioSource musicShoot;
    [SerializeField] protected GameObject gameObjectArrow;
    protected Image fillArrow;
    private float valueFillArrow;
    

    void Awake()
    {
        hero = gameObject.GetComponent<Rigidbody2D>();
        animatorHero = gameObject.GetComponent<Animator>();

        health = 100;
        armor = 100;
        speedRunning = 1.5f;
        speedJump = 3.5f;
        damage = 10;
        ammunition = 5;
        
        GetLocalScale();
       
        CountValueFillArrow();
    }

    void Start()
    {
        GetSpriteHero();
    }

    void Update()
    {
        CheckGround();
        SomersaultHero();
        ShootHero();
        DeathHero();
    }

    void FixedUpdate()
    {
        RunHero();
        JumpHero();
        AttackHero();
    }

    /// <inheritdoc />
    protected override void ShootHeroPlayMusic()
    {
        musicShoot.Play();
    }

    /// <summary>
    /// Метод активации спрайтов - жизни
    /// </summary>
    protected new void GetSpriteHero()
    {
        gameObjectArrow.SetActive(true);

        fillArrow = gameObjectArrow.transform.GetChild(1).gameObject.GetComponent<Image>();

        fillArrow.fillAmount = 1;

        base.GetSpriteHero();
    }

    /// <summary>
    /// Уменьшение количества стрел и заполнение спрайта, ивент на анимации
    /// </summary>
    private void SpriteFillShootHero() 
    {
        if(ammunition > 1) 
        {
            ammunition -= 1;

            fillArrow.fillAmount -= valueFillArrow;
        }
        else 
        {
            ammunition -= 1;

            fillArrow.fillAmount -= valueFillArrow;

            isShooting = false;
        }
    }

    /// <summary>
    /// Метод вычисление, какое количество нужно отнимать от спрайта стрел в зависимости от аммуниции героя
    /// </summary>
    private void CountValueFillArrow() 
    {
        valueFillArrow = ((1 * 100) / ammunition) * 0.01f;
    }
}
