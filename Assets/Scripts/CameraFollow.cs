﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;
    [SerializeField] private float _offset;

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, _offset);
    }
}
