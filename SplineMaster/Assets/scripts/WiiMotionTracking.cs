using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using WiimoteApi;
using WiimoteApi.Util;

public class WiiMotionTracking : MonoBehaviour {

	private Wiimote wiimote;

	private Rect controlRect = new Rect(300, 20, 470, 300);

	void Start () {
		WiimoteManager.FindWiimotes();
	}
	
	void Update () {
		
		wiimote = WiimoteManager.Wiimotes[0];

		Debug.Log(GetAccelVector());
	}

	private Vector3 GetAccelVector()
	{
		float accel_x;
		float accel_y;
		float accel_z;

		float[] accel = wiimote.Accel.GetCalibratedAccelData();
		accel_x = accel[0];
		accel_y = -accel[2];
		accel_z = -accel[1];

		return new Vector3(accel_x, accel_y, accel_z).normalized;
	}
	void OnGUI()
	{
		GUI.Box(new Rect(0, 0, Screen.width, 30), "");
		GUILayout.BeginHorizontal();
		GUILayout.Label("Wiimote Found: " + WiimoteManager.HasWiimote());
		for (int x = 0; x < 3; x++)
		{
			AccelCalibrationStep step = (AccelCalibrationStep)x;
			if (GUILayout.Button(step.ToString(), GUILayout.Width(100)))
				Debug.Log(step);
			wiimote.Accel.CalibrateAccel(step);
		}

		GUILayout.EndHorizontal();
	}
}
