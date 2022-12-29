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
        speedJump = 3;
        damage = 5;

        GetLocalScale();
    }

    void Start()
    {
        GetSpriteHero();
        CountValueFillArrow();
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

        yield return new WaitForSeconds(1.6f);

        isJump = true;
    }
}
