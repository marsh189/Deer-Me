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
 *     Opposite occurs at exit of section.
 */

using UnityEngine;

public class DarknessTrigger : MonoBehaviour {

	public GameObject player;
	public Light worldLight;
	public Camera mainCamera;
	public float minVisibility;
	public float minCamColorVal;
	public float lightDeltaValue;
	public float camColorDelta;
	public float innerTriggerDist;
	public bool isEntrance;

	private bool hasTorch;
	private bool hitTrigger;
	private int hitTriggerCount;
	private BoxCollider2D collider;
	private float playerVelocity;
	private float playerPosX;
	private float colliderPosX;
	private float innerTriggerPos;
	private float lightDelta;
	private bool triggerLock;
	private float fullDarkPos;
	private bool fullDarkLock;

	void Start() {

		if (PlayerPrefs.GetFloat("Lighting") != 1f) {
			worldLight.intensity = PlayerPrefs.GetFloat("Lighting");
		}

		player = GameObject.FindGameObjectWithTag("Player");

		collider = (BoxCollider2D) gameObject.GetComponent<Collider2D>();
		colliderPosX = collider.transform.position.x;
		if (isEntrance)
            innerTriggerPos = colliderPosX - collider.size.x / 2 + innerTriggerDist;
		else
			innerTriggerPos = colliderPosX + collider.size.x / 2 - innerTriggerDist;


		triggerLock = true;
		fullDarkLock = true;
	}

	void Update() {
		playerVelocity = player.GetComponent<Rigidbody2D>().velocity.x;
		playerPosX = player.transform.position.x;

		if (hitTrigger) {
            CheckPlayerPosition();
		}
	}

	private void CheckPlayerPosition() {

        if (hitTriggerCount % 2 != 1) return;

		// ENTRANCE
		if (isEntrance) {
			// IF PLAYER MOVING RIGHT
			if (playerVelocity > 0.5f) {
				// UNLOCK LIGHT DELTA LOCK
				triggerLock = true;
				// DECREASE WORLD LIGHT
				if (worldLight.intensity > minVisibility) {
					worldLight.intensity -= lightDeltaValue;
					var temp = new Color(mainCamera.backgroundColor.r - camColorDelta, mainCamera.backgroundColor.b - camColorDelta, mainCamera.backgroundColor.g - camColorDelta);
					mainCamera.backgroundColor = temp;
				}

				if (worldLight.intensity <= minVisibility && fullDarkLock) {
					fullDarkPos = playerPosX;
					print(fullDarkPos);
					fullDarkLock = false;
				}
			// IF PLAYER MOVING LEFT
			} else {
				// IF PLAYER INSIDE INNER TRIGGER BOX
				if (playerPosX <= innerTriggerPos) {
					// CAPTURE DELTA
					if (triggerLock) {
						lightDelta = 1f - worldLight.intensity;
						triggerLock = false;
					}
					// INCREASE WORLD LIGHT
					if (worldLight.intensity < 1f) {
						worldLight.intensity += lightDelta * Time.deltaTime;
                        var temp = new Color(mainCamera.backgroundColor.r + camColorDelta, mainCamera.backgroundColor.b + camColorDelta, mainCamera.backgroundColor.g + camColorDelta);
                        mainCamera.backgroundColor = temp;
					}
				}
			}
		// EXIT
		} else {
			// IF PLAYER MOVING LEFT
			if (playerVelocity < -0.5f) {
				// UNLOCK LIGHT DELTA LOCK
				triggerLock = true;
				// DECREASE WORLD LIGHT
				if (worldLight.intensity > minVisibility) {
					worldLight.intensity -= lightDeltaValue;
					var temp = new Color(mainCamera.backgroundColor.r - camColorDelta, mainCamera.backgroundColor.b - camColorDelta, mainCamera.backgroundColor.g - camColorDelta);
					mainCamera.backgroundColor = temp;
				}
			// IF PLAYER MOVING RIGHT
			} else {
				// IF PLAYER INSIDE INNER TRIGGER BOX
				if (playerPosX >= innerTriggerPos) {
					// CAPTURE DELTA
					if (triggerLock) {
						lightDelta = 1f - worldLight.intensity;
						triggerLock = false;
					}
					// INCREASE WORLD LIGHT
					if (worldLight.intensity < 1f) {
						worldLight.intensity += lightDelta * Time.deltaTime;
                        var temp = new Color(mainCamera.backgroundColor.r + camColorDelta * 1.15f, mainCamera.backgroundColor.b + camColorDelta * 1.15f, mainCamera.backgroundColor.g + camColorDelta * 1.15f);
                        mainCamera.backgroundColor = temp;
					}
				}
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
