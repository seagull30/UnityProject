using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    float _speed = 0.5f;
    public float distance;


    private float elapsedtme;
    void Start()
    {

    }
    private void OnEnable()
    {
        elapsedtme = 0f;
        //StartCoroutine(Fire());
    }

    void Update()
    {
        elapsedtme += Time.deltaTime;
        if (elapsedtme * _speed >= distance)
        {
            gameObject.SetActive(false);
        }
        
        transform.Translate(0f, 0f, _speed);
    }


    //IEnumerator Fire()
    //{
    //    elapsedtme = 0f;
    //    float dtime = distance / _speed;
    //    while (elapsedtme < dtime)
    //    {
    //        elapsedtme += Time.deltaTime;
    //
    //        transform.Translate(0f, 0f, _speed);
    //        yield return null;
    //    }
    //    gameObject.SetActive(false);
    //}

    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
    }

}
