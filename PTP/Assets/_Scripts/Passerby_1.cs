using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passerby_1 : MonoBehaviour
{
    [SerializeField] protected float speed;

    protected virtual void Update() // ABSTRACTION
    {
        Move();
        DestroyOnFallDown();
    }

    protected virtual void Move()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
    }

    protected void DestroyOnFallDown()
    {
        if (transform.position.y < 0)
        {
            Destroy(gameObject);
        }
    }
}
