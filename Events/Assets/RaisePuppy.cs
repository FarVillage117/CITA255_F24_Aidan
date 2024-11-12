using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaisePuppy
{
    private Dog dog;
    private DogHappy dogHappy;
    private DogHealth dogHealth;

    private void Start()
    {
        // Initialize the Dog instance
        dog = new Dog();

        // Get references to DogHappy and DogHealth components (attach these scripts to the same GameObject)
        dogHappy = GetComponent<DogHappy>();
        dogHealth = GetComponent<DogHealth>();

        // Subscribe DogHappy and DogHealth to Dog events
        dogHappy.SubscribeToDogEvents(dog);
        dogHealth.SubscribeToDogEvents(dog);
    }

    private void Update()
    {
        // Here, you could add simple input controls to call methods and simulate interactions with the puppy.

        if (Input.GetKeyDown(KeyCode.E)) // Press E to simulate the puppy eating
        {
            Debug.Log("Puppy is eating...");
            dog.Eat();
        }

        if (Input.GetKeyDown(KeyCode.P)) // Press P to simulate the puppy playing
        {
            Debug.Log("Puppy is playing...");
            dog.Play();
        }

        if (Input.GetKeyDown(KeyCode.S)) // Press S to simulate the puppy sleeping
        {
            Debug.Log("Puppy is sleeping...");
            dog.Sleeps();
        }
    }
}
