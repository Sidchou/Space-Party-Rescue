using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GazeDependentVolume : MonoBehaviour
{
    public Transform player;
    private AudioSource audioSource;
    private AudioLowPassFilter lowPassFilter;
    public TriggerController controllerTrigger;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        lowPassFilter = GetComponent<AudioLowPassFilter>();

    }

    private void Update()
    {
        Vector3 directionToSource = transform.position - player.position;
        float angle = Vector3.Angle(player.forward, directionToSource);

        // This line assumes that the volume should be 1.0 when the player is looking directly at the source,
        // and decrease linearly to 0.0 when the player is looking 90 degrees away.
        // Adjust as needed for your specific requirements.

        if (controllerTrigger.isTriggerPressed)
        {
            lowPassFilter.cutoffFrequency = (1.0f*20000) - Mathf.Clamp01(angle / 90.0f * controllerTrigger.micAngle) *20000;
            //audioSource.minDistance = 400;
        }
        else
        {
            audioSource.volume = 1.0f - Mathf.Clamp01(angle / 90.0f * controllerTrigger.normalAngle);
            lowPassFilter.cutoffFrequency = 20000;
            audioSource.minDistance = 1;

        }

    }
}
