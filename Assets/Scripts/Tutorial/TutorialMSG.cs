using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TutorialMSG : MonoBehaviour {

    public string msg;

    float yPos = -1.76f;

    bool showMsg = false;

    public RequestAction action;

    private void Update() {
        if (transform.position.y <= yPos && !showMsg && Game.tutorialActive) {
            showMsg = true;
            TutorialManager.instance.ShowMsg(msg);

            if (action != RequestAction.none) {
                TutorialManager.instance.FreezeGame(action);
            }
        }
    }

}
