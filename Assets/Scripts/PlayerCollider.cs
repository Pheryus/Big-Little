using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollider : MonoBehaviour {

    BoxCollider2D bc;

    MeshRenderer mesh;

    public ShakeBehaviour cameraShake;

    public GameObject deathParticle;

    public Signal gameOverSignal;

    private void Start() {
        bc = GetComponent<BoxCollider2D>();
        mesh = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag(Game.obstacleTag)) {
            cameraShake.TriggerHardShake();
            GameObject go = Instantiate(deathParticle, transform.position, Quaternion.identity);
            Destroy(go, .5f);
            AudioManager.instance.PlaySE(SE.breakPlayer);
            Invoke("RestartGame", .5f);
            bc.enabled = false;
            mesh.enabled = false;
            Game.deaths++;
            Game.tutorialActive = false;
        }
        else if (collision.gameObject.CompareTag(Game.rewardTag)) {
            AudioManager.instance.PlaySE(SE.reward);
            collision.gameObject.SetActive(false);
        }
    }

    void RestartGame() {
        Game.state = GameState.gameover;
        gameOverSignal.Raise();
    }
}
