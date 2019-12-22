using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreenCollision : MonoBehaviour {

    public GameObject particle;

    public ShakeBehaviour cameraShake;

    private void OnTriggerEnter2D(Collider2D collision) {
        
        if (collision.gameObject.CompareTag(Game.obstacleTag) || collision.gameObject.CompareTag(Game.rewardTag)) {
            Debug.Log("aqui");
            Obstacle obs = collision.gameObject.GetComponent<Obstacle>();
            if (obs != null) { 
                if (obs.unbreakable)
                    return;
            }

            Debug.Log("aqui2");
            GameObject go = Instantiate(particle, collision.gameObject.transform.position + Vector3.down * .5f, Quaternion.identity);
            Destroy(go, .8f);
            collision.gameObject.SetActive(false);
            AudioManager.instance.PlaySE(SE.breakWall);
            cameraShake.TriggerSoftShake();
        }
    }

}
