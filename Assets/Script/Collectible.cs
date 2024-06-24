using System.Collections.Generic;
using UnityEngine;

public class CollectionController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController.collectedAmount++;
            Destroy(gameObject);
        }
    }
}
