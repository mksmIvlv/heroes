using UnityEngine;

public class ManagerBrownSkeleton : ManagerEnemy
{
    void Awake()
    {
        animatorEnemy = gameObject.GetComponent<Animator>();
        enemy = gameObject.GetComponent<Rigidbody2D>();
        
        damage = 4;
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
            if(currentHero == null) // Если уничтожили главного героя  
            {
                isAttack = false;

                isRun = false;
            }
            else 
            {
                distanceHero = Vector2.Distance(gameObject.transform.position, currentHero.transform.position);

                // Если расстояние до главного героя меньше 2, поворачиваемся влево и задаем направление движения, и начинаем движение
                if (distanceHero < 2f && gameObject.transform.position.x > currentHero.transform.position.x)
                {
                    enemy.transform.localScale = new Vector2(-(localScaleX), localScaleY);

                    directionRun = new Vector2(-1f * speedRunning, enemy.velocity.y);

                    isRun = true;
                }
                // Если расстояние до главного героя меньше 2, поворачиваемся вправо и задаем направление движения, и начинаем движение
                if (distanceHero < 2f && gameObject.transform.position.x < currentHero.transform.position.x)
                {
                    enemy.transform.localScale = new Vector2(localScaleX, localScaleY);

                    directionRun = new Vector2(1f * speedRunning, enemy.velocity.y);

                    isRun = true;
                }
                // Если расстояние до главного героя больше 1.2, останавливаемся
                if (distanceHero > 1.2f)
                {
                    isRun = false;

                    isAttack = false;
                }
                // Если расстояние до главного героя меньше 0.3, начинаем атаку
                if (distanceHero < 0.3f)
                {
                    isRun = false;

                    isAttack = true;
                }
                // Если расстояние до главного героя больше 0.3 и меньше 1.2, начинаем движение
                if (distanceHero > 0.3f && distanceHero < 1.2f) 
                {
                    isRun = true;

                    isAttack = false;
                }
            }
            
        }
    }

    #endregion
}
