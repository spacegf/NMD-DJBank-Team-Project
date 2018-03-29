using UnityEngine;
using System.Collections;
using System.IO.Ports;

/*public class CharacterRotate : MonoBehaviour
{

    public float motionSensitivity = 0.0f; 
    public float motionDelta = 0.0f;
    private float prevMotionDelta = 0.0f;

    SerialPort arduino1;

    void Start()
    {
        arduino1 = new SerialPort();
        arduino1.PortName = "COM4";
        arduino1.BaudRate = 115200;
        arduino1.ReadTimeout = 50;
        arduino1.Parity = Parity.None;
        arduino1.Open();
         
        WriteToArduino(arduino1, "PING");
        StartCoroutine(AsyncControllerInput((string s) => Debug.Log(s),() => Debug.LogError("Error!"), 1000f));
    }
    public void WriteToArduino(SerialPort port, string message)
    {
        port.WriteLine(message);
        port.BaseStream.Flush();
    }
    void Update()
    {
        string motionString = arduino1.ReadLine();
        float motionValue = float.Parse(motionString);
        Debug.Log(value);
        motionDelta = motionValue * motionSensitivity;
        prevMotionDelta = motionValue;
        float rotZ = motionDelta * Mathf.Deg2Rad;
        transform.Rotate(Vector3.forward, -rotZ);
    }
    public IEnumerator AsyncControllerInput(System.Action<string> callback, System.Action fail = null, float timeout = float.PositiveInfinity)
    {
        System.DateTime initialTime = System.DateTime.Now;
        System.DateTime nowTime;
        System.TimeSpan diff = default(System.TimeSpan);

        string dataString = null;

        do
        {
            try
            {
                dataString = arduino1.ReadLine();
            }
            catch (System.TimeoutException)
            {
                dataString = null;
            }

            if (dataString != null)
            {
                callback(dataString);
                yield return null;
            }
            else
                yield return new WaitForSeconds(0.05f);

            nowTime = System.DateTime.Now;
            diff = nowTime - initialTime;

        } while (diff.Milliseconds < timeout);

        if (fail != null)
            fail();
        yield return null;
    }
}*/
