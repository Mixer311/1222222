using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class Animals : MonoBehaviour
{
    public List<DraggingItems> items;
    public string[] recipes;
    public DraggingItems[] recipeResult;
    [SerializeField]
    private string currentRecipeString;

    public AudioSource myFX;
    public AudioClip animalFX;
    public AudioClip wrongRecFX;


    public void Cooking()
    {

        if (recipes.Contains(currentRecipeString))
        {
            myFX.PlayOneShot(animalFX);
            StartCoroutine(CheckForRecipe(0.5f));
        }
        else
        {
            myFX.PlayOneShot(wrongRecFX);
        }
    }

    IEnumerator CheckForRecipe(float time)
    {
        yield return new WaitForSeconds(time);
        for (int i = 0; i < recipes.Length; i++)
        {
            if (recipes[i] == currentRecipeString)
            {
                Debug.Log("Готово!");
                for (int j = items.Count; j > 0; j--)
                {
                    Destroy(items[j - 1].gameObject);
                }
                items.Clear();
                currentRecipeString = "";
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DraggingItems item = collision.GetComponent<DraggingItems>();
        if (collision.tag == "Item")
        {
            currentRecipeString += item.itemName;
            items.Add(item);
            Cooking();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        DraggingItems item = collision.GetComponent<DraggingItems>();
        if (collision.tag == "Item")
        {
            currentRecipeString = currentRecipeString.Replace(item.itemName, "");
            items.Remove(item);
        }
    }

}
