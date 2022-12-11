using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerBrownSkeleton : ManagerEnemy
{
    private Vector2 directionRun;
    private GameObject currentHero;
    private float distanceHero;

    void Awake()
    {
        animatorEnemy = gameObject.GetComponent<Animator>();
        enemy = gameObject.GetComponent<Rigidbody2D>();
        
        damage = 5;
        health = 10;
        speedRunning = 0.5f;

        GetLocalScale();
        SetGameObjectTracking();
    }

    void Start()
    {
        directionRun = new Vector2(1 * speedRunning, enemy.velocity.y);
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
    void RunEnemy() 
    {
        animatorEnemy.SetBool("isRun", isRun);

        if (isRun)
        {
            enemy.velocity = directionRun;
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
            distanceHero = Vector2.Distance(gameObject.transform.position, currentHero.transform.position);

            if (distanceHero < 2f && gameObject.transform.position.x > currentHero.transform.position.x)
            {
                enemy.transform.localScale = new Vector2(-(localScaleX), localScaleY);

                directionRun = new Vector2(-1f * speedRunning, enemy.velocity.y);

                isRun = true;
            }
            if (distanceHero < 2f && gameObject.transform.position.x < currentHero.transform.position.x)
            {
                enemy.transform.localScale = new Vector2(localScaleX, localScaleY);

                directionRun = new Vector2(1f * speedRunning, enemy.velocity.y);

                isRun = true;
            }
            if (distanceHero > 2f)
            {
                isRun = false;

                isAttack = false;
            }
            if (distanceHero < 0.3f)
            {
                isRun = false;

                isAttack = true;
            }
        }
    }

    /// <summary>
    /// Установка героя, за которым нужно следить
    /// </summary>
    void SetGameObjectTracking() 
    {
        var indexHero = PlayerPrefs.GetInt("currentHero");

        var allHero = GameObject.Find("AllHeroes");

        currentHero = allHero.transform.GetChild(indexHero).gameObject;

    }

    #endregion
}
