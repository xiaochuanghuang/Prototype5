using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthSystem : MonoBehaviour
{
    private Image HealthBar;
    public float currentHealth;
    private float maxHealth = 100f;
    Move player;
    private void Start()
    {
        HealthBar = GetComponent<Image>();
        player = FindObjectOfType<Move>();
    }
    private void Update()
    {
        currentHealth = player.playerHealth;

        HealthBar.fillAmount = currentHealth / maxHealth;
    }

}
