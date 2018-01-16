using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerSpawn : MonoBehaviour {

    public List<GameObject> customers;
    private GameObject currentCustomer;
	public RecipeManager rm;
    public Text dishText;
    public Image bubble;
    private GameObject randCustomer;
    private AudioSource walkSound;

    public string chosenDish;
    private string[] dish;

    public int totalCustomer;
    private int customerServed = 0;

    public int minSpawnWait, maxSpawnWait;
    private int spawnWait;

    public bool killMode;
    
	void Start ()
    {
        walkSound = GameObject.Find("WalkSound").GetComponent<AudioSource>();
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

        // End game
        if (customerServed == totalCustomer)
        {

        }
    }

    IEnumerator spawnCustomer()
    {
		yield return new WaitUntil(() => rm.isStart);
		List<string> recipe = new List<string> (rm.chosenDish);
		dish = new string[totalCustomer];

        for (int i = 0; i < totalCustomer; i++)
        {
            yield return new WaitUntil(() => !currentCustomer);
            spawnWait = Random.Range(minSpawnWait, maxSpawnWait);
            yield return new WaitForSeconds(spawnWait);

			dish[i] = recipe[Random.Range (0, recipe.Count)];
            dishText.text = dish[i];
            dishText.enabled = true;
            bubble.enabled = true;
            chosenDish = dish[i];

			if (totalCustomer - customerServed <= recipe.Count)
			    recipe.Remove(dish[i]);

            randCustomer = customers[Random.Range(0, customers.Count)];
            currentCustomer = Instantiate(randCustomer, transform.position, transform.rotation);
            walkSound.Play();
            customers.Remove(randCustomer);
            currentCustomer.transform.parent = gameObject.transform;
        }
    }

    public void destroyCustomer()
    {
        Destroy(currentCustomer);
        dishText.enabled = false;
        dishText.text = "";
        bubble.enabled = false;
        currentCustomer = null;
        walkSound.Play();
        customerServed++;
    }
}