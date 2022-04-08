using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Enemy : MonoBehaviour
{

    public float speed;

    private Rigidbody2D rig;
    private Vector2 _direction;
    private float acelerationTime = 2f;
    private float timeleft;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void Update() 
    {
        timeleft -= Time.deltaTime;
        if(timeleft <=0)
        {
            _direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            timeleft += acelerationTime;
        }
    }

    private void FixedUpdate()
    {
        rig.velocity = (_direction * speed);
    }
}

