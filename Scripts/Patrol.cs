using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _groundDetection;

    private float _rayDistance = 1f;
    private bool _isMovingRight = true;

    private void Update()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(_groundDetection.position, Vector2.down, _rayDistance);

        if(groundInfo.collider == false)
        {
            if (_isMovingRight)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);

                _isMovingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);

                _isMovingRight = true;
            }
        }
    }
}
