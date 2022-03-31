using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;

    private Rigidbody2D rig;
    private Vector2 _direction;

    //Acessando _direction de forma correta para ser usado em outro script
    public Vector2 direction
    {
        get { return _direction; }
        set { _direction = value; }
    }

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void Update() //Relacionado a input
    {
        OnInput();
    }

    private void FixedUpdate() // Relacionado a fisica
    {
        OnMove();
    }

    #region Movement

        void OnInput()
        {
            _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
        void OnMove()
        {
            rig.MovePosition(rig.position + _direction * speed * Time.fixedDeltaTime);
        }

    #endregion
}
