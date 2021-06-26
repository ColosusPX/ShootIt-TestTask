using UnityEngine;

public class HeartPivot : MonoBehaviour
{
    void Update()
    {
        transform.LookAt(Camera.main.transform.position); // сердца смотрят в камеру
    }
}
