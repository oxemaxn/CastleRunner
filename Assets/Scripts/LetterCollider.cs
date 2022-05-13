using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterCollider : MonoBehaviour
{
    public string letterValue;
    public bool isActive;
    public GameController GC;



    private void OnCollisionStay2D(Collision2D collision)
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            gameObject.SetActive(false);
            GC.SetBagLevel(letterValue);
        }
    }
    public void SetActiveLetter()
    {
        gameObject.SetActive(true);
    }
}
