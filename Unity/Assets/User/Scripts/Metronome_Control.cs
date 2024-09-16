
using UnityEngine;



public class Metronome_Control : MonoBehaviour
{
    // Reference to the Metronome script
    public Metronome metronome;
    public UDPSignalReceiver udpsignalreceiver;
    public KeyboardControl keyboardcontrol;
    public float newBPM=60;


    void Start()
    {
        if (metronome == null)
        {
            Debug.LogError("Metronome script reference is missing.");
            return;
        }

        // Set the updated BPM if necessary
        metronome.SetBPM(newBPM);

        // Force start the metronome
        if (1 > 0) // This condition is always true
        {
            metronome.StartMetronome();
            Debug.Log("Forced start of metronome.");
        }
    }

    void Update()
    {
        
        if (metronome != null)
        {
            metronome.SetBPM(newBPM);
        }

        // Check if movement is detected
        bool isMoving = (udpsignalreceiver.linearVelocity > 0 || keyboardcontrol.linearSpeed > 0);

        // If moving and the metronome is not running, start it
        if (isMoving && !metronome.isRunning)
        {
            if (metronome != null)
            {
                metronome.StartMetronome();
                metronome.isRunning = true;
                Debug.Log("Metronome started during movement.");
            }
            else
            {
                Debug.LogError("Metronome script reference is missing in Update.");
            }
        }

        // If no movement and the metronome is running, stop it
        if (!isMoving && metronome.isRunning)
        {
            if (metronome != null)
            {
                metronome.StopMetronome();
                metronome.isRunning = false;
                Debug.Log("Metronome stopped during stop.");
            }
            else
            {
                Debug.LogError("Metronome script reference is missing in Update.");
            }
        }
    }
}
