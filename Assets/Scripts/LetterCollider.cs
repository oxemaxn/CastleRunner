using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        InventoryManager manager = collision.GetComponent<InventoryManager>();

        if (manager)
        {
            manager.PickupLetter(gameObject);
        }
    }
}
