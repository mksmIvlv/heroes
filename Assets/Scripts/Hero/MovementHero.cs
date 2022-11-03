using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHero : MonoBehaviour
{
    [Header("Игрок")]
    [SerializeField] private Rigidbody2D player;
    private float directionRunning;
    private float speedRunning;

    [Header("Вспомогательные поля")]
    [SerializeField] private Transform ObjectGround;
    [SerializeField] private LayerMask layerMask;
    private bool isGround;
    private float radiusIsGround;
    

    void Awake()
    {
        speedRunning = 3;
        radiusIsGround = 0.07f;
        player.GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        //player.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        RunPlayer();
        CheckGround();
    }

    #region Управление игроком
    private void RunPlayer()
    {
        

        if (isGround)
        {
            directionRunning = Input.GetAxis("Horizontal");

            if (directionRunning > 0)
            {
                player.transform.localScale = new Vector2(1f, 1f);
            }
            if (directionRunning < 0)
            {
                player.transform.localScale = new Vector2(-1f, 1f);
            }

            player.velocity = new Vector2(directionRunning * speedRunning, player.velocity.y);
        }
    }
    #endregion

    #region Вспомогательные методы для управления игроком
    private void CheckGround()
    {
        isGround = Physics2D.OverlapCircle(ObjectGround.position, radiusIsGround, layerMask);
    }
    #endregion
}
