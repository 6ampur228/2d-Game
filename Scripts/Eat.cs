using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat : MonoBehaviour
{
    [SerializeField] private AudioSource _soundEat;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<Pizza>(out Pizza pizza))
        {
            Destroy(collision.gameObject);

            _soundEat.Play();
        }
    }
}
