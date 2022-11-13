using System.Collections;
using UnityEngine;

public class ManagerViking : ManagerHero
{
    void Awake()
    {
        GetLocalScale();
        hero = gameObject.GetComponent<Rigidbody2D>();
        animatorHero = gameObject.GetComponent<Animator>();
        health = 10;
        speedRunning = 1.5f;
        speedJump = 4;
        damage = 7;
    }
    void Start()
    {
        
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

    protected override IEnumerator CoroutineIsJump()
    {
        isJump = false;

        yield return new WaitForSeconds(2);

        isJump = true;
    }
}
