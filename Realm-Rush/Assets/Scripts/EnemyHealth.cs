using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    public int MaxHitPoints { get { return maxHitPoints; } }

    [Tooltip("Adds amount of maxHitPoints when enemy dies.")]
    [SerializeField] int difficultyRamp = 1;
    int currentHitPoints = 0;
    public int CurrentHitPoints { get { return currentHitPoints; } }
    Enemy enemy;
    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }
    void Start()
    {
        enemy = GetComponent<Enemy>();
    }
    void OnParticleCollision(GameObject other)
    {
        ProccesHit();
    }

    void ProccesHit()
    {
        CurrentHitPointss();
        if (currentHitPoints <= 0)
        {
            enemy.RewardGold();
            maxHitPoints += difficultyRamp;
            gameObject.SetActive(false);
        }
    }

    public int CurrentHitPointss()
    {
        currentHitPoints--;
        return currentHitPoints;
    }
}

