using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObstacleType { black, white, red, blue, none };

public class Obstacle : MonoBehaviour {

    [HideInInspector]
    public Vector3 startScaleValues;

    Vector3 maxScale, minScale;

    public float minZoom, maxZoom;
    public ObstacleType obstacleType;

    public bool unbreakable;

    public Vector2 speed;

    private void Awake() {
        MeshRenderer mesh = GetComponent<MeshRenderer>();
        if (mesh != null)
            mesh.sortingLayerName = "Default";


        startScaleValues = transform.localScale;
        maxScale = startScaleValues * maxZoom;
        minScale = startScaleValues * minZoom;
    }

    public void OnCreation() {
        
    }


    private void Update() {
        VerticalMovement();
        if (transform.position.y < 4.5f) {
            HorizontalMovement();
        }
    }

    void VerticalMovement() {
        if (Game.state == GameState.gameover)
            return;

        transform.position += Vector3.down * speed.y * Time.deltaTime;
    }

    void HorizontalMovement() {
        if (Game.state == GameState.gameover)
            return;

        transform.position += Vector3.right * speed.x * Time.deltaTime;
    }

    public void UpdateObject(float zoom, float negativeZoom) {

        if (obstacleType == ObstacleType.white || obstacleType == ObstacleType.black)
            UpdateSize(zoom, negativeZoom);
        else if (obstacleType == ObstacleType.blue || obstacleType == ObstacleType.red)
            UpdateSpeed(zoom, negativeZoom);
    }


    void UpdateSpeed (float zoom, float negativeZoom) {

    }


    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Border")) {
            AudioManager.instance.PlaySE(SE.breakWall);
            speed.x *= -1;
            Debug.Log("collision");
        }
    }


    private void UpdateSize(float zoom, float negativeZoom) {

        if (obstacleType == ObstacleType.white)
            zoom = negativeZoom;

        zoom = Mathf.Pow(2, zoom);

        transform.localScale = Vector3.Scale(new Vector3(zoom, zoom, 1), startScaleValues);
        
        
        if (transform.localScale.x > maxScale.x) {
            transform.localScale = maxScale;
        }

        if (transform.localScale.x < minScale.x)
            transform.localScale = minScale;

        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, 1);
    }


}
