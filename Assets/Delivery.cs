using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] float waitToDestroy = 0.2f;

    //Let us create a logic such that when the package is picked the color of the car changes
    [SerializeField] Color32 colorWhenPicked = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 colorWhenNoPackage = new Color32(1, 1, 1, 1);

    //We create a spriterenderer component so that it can be accessed and modified through the code
    SpriteRenderer spriteRenderer;

    void Start() //We have to initialise the spriterenderer object/component in the start so that it is created only once at the start and can be used on different objects.
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    //This is the boolean for determining whether the package is picked up or not. This helps us make sure that only one package is picked and delivered at one time
    bool packagePicked = false;

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("There has been a collision");
    }

    private void OnTriggerEnter2D(Collider2D other) //Other is the object that we're colliding with. While checking for tags for the if statement, we essentaially question if this other parameter has a tag that we're searching for.
    {
        if (other.tag == "Package" && !packagePicked)
        {
            Debug.Log("You have picked up the package!!");
            packagePicked = true;
            spriteRenderer.color = colorWhenPicked;
            Destroy(other.gameObject, waitToDestroy);
        }

        if (other.tag == "Customer")
        {
            if (packagePicked == true)
            {
                Debug.Log("Package delivered");
                packagePicked = false;
                spriteRenderer.color = colorWhenNoPackage;
            }
            else
            {
                Debug.Log("Where's the package??");
            }
        }
    }
}
