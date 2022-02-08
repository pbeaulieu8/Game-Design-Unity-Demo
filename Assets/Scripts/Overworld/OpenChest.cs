using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{   
    public Sprite itemSprite;
    public AudioSource openSound;

    //private int timeToAnimate = 5;
    
    //when player collides with chest, they get the item within
    //providing them with its stat benefits
    private void OnTriggerEnter2D(Collider2D other) {
        openSound.Play();

        ItemStats itemStats = this.gameObject.GetComponent<ItemStats>();

        int attackMod = itemStats.attack;
        int defenseMod = itemStats.defense;

        CharacterStats player_stats = GameObject.Find("Player").GetComponent<CharacterStats>();
        player_stats.SetAttackMod(attackMod);
        player_stats.SetDefenseMod(defenseMod);
        player_stats.UpdateStats();

        StartCoroutine("showItem");
    }

    IEnumerator showItem() {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = itemSprite;
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }
}
