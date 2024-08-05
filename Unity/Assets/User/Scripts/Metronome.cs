using UnityEngine;

public class Metronome : MonoBehaviour
{
    public float bpm = 60f; // Beats per minute
    private float secondsPerBeat;
    private float nextTickTime;
    private AudioSource audioSource;
    private bool isRunning = false; // Flag to track if the metronome is running
    

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Check if AudioSource component is properly assigned
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component is missing on the GameObject at start.");
            return;
        }
        else
        {
            Debug.Log("AudioSource component found at start.");
        }

        if (audioSource.clip == null)
        {
            Debug.LogError("No AudioClip assigned to the AudioSource.");
            return;
        }

        CalculateSecondsPerBeat();
        Debug.Log("Metronome initialized with BPM: " + bpm);
    }

    void CalculateSecondsPerBeat()
    {
        secondsPerBeat = 60f / bpm;
        Debug.Log("Seconds per beat calculated: " + secondsPerBeat);
    }

    public void StartMetronome()
    {
        // Re-check AudioSource component
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            Debug.LogError("Cannot start metronome because AudioSource is missing.");
            return;
        }
        else
        {
            Debug.Log("AudioSource component found in StartMetronome.");
        }

        isRunning = true;
        nextTickTime = Time.time + secondsPerBeat;
        Debug.Log("Metronome started. Next tick time: " + nextTickTime);
    }

    public void StopMetronome()
    {
        isRunning = false;
        Debug.Log("Metronome stopped.");
    }

    void Update()
    {
        if (audioSource == null)
        {
            Debug.LogError("AudioSource is missing in Update.");
            return;
        }

        if (isRunning)
        {
            Debug.Log("Metronome running. Current time: " + Time.time + ", Next tick time: " + nextTickTime);

            if (Time.time >= nextTickTime)
            {
                audioSource.Play();
                Debug.Log("Metronome tick at: " + Time.time);
                nextTickTime += secondsPerBeat;
            }
        }
    }

    public void SetBPM(float newBPM)
    {
        bpm = newBPM;
        CalculateSecondsPerBeat();
    }
}
