using UnityEngine;

[RequireComponent(typeof(ShootingHero))]
public class ManagerArcher : ManagerHero
{
    void Awake()
    {
        GetLocalScale();
        hero = gameObject.GetComponent<Rigidbody2D>();
        animatorHero = gameObject.GetComponent<Animator>();
        health = 100;
        speedRunning = 3;
        speedJump = 3.5f;
        damage = 5;
        ammunition = 20;
    }

    void Start()
    {
        
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
}
