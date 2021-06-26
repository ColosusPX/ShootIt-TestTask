using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform _head;
    [SerializeField] Transform _body;
    [SerializeField] GameObject _raggdoll;
    [SerializeField] GameObject _heart;
    int _health = 2;

    private void OnCollisionEnter(Collision collision)
    {
        if (Mathf.Abs((collision.transform.position - _head.position).magnitude) < Mathf.Abs((collision.transform.position - _body.position).magnitude)) // фиксируем попадание в голову или тело
            Die();
        else
        {
            _health--;
            Destroy(_heart);
        }

        if (_health == 0)
            Die();
    }

    void Die()
    {
        GameObject rd = Instantiate(_raggdoll); // создаем на месте врага рэгдол
        rd.transform.position = transform.position;
        rd.transform.rotation = transform.rotation;
        Destroy(gameObject);
    }
}
