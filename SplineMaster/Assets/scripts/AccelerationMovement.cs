using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text;
using System;
using WiimoteApi;
//REQUIRED LIBRARIES -- CRITICAL

public class AccelerationMovement : MonoBehaviour
{
    //establish rig parameters
    Rigidbody rb;
    public GameObject playerCraft;
    public GameObject cameraRig;

    //for storing camera rotation
    Quaternion cameraDir;
	private Quaternion initial_rotation;
	Transform rot;

	//establish wii remote object
	private Wiimote wiimote;

	public float hSens = 2.0f;
    public float vSens = 0.0f;
    public float xOffset = 0.15f;
    public float yOffset = 0.25f; //remember that the camera is pitched down 10 degrees, meaning that the available screenspace is smaller 
	public float rotDamping = 1.0f;

	//jump parameters
	public float maxJumpHeight = 2.0f;
	public float jumpSpeed = 0.8f;
	public float fallSpeed = 0.4f;
	public float jumpSens = 4.0f; //jump activation sensitivity

	private bool isGrounded = false;
	private bool isJumping = false;

	//motion vectors for accelerometer movement
	Vector3 lastPos = Vector3.zero;
	Vector3 deltaPos = Vector3.zero;
	Vector3 screenMovement = Vector3.zero;

	Vector3 jumpStartPos;
	Vector3 jumpOffset;
	Vector3 fallOffset;
	//[SerializeField] private float rotateSpeed; //comment this out when the wiimote controls are functional

	Vector3 postRay = Vector3.zero;
	float postMag = 0.0f;

	Vector3 simpleVect = Vector3.zero;
	float thresholdVect = 0.0f;

	void Start()
    {
        rb = GetComponent<Rigidbody>();
		jumpOffset = new Vector3(0, jumpSpeed, 0);
		fallOffset = new Vector3(0, fallSpeed, 0);
		initial_rotation = playerCraft.transform.localRotation; 
	}

    void Update()
    {

		//transform.Rotate(Vector3.left, rotateSpeed * Input.GetAxis("Mouse ScrollWheel"));//comment this out when wiimote controls are functional
		//read accelerometer values
		ReadAccelValues();

		//Get Mouse Acceleration
		//deltaPos = Input.mousePosition - lastPos;

		//Normalize for display sizes
		//deltaPos.x = deltaPos.x / Screen.width;
		//deltaPos.y = deltaPos.y / Screen.height;

		//deltaPos.x = deltaPos.x * hSens;
		//deltaPos.y = deltaPos.y * vSens;
		//Debug.Log("LastPos:" + lastPos + "NewPos:" + deltaPos); //check for zeroes

		//Get parent rotation (cameraRig), for easing around corners.
		cameraDir = cameraRig.transform.rotation * Quaternion.Euler(0, -75.0f, 0);

        //convert back to world space
        playerCraft.transform.position = ConvertViewportSpace();

		//craft will jump when the accelerometer is moved quickly enough to break the threshhold
		Vector3 complexVect = GetAccelVector(2) - simpleVect;

		thresholdVect = Vector3.Angle(complexVect, simpleVect);
		//Debug.Log(thresholdVect);
		if (Mathf.Abs(thresholdVect) > jumpSens) 
		{
			if (isGrounded) //check if grounded
			{
				jumpStartPos = playerCraft.transform.position; //get position above ground for offset
				isJumping = true;
				StartCoroutine("JumpCycle");
			}
		}

		simpleVect = GetAccelVector(2);

		//Debug.DrawRay(playerCraft.transform.position, Vector3.down * 1.25f, Color.green);
		if (Physics.Raycast(playerCraft.transform.position, Vector3.down, 1.25f))
		{
			isGrounded = true;
		}
		else
		{
			isGrounded = false;
		}
		//Debug.Log("isJumping:" + isJumping + "isGrounded:" + isGrounded);

		//calculate velocity and move craft based on acceleration value
		screenMovement = new Vector3((StrafeMovement().x * hSens) + (StrafeMovement().y * hSens), 0, 0);
		
        playerCraft.transform.localPosition += screenMovement * Time.smoothDeltaTime;

        //Zero out mouse acceleration
        //lastPos = Input.mousePosition;
    }

    Vector3 ConvertViewportSpace()
    {
        //keep craft inside screen boundary - convert to screen space
        Vector3 cameraSpace = Camera.main.WorldToViewportPoint(playerCraft.transform.position);
        cameraSpace.x = Mathf.Clamp(cameraSpace.x, xOffset, 1.0f - xOffset);
        cameraSpace.y = Mathf.Clamp(cameraSpace.y, yOffset, 1.0f - yOffset);

        //set upper and lower bounds on both axes
        if (cameraSpace.x == 0 || cameraSpace.x == 1)
        {
            screenMovement.x = 0.0f;
            //Debug.Log("Out of Bounds");
        }
        if (cameraSpace.y == 0 || cameraSpace.y == 1)
        {
            screenMovement.y = 0.0f;
            //Debug.Log("Out of Bounds");
        }

        return Camera.main.ViewportToWorldPoint(cameraSpace);
    }

    //jump coroutine start
    IEnumerator JumpCycle()
    {
        while (true)
        {
			if(playerCraft.transform.localPosition.y >= maxJumpHeight)
			{
				isJumping = false;
			}
			if(isJumping)
			{
				playerCraft.transform.localPosition += jumpOffset * Time.smoothDeltaTime;
			}
			else if (!isJumping)
			{
				playerCraft.transform.localPosition -= fallOffset * Time.smoothDeltaTime;
				if (Physics.Raycast(playerCraft.transform.position, Vector3.down, 1.1f))
				{
					StopAllCoroutines();
				}
			}

			yield return new WaitForEndOfFrame();
        }
    }

	//taken from wii remote API for initializing wii remote
	//move this section to the "Main Menu" scene and then transfer the value to this scene
	void OnGUI()
	{
		GUI.Box(new Rect(0, 0, 320, 180), "");

		GUILayout.BeginVertical(GUILayout.Width(300));
		GUILayout.Label("Wiimote Found: " + WiimoteManager.HasWiimote());
		if (GUILayout.Button("Find Wiimote"))
			WiimoteManager.FindWiimotes();

		if (GUILayout.Button("Cleanup"))
		{
			for (int i = 0; i < WiimoteManager.Wiimotes.Count; i++)
			{
				wiimote = WiimoteManager.Wiimotes[i];
				WiimoteManager.Cleanup(wiimote);
				wiimote = null;
			}
		}

		if (wiimote == null)
			return;

		GUILayout.Label("Calibrate Accelerometer");
		GUILayout.BeginHorizontal();
		for (int x = 0; x < 3; x++)
		{
			AccelCalibrationStep step = (AccelCalibrationStep)x;
			if (GUILayout.Button(step.ToString(), GUILayout.Width(100)))
				wiimote.Accel.CalibrateAccel(step);
		}
		GUILayout.EndHorizontal();
	}

	//establish initial rotations
	//player 0 - 3 correspond 1 - 4
	void ReadAccelValues()
	{
		if (!WiimoteManager.HasWiimote()) { return; }
	
		for (int i = 0; i < WiimoteManager.Wiimotes.Count; i++)
		{
			wiimote = WiimoteManager.Wiimotes[i];

			wiimote.SendDataReportMode(InputDataType.REPORT_BUTTONS_ACCEL);
			int ret;//read values from driver
			do { ret = wiimote.ReadWiimoteData(); } while (ret > 0);
			//Debug.Log(GetAccelVector(i).x + ", " + GetAccelVector(i).y + ", " + GetAccelVector(i).z);
		}
		//This is all that's needed for rotation
		playerCraft.transform.rotation *= Quaternion.Euler((-GetAccelVector(0).x * rotDamping), 0, 0);
	}

	private Vector3 StrafeMovement()
	{
		//Quaternion postRay = Quaternion.Euler(GetAccelVector(1).x - initRay.x, 0, 0);

		//playerCraft.transform.localPosition += (postRay * Vector3.left * 10.0f) * Time.smoothDeltaTime;

		//initRay = Quaternion.Euler((GetAccelVector(1).x), 0, 0);

		postRay = Vector3.Lerp(postRay, GetAccelVector(1), Time.smoothDeltaTime);
		//postMag = Mathf.Clamp01(new Vector2(postRay.x, postRay.y).magnitude); 
		return postRay;
	}
	
	//acceleration from wii remote
	private Vector3 GetAccelVector(int player)
	{
		float accel_x;
		float accel_y;
		float accel_z;

		wiimote = WiimoteManager.Wiimotes[player];//from 0 to 3

		float[] accel = wiimote.Accel.GetCalibratedAccelData();
		accel_x = accel[0];
		accel_y = -accel[2];
		accel_z = -accel[1];

		return new Vector3(accel_x, accel_y, accel_z).normalized;
	}

	//rotation vector
	void OnDrawGizmos()
	{
		if (wiimote == null) return;

		Gizmos.color = Color.red;
		Gizmos.DrawLine(playerCraft.transform.position, playerCraft.transform.position + cameraRig.transform.rotation * GetAccelVector(0) * 2);
		Gizmos.color = Color.yellow;
		Gizmos.DrawLine(playerCraft.transform.position, playerCraft.transform.position + cameraRig.transform.rotation * GetAccelVector(1) * 2);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(playerCraft.transform.position, playerCraft.transform.position + cameraRig.transform.rotation * GetAccelVector(2) * 2);
	}
}
