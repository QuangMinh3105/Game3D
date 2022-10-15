using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    int items = 0;
    [SerializeField] Text itemsText;
    [SerializeField] AudioSource collectingSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            Destroy(other.gameObject);
            items++;
            itemsText.text = "Points: " + items;
            collectingSound.Play();
        }    
    }
}
