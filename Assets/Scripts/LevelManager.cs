using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] levelPrefabs;


    GameObject actualLevel;

    GameObject endLevel;

    public Zoom zoom;


    private void Start() {
        AudioManager.instance.PlayBGM(BGMEnum.game);

        Invoke("CreateLevel", 0.5f);
    }

    void CreateLevel() {
        Game.state = GameState.level;
        actualLevel = Instantiate(levelPrefabs[Game.level]);
        endLevel = GameObject.FindGameObjectWithTag("EndLevel");
        zoom.SetColliders(actualLevel.transform);
    }


    private void Update() {
        if (endLevel != null && endLevel.transform.position.y < -5) {
            endLevel = null;
            actualLevel.SetActive(false);
            Game.level++;
            CreateLevel();
            zoom.ResetZoom();
        }
    }

}
