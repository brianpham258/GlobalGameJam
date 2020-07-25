using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] int foodPickUp = 200;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<GameDataS>().staminaToAdd(foodPickUp);
        Destroy(gameObject);
    }
}
