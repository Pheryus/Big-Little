using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeBehaviour : MonoBehaviour {

    // Desired duration of the shake effect
    private float shakeDuration = 0f;

    // A measure of magnitude for the shake. Tweak based on your preference
    private float shakeMagnitude = 0.3f;

    // A measure of how quickly the shake effect should evaporate
    private float dampingSpeed = 1.0f;

    // The initial position of the GameObject
    Vector3 initialPosition;

    private void Start() {
        initialPosition = transform.localPosition;

    }

    void Update() {
        if (shakeDuration > 0) {
            transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;

            shakeDuration -= Time.deltaTime * dampingSpeed;
        }
        else {
            shakeDuration = 0f;
            transform.localPosition = initialPosition;
        }
    }

    public void TriggerHardShake() {
        shakeDuration = .1f;
        shakeMagnitude = 0.3f;
    }
    public void TriggerSoftShake() {
        shakeDuration = .1f;
        shakeMagnitude = .2f;
    }
}
