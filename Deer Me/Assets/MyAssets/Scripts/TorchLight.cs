using UnityEngine;

public class TorchLight : MonoBehaviour {

	public float minRand;
	public float maxRand;
	public float updateFrequency;
	public float brightnessChangeValue;

	private Light thisLight;
	private Color originalColor;
	private float timePassed;
	private float changeValue;

	private float randValue;

	void Start () {
		thisLight = GetComponent<Light>();

		if (thisLight != null) {
			originalColor = thisLight.color;
		} else {
			enabled = false;
			return;
		}

		changeValue = 0;
		timePassed = 0;

		InvokeRepeating("ChangeTorchFrequency", 0f, updateFrequency);
	}

	void Update () {
		timePassed = Time.time;
		timePassed = timePassed - Mathf.Floor(timePassed);

		thisLight.color = originalColor * CalculateChange();

//		StartCoroutine(ChangeTorchFrequency(1f));
	}

	private float CalculateChange() {
		changeValue = -Mathf.Sin(timePassed * randValue * Mathf.PI) * brightnessChangeValue + 0.95f;
		return changeValue;
	}

	void ChangeTorchFrequency() {
//		yield return new WaitForSeconds(val);

		randValue = Random.Range(minRand, maxRand);
	}
}
