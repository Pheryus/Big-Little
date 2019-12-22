using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialManager : MonoBehaviour {

    public TextMeshProUGUI textMesh;

    public static TutorialManager instance;

    RequestAction actionToDo;

    private void Start() {
        instance = this;
    }


    public void ShowMsg(string msg) {
        textMesh.text = msg;
        textMesh.gameObject.SetActive(true);
    }

    public void FreezeGame(RequestAction a) {
        Game.onRequestAction = true;
        actionToDo = a;
        Time.timeScale = 0;
    }

    public bool CheckActionToDo (RequestAction a) {
        return actionToDo == a;
    }

    public void ActionDone() {
        Time.timeScale = 1;
        Game.onRequestAction = false;
        actionToDo = RequestAction.none;
        textMesh.gameObject.SetActive(false);
        textMesh.text = string.Empty;
    }
}
