using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerSpawn : MonoBehaviour
{

    public List<GameObject> customers;
    public GameObject bubble;
    public RecipeManager recipeManager;
    private GameObject currentCustomer;
    private Text dishText;
    private AudioManager audioManager;

    [HideInInspector]
    public string chosenDish;
    public int totalCustomer;
    public int minSpawnWait;
    public int maxSpawnWait;
    private int customerServed = 0;

    public bool killMode;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        dishText = bubble.GetComponentInChildren<Text>();
        StartCoroutine(spawnCustomer());
    }

    void Update()
    {
        if (killMode)
        {
            killMode = false;

            if (currentCustomer)
                destroyCustomer();
        }
    }

    IEnumerator spawnCustomer()
    {
        GameObject randCustomer;
        string randRecipe;

        yield return new WaitUntil(() => recipeManager.isStart);
        List<string> recipe = new List<string>(recipeManager.chosenDish);

        for (int i = 0; i < totalCustomer; i++)
        {
            yield return new WaitUntil(() => !currentCustomer);
            yield return new WaitForSeconds(Random.Range(minSpawnWait, maxSpawnWait));

            randRecipe = recipe[Random.Range(0, recipe.Count)];
            chosenDish = dishText.text = randRecipe;
            bubble.SetActive(true);

            if (totalCustomer - customerServed <= recipe.Count)
                recipe.Remove(randRecipe);

            audioManager.Play("Walk");
            randCustomer = customers[Random.Range(0, customers.Count)];
            currentCustomer = Instantiate(randCustomer, transform.position, transform.rotation);
            currentCustomer.transform.parent = gameObject.transform;
            customers.Remove(randCustomer);
        }
    }

    public void destroyCustomer()
    {
        Destroy(currentCustomer);
        bubble.SetActive(false);
        currentCustomer = null;
        customerServed++;
    }
}