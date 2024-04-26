using System; //
using UnityEngine; // This is for MonoBehavior

/*
    could also be done like
    public class Clock : UnityEngine.MonoBehavior {}

    must extend MonoBehavior type, inheriting its data and functionality to be able to use this script to create compononents in Unity
*/
public class Clock : MonoBehaviour { 

    const float hoursToDegrees = -30f, minutesToDegrees = -6f, secondsToDegrees = -6f;

    [SerializeField] //This is now included in the scene's data when Unity saves the scene -> puts data in a sequence (serializing it) -> writes to a file
    Transform hoursPivot, minutesPivot, secondsPivot;

    void Update() {
        TimeSpan time = DateTime.Now.TimeOfDay;
        //Debug.Log(time.Now) to see in console

        // Transform components are defined with Euler angles in degrees per axis
        // Euler angles are defined as planar rotation angles around x, y, and z axes, 
        // in code, we have to use Quaternion
        // Quaternions are used to represent 3D rotations.
        // Unlike Euler angles, quaternions uses four components (w, x, y, z) to compute the rotation. These components are part of an equation using the Euler axis vector components (i, j, k) and angle (θ).
        // Unity's code only works with single-precision floating point values
        hoursPivot.localRotation = Quaternion.Euler(0f, 0f, hoursToDegrees * (float)time.TotalHours);
        minutesPivot.localRotation = Quaternion.Euler(0f, 0f, minutesToDegrees * (float)time.TotalMinutes);
        secondsPivot.localRotation = Quaternion.Euler(0f, 0f, secondsToDegrees * (float)time.TotalSeconds);
    }
}