using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHero : MonoBehaviour
{
    [Header("Игрок")]
    [SerializeField] private Animator playerAnimation;
    void Awake()
    {
        playerAnimation = GetComponent<Animator>();
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        
    }
}
