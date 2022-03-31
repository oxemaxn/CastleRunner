using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    //Referenciando o script Player para pegar direction
    private Player player;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        OnMove();
    }

    #region Movement
        void OnMove()
        {
            if( player.direction.sqrMagnitude > 0)
            {
                if( player.direction.y < 0 )
                {
                    anim.SetInteger("transition", 3);
                }
                else if( player.direction.y > 0 )
                {
                    anim.SetInteger("transition", 2);
                }
                else
                {
                    anim.SetInteger("transition", 1);
                }
                //sanim.SetInteger("transition", 1);
            }
            else
            {
                anim.SetInteger("transition", 0);
            }

            if( player.direction.x > 0 )
            {
                transform.eulerAngles = new Vector2(0, 0);
            }

            if( player.direction.x < 0 )
            {
                transform.eulerAngles = new Vector2(0, 180);
            }
        }
    #endregion
}
