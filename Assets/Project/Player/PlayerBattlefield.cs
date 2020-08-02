using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattlefield : MonoBehaviour
{
    public int MaximumRuneSlots = 5;
    public int StartingRuneSlots = 5;
    public List<RuneSlot> RuneSlots;

    public GameObject RuneSlotPrefab;

    // Start is called before the first frame update
    void Start()
    {
        RuneSlots = new List<RuneSlot>(MaximumRuneSlots);

        CreateStartingRuneSlots();
    }

    void CreateStartingRuneSlots()
    {
        const float distanceBetweenRuneSlots = 0.1f;
        float handWidth = (StartingRuneSlots - 1) * distanceBetweenRuneSlots;
        for (int i = 0; i < StartingRuneSlots; i++)
        {
            GameObject go = Instantiate(RuneSlotPrefab);
            RuneSlot runeSlot = go.GetComponent<RuneSlot>();
            runeSlot.transform.parent = transform;
            runeSlot.transform.localPosition = new Vector3(-handWidth / 2.0f + (i * distanceBetweenRuneSlots), 0, 0);

            RuneSlots.Add(runeSlot);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
