/*
 * Vince Carpino
 * 2260921
 * carpi111@mail.chapman.edu
 * CPSC 440-01
 * Deer Me
 *
 * Controls darkness stage of level.
 *     As player advances forward,
 *     the screen darkens. If they
 *     turn around, the screen
 *     lightens again.
 */

using UnityEngine;
using UnityEngine.UI;

public class DarknessTrigger : MonoBehaviour {

	public float startXPos;

	public float divisor;
	public float minVisibility;

	public GameObject player;
	public Image darknessImage;

	private void Start() {
		minVisibility /= 100f;
		minVisibility = 1f - minVisibility;
	}

	void Update() {
		CheckPosition();
	}

	void CheckPosition() {
		if (player.transform.position.x <= startXPos) return;

		var tempColor = darknessImage.color;
		tempColor.a = (player.transform.position.x - startXPos) / divisor;
		if (tempColor.a <= minVisibility) {
			darknessImage.color = tempColor;
		}
	}
}
