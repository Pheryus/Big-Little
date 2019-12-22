using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour {
    public GameObject gameOverUI;

    public TextMeshProUGUI deathTexts;

    public void ShowRestartMsg() {
        gameOverUI.SetActive(true);
    }

    private void Update() {
        deathTexts.text = "Deaths: " + Game.deaths.ToString();
    }

}
