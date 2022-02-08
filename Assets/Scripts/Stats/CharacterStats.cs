using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour
{
    public int baseAttack;
    public int baseDefense;
    private int attackMod;
    private int defenseMod;

    public int attack {get; private set;}
    public int defense {get; private set;}

    public int maxHP;
    public int currentHP {get; private set;}

    public int level = 1;
    private int expToLevel = 10;
    public int exp = 0;

    public HealthBar healthBar;
    public EXPBar expBar;

    public AudioSource hitSound;

    void Awake () {
        attack = baseAttack + attackMod;
        defense = baseDefense + defenseMod;
        currentHP = maxHP;

        healthBar.SetMaxHealth(maxHP);
        healthBar.SetHealth(currentHP);

        expBar.SetMaxValue(expToLevel);
        expBar.SetCurrentValue(exp);
    }

    //called when base stats or stat mods are changed
    public void UpdateStats() {
        attack = baseAttack + attackMod;
        defense = baseDefense + defenseMod;
        
        //update UI stat values
        GameObject.Find("Attack").GetComponent<AttackText>().SetAttack(attack);
        GameObject.Find("Defense").GetComponent<DefenseText>().SetDefense(defense);
    }

    public void TakeDamage (int damage) {
        hitSound.Play();
        damage -= defense;
        currentHP -= damage;
        
        if(currentHP <= 0) {
            SceneManager.LoadScene("Game Over");
        }

        healthBar.SetHealth(currentHP);
    }

    public void LevelUp() {
        //update player stats
        level += 1;
        baseAttack += 2;
        baseDefense += 0;
        maxHP += 10;
        currentHP = maxHP;
        UpdateStats();
        exp = exp - expToLevel;
        expToLevel = level * 10;

        //update hp bar
        healthBar.SetMaxHealth(maxHP);
        healthBar.SetHealth(currentHP);

        //update exp bar
        expBar.SetMaxValue(expToLevel);

        //update ui values
        GameObject.Find("Level").GetComponent<LevelText>().SetLevel(level);
        GameObject.Find("Attack").GetComponent<AttackText>().SetAttack(attack);
        GameObject.Find("Defense").GetComponent<DefenseText>().SetDefense(defense);
    }  

    public void EXPGain(int expVal) {
        exp += expVal;
        if(exp >= expToLevel) {
            LevelUp();
        }
        expBar.SetCurrentValue(exp);
    }

    public void SetAttackMod(int mod) {
        if(mod > attackMod)
            attackMod = mod;
    }

    public void SetDefenseMod(int mod) {
        if(mod > defenseMod)
            defenseMod = mod;
    }
}
