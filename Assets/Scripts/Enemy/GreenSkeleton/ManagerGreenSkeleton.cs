using UnityEngine;

public class ManagerGreenSkeleton : ManagerEnemy
{
    [Header("Точки внутри которых передвигается Skeleton")]
    [SerializeField] private GameObject pointA;
    [SerializeField] private GameObject pointB;

    void Awake()
    {
        animatorEnemy = gameObject.GetComponent<Animator>();
        enemy = gameObject.GetComponent<Rigidbody2D>();
        
        damage = 3;
        health = 10;
        speedRunning = 0.5f;

        directionRun = new Vector2(1 * speedRunning, enemy.velocity.y);

        SetHero();
        GetLocalScale();
    }

    void FixedUpdate()
    {
        RunEnemy();
        DeathEnemy();
        AttackEnemy();
        TrackingHero();
    }

    #region Управление врагом

    /// <summary>
    /// Метод движения врага
    /// </summary>
    new void RunEnemy()
    {
        animatorEnemy.SetBool("isRun", isRun);

        if (isRun)
        {
            enemy.velocity = directionRun;

            // Движение к точке В
            if (enemy.transform.position.x > pointA.transform.position.x)
            {
                enemy.transform.localScale = new Vector2(-(localScaleX), localScaleY);

                directionRun = new Vector2(-1f * speedRunning, enemy.velocity.y);
            }
            // Движение к точке А
            if (enemy.transform.position.x < pointB.transform.position.x)
            {
                enemy.transform.localScale = new Vector2(localScaleX, localScaleY);

                directionRun = new Vector2(1f * speedRunning, enemy.velocity.y);
            }
        }
    }

    #endregion

    #region Вспомогательные методы

    /// <summary>
    /// Метод слежения за игроком
    /// </summary>
    void TrackingHero() 
    {
        if (!isDeath) 
        {
            if(currentHero == null) // Если уничтожили главного героя 
            {
                isAttack = false;

                isRun = false;
            }
            else 
            {
                distanceHero = Vector2.Distance(gameObject.transform.position, currentHero.transform.position);

                // Если расстояние до главного героя меньше 0.7, поворачиваемся влево и задаем направление движения, и начинаем атаку
                if (distanceHero < 0.7f && gameObject.transform.position.x > currentHero.transform.position.x)
                {
                    enemy.transform.localScale = new Vector2(-(localScaleX), localScaleY);

                    directionRun = new Vector2(-1f * speedRunning, enemy.velocity.y);

                    isRun = true;
                }
                // Если расстояние до главного героя меньше 0.7, поворачиваемся вправо и задаем направление движения, и начинаем атаку
                if (distanceHero < 0.7f && gameObject.transform.position.x < currentHero.transform.position.x)
                {
                    enemy.transform.localScale = new Vector2(localScaleX, localScaleY);

                    directionRun = new Vector2(1f * speedRunning, enemy.velocity.y);

                    isRun = true;
                }
                // Если расстоние до главного героя меньше 0.3, начинаем атаку
                if(distanceHero < 0.3f) 
                {
                    isAttack = true;

                    isRun = false;
                }
                // Если расстоние до главного героя больше 0.7, продолжаем движение
                if (distanceHero > 0.7f)
                {
                    isRun = true;

                    isAttack = false;
                }
            }
        }
    }

    /// <summary>
    /// Уничтожение врага и его точек, ивент на анимации
    /// </summary>
    private new void DestroyEnemy()
    {
        Destroy(pointA);

        Destroy(pointB);

        base.DestroyEnemy();
    }

    #endregion
}
