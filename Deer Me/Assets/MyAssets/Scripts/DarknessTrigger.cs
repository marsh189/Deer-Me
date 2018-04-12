/*
 * Vince Carpino
 * 2260921
 * carpi111@mail.chapman.edu
 * CPSC 440-01
 * Deer Me
 *
 * Controls darkness stage of level.
 *     As player enters darkness section,
 *     world darkens; lightens as they
 *     move back toward entrance.
 */

using UnityEngine;

public class DarknessTrigger : MonoBehaviour {

	public GameObject player;
	public Light worldLight;
	public float minVisibility;
	public float lightDeltaValue;
	public float innerTriggerDist;

	private bool hasTorch;
	private bool hitTrigger;
	private int hitTriggerCount;
	private BoxCollider2D collider;
	private float playerVelocity;
	private float playerPosX;
	private float colliderPosX;
	private float triggerDistToLeftSide;
	private float lightDelta;
	private bool triggerLock;

	void Start() {

		if (PlayerPrefs.GetFloat("Lighting") != 1f) {
			worldLight.intensity = PlayerPrefs.GetFloat("Lighting");
		}

		player = GameObject.FindGameObjectWithTag("Player");

		collider = (BoxCollider2D) gameObject.GetComponent<Collider2D>();
		colliderPosX = collider.transform.position.x;
		triggerDistToLeftSide = collider.offset.x - collider.size.x / 2f;

		triggerLock = true;
	}

	void Update() {
		playerVelocity = player.GetComponent<Rigidbody2D>().velocity.x;
		playerPosX = player.transform.position.x;

		if (hitTrigger) {
            CheckPlayerPosition();
		}
	}

	private void CheckPlayerPosition() {
		// IF PLAYER CROSSES TRIGGER RIGHT TO LEFT, IGNORE
		if (hitTriggerCount % 2 != 1) return;

		// IF PLAYER MOVING RIGHT
		if (playerVelocity > 0.5f) {
			triggerLock = true;
			// DECREASE WORLD LIGHT INTENSITY
			if (worldLight.intensity > minVisibility)
				worldLight.intensity -= lightDeltaValue;
        // IF PLAYER MOVING LEFT
		} else if (playerVelocity < -0.5f) {
			// IF PLAYER IS LEFT OF INNER TRIGGER
			if (playerPosX <= colliderPosX + triggerDistToLeftSide + innerTriggerDist) {
                // INCREASE WORLD LIGHT INTENSITY
				if (triggerLock) {
					lightDelta = 1f - worldLight.intensity;
					triggerLock = false;
				}

				if (worldLight.intensity < 1.0f)
					worldLight.intensity += lightDelta * Time.deltaTime;
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (!other.CompareTag("Player")) return;

		hitTrigger = true;
		hitTriggerCount++;
	}

	private void OnTriggerExit2D(Collider2D other) {
		if (!other.CompareTag("Player")) return;

		hitTrigger = false;
		hitTriggerCount++;
	}

	public void setHasTorch(bool val) {
		hasTorch = val;
	}
}