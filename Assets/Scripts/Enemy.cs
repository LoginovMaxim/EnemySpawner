using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private bool _isTrap;

    private void Update()
    {
        if(!_isTrap)
            transform.Translate(0, _speed * Time.deltaTime * (-1), 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!_isTrap)
            Destroy(gameObject);
    }
}
