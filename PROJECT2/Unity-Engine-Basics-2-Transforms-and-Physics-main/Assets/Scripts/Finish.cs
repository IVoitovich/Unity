using System;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerController player))
        {
            Debug.Log("You win!");
            Destroy(player.gameObject);
        }
    }
}
