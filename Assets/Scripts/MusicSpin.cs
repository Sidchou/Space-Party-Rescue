using UnityEngine;

public class MusicSpin : MonoBehaviour
{
    public float speed = 1f;

    void Update()
    {
        // Rotate the object on the Y-axis based on the speed variable
        transform.Rotate(0f, speed * Time.deltaTime, 0f, Space.World);
    }
}
