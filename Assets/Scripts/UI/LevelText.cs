using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelText : MonoBehaviour
{
    public int level;
    public Text levelText;

    void Start() {
        level = GameObject.Find("Player").GetComponent<CharacterStats>().level;
        levelText.text = "Lv. " + level.ToString();
    }

    public void SetLevel(int newLevel) {
        level = newLevel;
        levelText.text = "Lv. " + level.ToString();
    }
}
