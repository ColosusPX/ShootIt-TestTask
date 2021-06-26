using UnityEngine;
using UnityEngine.AI;

public class PlayerMoving : MonoBehaviour
{
    int target = 0;
    [HideInInspector] public bool isStay = false;
    [SerializeField] GameObject[] _waypoints;
    NavMeshAgent _agent;
    Animator _animator;

    void Start()
    {
        _agent = gameObject.GetComponent<NavMeshAgent>(); // Обращаемся к компоненту НавМеша...
    }

    void Update()
    {
        if ((_waypoints[target].transform.position - transform.position).magnitude < .3f && !isStay) // Если мы подошли к точке запускаем анимацию ожидания
        {
            _animator.Play("Idle");
            isStay = true;
        }
    }

    public bool NextWaypoint() // Передвигаемся на следующий вейпоинт, если он последний сообщаем о завершении пути
    {
        target++;
        isStay = false;
        if (target > _waypoints.Length)
            return true;

        _agent.SetDestination(_waypoints[target].transform.position); // ...Задаем путь к следующей точке
        _animator = gameObject.GetComponent<Animator>(); // Запускаем анимацию бега
        _animator.Play("Run");

        return false;
    }
}