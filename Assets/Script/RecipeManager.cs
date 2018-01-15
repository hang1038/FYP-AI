using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeManager : MonoBehaviour {
	// Use this for initialization
	public TimerManager currentTime;
    public int numOfDish; //controling the level dish
    public string[] chosenDish;
    public string[] recipe;// = { "testrecipe1", "testrecipe2", "testrecipe3" };
    private int PageCounter = 0; //select food use
	public Text titleText;
    private bool changePage = false;
    public const int numItemSlots = 4;
    private string testList = "list: ";
    public Canvas BlockerLeft;
    public Canvas BlockerRight;
	public bool isStart = false;

    public Image[] itemImages = new Image[numItemSlots];

    public Text[] itemName = new Text[numItemSlots];

    void Start () {
		int count = 1;
        Debug.Log(recipe.Length);
        chosenDish = new string[numOfDish];
        List<string> temprecipe = new List<string>(recipe);
        for (int k = 0; k < numOfDish; k++) //Loop for the random dish in the game
            {
                chosenDish[k] = temprecipe[Random.Range(0, temprecipe.Count)];
                temprecipe.Remove(chosenDish[k]);
                testList += chosenDish[k]; 
        }
        Debug.Log(testList);
        
        Recipe CorrectRecipeFoods = Resources.Load<Recipe>("recipes/" + chosenDish[PageCounter]);
        titleText.text = "Recipt for " + CorrectRecipeFoods.name;
        for (int i = 0; i < CorrectRecipeFoods.foods.Length; i++)
            {
                itemName[i].enabled = true;
                itemImages[i].enabled = true;
                itemImages[i].sprite = CorrectRecipeFoods.foods[i].sprite;
                itemName[i].text = (count + ". " + CorrectRecipeFoods.foods[i].name + "\n");
                count++;

            }
	}
	// Update is called once per frame
	void Update () {
		if (changePage == true)
        {
            int count = 1;
            Recipe CorrectRecipeFoods = Resources.Load<Recipe>("recipes/" + chosenDish[PageCounter]);
            Debug.Log(CorrectRecipeFoods.name);
            changePage = false;
            titleText.text = "Recipt for" + CorrectRecipeFoods.name;
            for (int i = 0; i < CorrectRecipeFoods.foods.Length; i++)
            {
                if (!(itemName[i].enabled && itemImages[i].enabled))
                {
                    itemName[i].enabled = true;
                    itemImages[i].enabled = true;
                }
                itemImages[i].sprite = CorrectRecipeFoods.foods[i].sprite;
                itemName[i].text = (count + ". " + CorrectRecipeFoods.foods[i].name + "\n");
                count++;
            }
        }
	}
	public void StartTheGame ()
	{
		Canvas ReciptUI = GetComponent<Canvas>();
		Debug.Log ("The remaining time is " + currentTime.TimeScore);
		currentTime.IsTimeEnd = true;
		ReciptUI.enabled = false;
        BlockerLeft.enabled = false;
        BlockerRight.enabled = false;
		isStart = true;
	}
    public void NextRecipe ()
    {
        if (PageCounter + 1 < numOfDish)
        {
            PageCounter += 1;
            changePage = true;
            Debug.Log("true n" + PageCounter);
        }
        else
        {
            changePage = false;
            Debug.Log("false" + PageCounter);
        }
    }
    public void PreviousRecipe()
    {
        if (PageCounter !=0 )
        {
            PageCounter -= 1;
            changePage = true;
            Debug.Log("true p" + PageCounter);
        }
        else
        {
            changePage = false;
            Debug.Log("false" + PageCounter);
        }
    }
}
