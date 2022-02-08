using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossStats : MonoBehaviour
{
    public int attack;
    public int defense;

    public int maxHP;
    public int currentHP {get; private set;}

    public HealthBar healthBar;

    void Awake () {
        currentHP = maxHP;

        healthBar.SetMaxHealth(maxHP);
        healthBar.SetHealth(currentHP);
    }

    public void TakeDamage (int damage) {
        currentHP -= damage;
        healthBar.SetHealth(currentHP);
        if(currentHP <= 0) {
            SceneManager.LoadScene("Win Screen");
            Destroy(this.gameObject);
        }
    } 
}
