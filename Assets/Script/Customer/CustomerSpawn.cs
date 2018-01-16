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

    public string chosenDish;
    public int totalCustomer;
    private int customerServed = 0;

    public int minSpawnWait, maxSpawnWait;
    private int spawnWait;

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
        string[] dish = new string[totalCustomer];

        yield return new WaitUntil(() => recipeManager.isStart);
        List<string> recipe = new List<string>(recipeManager.chosenDish);

        for (int i = 0; i < totalCustomer; i++)
        {
            spawnWait = Random.Range(minSpawnWait, maxSpawnWait);
            yield return new WaitUntil(() => !currentCustomer);
            yield return new WaitForSeconds(spawnWait);

            dish[i] = recipe[Random.Range(0, recipe.Count)];
            chosenDish = dishText.text = dish[i];
            bubble.SetActive(true);

            if (totalCustomer - customerServed <= recipe.Count)
                recipe.Remove(dish[i]);

            audioManager.Play("Walk");
            randCustomer = customers[Random.Range(0, customers.Count)];
            currentCustomer = Instantiate(randCustomer, transform.position, transform.rotation);
            customers.Remove(randCustomer);
            currentCustomer.transform.parent = gameObject.transform;
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