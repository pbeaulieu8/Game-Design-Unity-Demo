using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyStats : MonoBehaviour
{
    public int attack;
    public int defense;

    public HealthBar healthBar;

    public int expYield;

    public int maxHP;
    public int currentHP {get; private set;}

    void Awake () {
        currentHP = maxHP;

        healthBar.SetMaxHealth(maxHP);
        healthBar.SetHealth(currentHP);
    }

    public void TakeDamage (int damage) {
        currentHP -= damage;
        healthBar.SetHealth(currentHP);
        if(currentHP <= 0) {
            GameObject.Find("Player").GetComponent<CharacterStats>().EXPGain(expYield);
            Destroy(this.gameObject);
        }
    } 
    

}
