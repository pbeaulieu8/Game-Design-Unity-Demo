using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBattle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        CharacterStats player_stats = GameObject.Find("Player").GetComponent<CharacterStats>();
        BossStats boss_stats = this.gameObject.GetComponent<BossStats>();
    
        int damage_inflict = boss_stats.attack;
        int damage_receive = player_stats.attack;
        
        player_stats.TakeDamage(damage_inflict);
        boss_stats.TakeDamage(damage_receive);
    }
}
