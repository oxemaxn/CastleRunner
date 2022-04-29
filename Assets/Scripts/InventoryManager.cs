using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public List<char> inventoryList = new List<char>();
    public int numberOfLetters = 3;
    public string word = "BAG";
    private Canvas canvas;
    private TextMeshPro mesh;
    private GameObject objectChild;
    private char letterToAdd;

    public void PickupLetter(GameObject obj)
    {   
        Debug.LogWarning($"Teste 3: {obj.transform.GetChild(0).GetChild(0).gameObject.tag}");
        objectChild = obj.transform.GetChild(0).GetChild(0).gameObject;

        if (obj.transform.GetChild(0).GetChild(0).gameObject.tag == "LetterText")
        {
            letterToAdd = objectChild.GetComponentInChildren<TextMeshProUGUI>().text.ToCharArray()[0];
            inventoryList.Add(letterToAdd);
            if(!LevelFinished() && LevelWronglyFinished())
            {
                inventoryList.Clear();
            } else if(LevelFinished()) {
                // Finalizar o level
            }
            UpdateInventoryLetters();
            Destroy(obj);
        }
    }

    public void UpdateInventoryLetters()
    {
        for(int i = 0; i < numberOfLetters; i++)
        {
            var inventoryItem = GameObject.FindWithTag($"Letter{i}");
            var itemText = inventoryItem.GetComponent<TMPro.TextMeshProUGUI>();
            if(i <= inventoryList.Count -1)
            {
                itemText.text = inventoryList[i].ToString();
            } else {
                itemText.text = '_'.ToString();
            }
        }
    }

    public bool LevelFinished()
    {
        if(inventoryList.Count == numberOfLetters)
        {
            if(new string(inventoryList.ToArray()) == word)
            {
                return true;
            }
        }
        return false;
    }

    public bool LevelWronglyFinished()
    {
        if(inventoryList.Count == numberOfLetters)
        {
            if(new string(inventoryList.ToArray()) != word)
            {
                return true;
            }
        }
        return false;
    }

    public void clearBag()
    {
        inventoryList.Clear();
        UpdateInventoryLetters();
    }
}
