using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector3 _dest;
    float ttl = 1f;

    void Update()
    {
        transform.position += _dest * 10 * Time.deltaTime; // движение пули
        ttl -= Time.deltaTime; // время до уничтожения пули
        if (ttl < 0)
            Destroy(gameObject);
    }

    public void SetDestination(Vector3 dest)
    {
        _dest = dest;
        float z = dest.x * transform.up.y - dest.y * transform.up.x;
        transform.Rotate(0, 0, Vector3.Angle(dest, transform.up) * z / Mathf.Abs(z)); // задаем вектор движения и поворачиваем пулю по нему
    }

    private void OnCollisionEnter(Collision collision) // при столкновении удаляем
    {
        Destroy(gameObject);
    }
}
