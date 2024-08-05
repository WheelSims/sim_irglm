
using UnityEngine;



public class Metronome_Control : MonoBehaviour
{
    // Reference to the Metronome script
    public Metronome metronome;
    public UDPSignalReceiver udpsignalreceiver;
    public float newBPM=60;

    void Start()
    {
        if (metronome == null)
        {
            Debug.LogError("Metronome script reference is missing.");
            return;
        }

        // Optionally set the initial BPM
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
        
        if (udpsignalreceiver.linearVelocity>0)
        {
            if (metronome != null)
            {
                metronome.StartMetronome();
                Debug.Log("Metronome started.");
            }
            else
            {
                Debug.LogError("Metronome script reference is missing in Update.");
            }
        }

        if (udpsignalreceiver.linearVelocity ==0)
        {
            if (metronome != null)
            {
                metronome.StopMetronome();
                Debug.Log("Metronome stopped.");
            }
            else
            {
                Debug.LogError("Metronome script reference is missing in Update.");
            }
        }

     
    }
}
