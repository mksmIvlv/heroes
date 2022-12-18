using UnityEngine;

public class ManagerWhiteSkeleton : ManagerEnemy
{
    void Awake()
    {
        animatorEnemy = gameObject.GetComponent<Animator>();
        enemy = gameObject.GetComponent<Rigidbody2D>();
        
        damage = 5;
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

    #region Вспомогательные методы

    /// <summary>
    /// Метод слежения за игроком
    /// </summary>
    void TrackingHero() 
    {
        if (!isDeath) 
        {
            if(currentHero == null) // Если главного героя убили
            {
                isAttack = false;

                isRun = false;
            }
            else 
            {
                distanceHero = Vector2.Distance(gameObject.transform.position, currentHero.transform.position);

                // Если расстояние до главного героя меньше 2, поворачиваемся влево и задаем направление движения
                if (distanceHero < 2f && gameObject.transform.position.x > currentHero.transform.position.x)
                {
                    enemy.transform.localScale = new Vector2(-(localScaleX), localScaleY);

                    directionRun = new Vector2(-1f * speedRunning, enemy.velocity.y);
                }
                // Если расстояние до главного героя меньше 2, поворачиваемся вправо и задаем направление движения
                if (distanceHero < 2f && gameObject.transform.position.x < currentHero.transform.position.x)
                {
                    enemy.transform.localScale = new Vector2(localScaleX, localScaleY);

                    directionRun = new Vector2(1f * speedRunning, enemy.velocity.y);
                }
                // Если расстояние до главного героя больше 2, стоим на месте и не атакуем
                if (distanceHero > 2f)
                {
                    isRun = false;

                    isAttack = false;
                }
                // Если расстояние меньше 1, начинаем движение
                if (distanceHero < 1f && (gameObject.transform.position.x > currentHero.transform.position.x ||
                                         gameObject.transform.position.x < currentHero.transform.position.x))
                {
                    isRun = true;
                }
                // Если расстоние меньше 0.3, начинаем атаку, прекращаем движение
                if (distanceHero < 0.3f)
                {
                    isRun = false;

                    isAttack = true;
                }
            }
        }
    }

    #endregion
}
