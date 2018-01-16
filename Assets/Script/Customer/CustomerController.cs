using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerController : MonoBehaviour
{

    public Sprite tick;
    public Sprite cross;
    private Image answerImage;
    private Inventory inventory;
    private CustomerSpawn CS;
    private int destroyWait = 5;
    private AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        answerImage = GameObject.Find("AnswerImage").GetComponent<Image>();
    }

    public void CheckFood()
    {
        inventory = FindObjectOfType<Inventory>();
        inventory.GetItemInList();
        Item[] PlayerSelectedFood = inventory.GetItemInList();
        CS = FindObjectOfType<CustomerSpawn>();
        Recipe CorrectRecipeFoods = Resources.Load<Recipe>("recipes/" + CS.chosenDish);
        int counter = CorrectRecipeFoods.foods.Length;
        int PlayerSelectedLength = PlayerSelectedFood.Length;

        for (var i = 0; i < CorrectRecipeFoods.foods.Length; i++)
        {
            bool correct = false;

            for (var k = 0; k < PlayerSelectedLength; k++)
            {
                if (CorrectRecipeFoods.foods[i] == PlayerSelectedFood[k])
                {
                    PlayerSelectedFood[k] = null;
                    counter--;
                    Debug.Log("counter:" + counter);
                    correct = true;
                    break;
                }
            }

            if (correct == false)
            {
                setWrong();
                return;
            }

            if (counter == 0)
            {
                for (var k = 0; k < PlayerSelectedLength; k++)
                {
                    if (PlayerSelectedFood[k] != null)
                    {
                        setWrong();
                        return;
                    }
                }

                setCorrect();
                CS = FindObjectOfType<CustomerSpawn>();
                CS.Invoke("destroyCustomer", destroyWait);
            }
        }
    }

    private void setCorrect()
    {
        Debug.Log("Selected Food correct!!!!!");
        answerImage.sprite = tick;
        answerImage.enabled = true;
        audioManager.Play("Correct");
        Invoke("destroySet", destroyWait);
    }

    private void setWrong()
    {
        Debug.Log("Selected Food incorrect");
        answerImage.sprite = cross;
        answerImage.enabled = true;
        audioManager.Play("Wrong");
        Invoke("destroySet", destroyWait);
    }

    private void destroySet()
    {
        answerImage.enabled = false;
    }
}