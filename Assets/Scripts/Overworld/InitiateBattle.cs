using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitiateBattle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        CharacterStats player_stats = GameObject.Find("Player").GetComponent<CharacterStats>();
        EnemyStats enemy_stats = this.gameObject.GetComponent<EnemyStats>();
    
        int damage_inflict = enemy_stats.attack;
        int damage_receive = player_stats.attack;
        
        player_stats.TakeDamage(damage_inflict);
        enemy_stats.TakeDamage(damage_receive);
    }
}
