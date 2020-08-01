using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardRuneSlot : MonoBehaviour
{

    public Rune runePrefab;
    public Rune rune;
    public GameObject mountLocation;

    // Start is called before the first frame update
    void Start()
    {
        rune = Instantiate(runePrefab, mountLocation.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
