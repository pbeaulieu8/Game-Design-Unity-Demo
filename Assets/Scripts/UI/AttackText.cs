using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackText : MonoBehaviour
{
    public int attack;
    public Text attackText;

    void Start() {
        attack = GameObject.Find("Player").GetComponent<CharacterStats>().attack;
        attackText.text = "ATK " + attack.ToString();
    }

    public void SetAttack(int newAttack) {
        attack = newAttack;
        attackText.text = "ATK " + attack.ToString();
    }
}
