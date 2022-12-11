using System.Collections;
using UnityEngine;

public class ManagerViking : ManagerHero
{
    void Awake()
    {
        hero = gameObject.GetComponent<Rigidbody2D>();
        animatorHero = gameObject.GetComponent<Animator>();

        health = 100;
        armor = 100;
        speedRunning = 1.3f;
        speedJump = 4;
        damage = 10;

        GetLocalScale();
    }

    void Start()
    {
        GetSpriteHero();
    }

    void Update()
    {
        CheckGround();
        DeathHero();
    }

    void FixedUpdate()
    {
        RunHero();
        JumpHero();
        AttackHero();
    }

    /// <inheritdoc />
    protected override IEnumerator CoroutineIsJump()
    {
        isJump = false;

        yield return new WaitForSeconds(2);

        isJump = true;
    }
}
