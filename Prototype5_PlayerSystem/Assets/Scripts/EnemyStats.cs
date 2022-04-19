using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    // Start is called before the first frame update
    public int healthLevel = 10;
    public int currentHealth;
    public int maxHealth;
    void Start()
    {
        maxHealth = SetMaxHealthFromHealthLevel();
        currentHealth = maxHealth;
    }

    private void Awake()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    int SetMaxHealthFromHealthLevel()
    {
        maxHealth = healthLevel * 10;
        return maxHealth;

    }
}
