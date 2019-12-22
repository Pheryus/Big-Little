using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovement : MonoBehaviour {
    public float speed;

    bool movingRight = true;

    Renderer rend;

    private void Start() {
        rend = GetComponent<Renderer>();
    }

    private void Update() {
        if (Game.state == GameState.gameover)
            return;

        float direction = movingRight ? 1 : -1;

        transform.position += Vector3.right * Time.deltaTime * speed * direction;
        if (rend.bounds.min.x < Game.minX) {
            movingRight = true;
        }
        else if (rend.bounds.max.x > Game.maxX)
            movingRight = false;
    }
}
