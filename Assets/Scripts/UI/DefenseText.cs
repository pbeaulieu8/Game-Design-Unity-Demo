using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenseText : MonoBehaviour
{
    public int defense;
    public Text defenseText;

    void Start() {
        defense = GameObject.Find("Player").GetComponent<CharacterStats>().defense;
        defenseText.text = "DEF " + defense.ToString();
    }

    public void SetDefense(int newDefense) {
        defense = newDefense;
        defenseText.text = "DEF " + defense.ToString();
    }
}
