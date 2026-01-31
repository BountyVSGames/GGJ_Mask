using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public List<Puzzle> PuzzlesToSpawn;
    private List<Puzzle> activePuzzles = new List<Puzzle>();

    private bool allPuzzlesUnlocked = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnPuzzles();
    }

    // Update is called once per frame
    void Update()
    {
        if (!allPuzzlesUnlocked) 
        {
            CheckPuzzles();
        }
    }

    private void SpawnPuzzles() 
    {
        for (int i = 0; i < PuzzlesToSpawn.Count; i++) 
        {
            Vector3 position = new Vector3(i * 3, transform.position.y, transform.position.z);
            var newPuzzle = Instantiate(PuzzlesToSpawn[i], position, Quaternion.identity);

            activePuzzles.Add(newPuzzle);
        }
    }

    private void CheckPuzzles() 
    {
        foreach (Puzzle p in activePuzzles)
        {
            if(p.isUnlocked == false)
            {
                return;
            }
        }

        Debug.Log("All Puzzles Unlocked");
        allPuzzlesUnlocked = true;
    }
}
