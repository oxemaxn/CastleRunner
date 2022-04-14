using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    // public int inventoryCounter;
    public List<char> inventoryList = new List<char>();
    private Canvas canvas;
    private TextMeshPro mesh;

    public void PickupLetter(GameObject obj)
    {   
        // obj.FindGameObjectsWithTag("LetterText").text
        canvas = obj.GetComponent<Canvas>();
        Debug.LogWarning($"Teste 3: {obj.transform.GetChild(0).GetChild(0).gameObject.tag}");
        if (canvas != null)
            mesh = canvas.GetComponent<TextMeshPro>();
        if (mesh != null)
            Debug.LogWarning($"Teste 2: {mesh.tag}");
        Debug.LogWarning($"Teste: no");
        inventoryList.Add('A');
    }
}
