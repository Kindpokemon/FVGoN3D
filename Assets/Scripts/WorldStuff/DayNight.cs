using UnityEngine;
using System.Collections;

public class DayNight : MonoBehaviour {

	public Transform Sun;
	public float dayCycleInMinutes = 20;

	public const float SECOND = 1;
	public const float MINUTE = 60 * SECOND;
	public const float HOUR = 60 * MINUTE;
	public const float DAY = 24 * HOUR;
	public const float MONTH = 30 * DAY;
	public const float YEAR = 12 * MONTH;
	private const float DEGREES_PER_SECOND = 360 / DAY;
	private float _degreeRotation;
	private float _timeofDay;

	public static int currentSeconds = 0;
	public static int currentMinutes = 0;
	public static int currentHours = 0;
	public static int currentDays = 0;
	public static int currentMonths = 0;
	public static int currentYears = 0;

	float degreesRotated = 0;

	// Use this for initialization
	void Start () {
		_timeofDay = 0;
		_degreeRotation = DEGREES_PER_SECOND * DAY / (dayCycleInMinutes * MINUTE);
		Time.timeScale = 1.0f;
	}

	// Update is called once per frame
	void Update () {
		if (degreesRotated < 360) {
			Sun.Rotate (new Vector3 (_degreeRotation, 0, 0) * Time.deltaTime);
			degreesRotated += _degreeRotation*Time.deltaTime;

			_timeofDay += Time.deltaTime;
			Debug.Log (_degreeRotation);
			currentSeconds += (int)Mathf.Floor ((_degreeRotation*Time.deltaTime)*10.39f*24);
			currentMinutes = currentSeconds / 60;
			currentHours = currentMinutes / 60;
			currentDays = currentHours / 24;
			currentMonths = currentDays / 30;
			currentYears = currentMonths / 12;
			Debug.Log ("Seconds: " + currentSeconds + ", Minutes: " + currentMinutes + ", Hours: " + currentHours + ", Days: " + currentDays);
		}
	}
}