using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] Transform _outBullet;
    [SerializeField] GameObject _bullet;
    [SerializeField] Transform _pivot;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 dest;
            RaycastHit hit;
            Ray ray = Camera.main.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition); // Задаем луч из камеры

            if (Physics.Raycast(ray, out hit)) // пускаем луч
            {
                dest = hit.point - _outBullet.position; // Задаем вектор движения пули
                GameObject bull = Instantiate(_bullet); 
                bull.transform.position = _outBullet.position;
                bull.GetComponent<Bullet>().SetDestination(dest.normalized);
            }
        }
    }
}