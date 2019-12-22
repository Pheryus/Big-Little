using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Zoom : MonoBehaviour {

    Transform colliders;

    float zoomValue, negativeValue;

    float zoomSpeed = 4f;

    List<Obstacle> obstacles = new List<Obstacle>();

    public Image zoomLine;

    public TutorialManager tutorialManager;

    private void Start() {
        zoomValue = negativeValue = 0;
    }

    public void SetColliders (Transform c) {
        colliders = c;
        obstacles = new List<Obstacle>();

        foreach (Transform t in colliders) { 
            if (t.GetComponent<Obstacle>() != null)
                obstacles.Add(t.GetComponent<Obstacle>());
        }

    }

    public void ResetZoom() {
        zoomValue = negativeValue = 0;
    }

    private void Update() {
        PlayerInputs();
        UpdateObjectsSize();
        UpdateZoomLine();
    }


    void PlayerInputs() {
        if (Game.state == GameState.gameover) {
            if (Input.anyKeyDown) {
                SceneManager.LoadScene("Game");
                Game.state = GameState.level;
                return;
            }
        }
        else if (Game.state != GameState.level)
            return;

        if (Input.GetKey(KeyCode.Z)) {
            ZoomIn();

        }
        else if (Input.GetKey(KeyCode.X)) {
            ZoomOut();
        }

        if (Input.GetKey(KeyCode.R)) {
            SceneManager.LoadScene("Game");
        }
    }

    void UpdateZoomLine() {
        zoomLine.fillAmount = (zoomValue + Game.maxZoomValue) / (Game.maxZoomValue * 2);
    }


    void UpdateObjectsSize() {
        int i = 0;
        foreach (Obstacle o in obstacles) {
            o.UpdateObject(zoomValue, negativeValue);
        }
    }

    void ZoomIn() {

        if (Game.onRequestAction && tutorialManager.CheckActionToDo(RequestAction.pressZ))
            tutorialManager.ActionDone();

        if (zoomValue >= Game.maxZoomValue)
            return;

        Debug.Log(zoomValue);

        zoomValue += Time.deltaTime * zoomSpeed;
        negativeValue -= Time.deltaTime * zoomSpeed;
        AudioManager.instance.PlaySE(SE.zoomIn, true);

    }

    void ZoomOut() {


        if (Game.onRequestAction && tutorialManager.CheckActionToDo(RequestAction.pressX))
            tutorialManager.ActionDone();

        if (zoomValue <= -Game.maxZoomValue)
            return;

        Debug.Log(zoomValue);



        zoomValue -= Time.deltaTime * zoomSpeed;
        negativeValue += Time.deltaTime * zoomSpeed;
        AudioManager.instance.PlaySE(SE.zoomOut, true);

    }
}
