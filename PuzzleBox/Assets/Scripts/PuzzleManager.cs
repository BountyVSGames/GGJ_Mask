using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class PuzzleManager : MonoBehaviour
{
    public List<Puzzle> PuzzlesToSpawn;
    private List<Puzzle> activePuzzles = new List<Puzzle>();

    public List<GameObject> puzzleLocations;

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
        for (int i = 0; i < puzzleLocations.Count; i++)
        {
            Transform puzzleTransform = puzzleLocations[i].transform;

            Vector3 position = new Vector3(puzzleTransform.position.x, puzzleTransform.position.y, puzzleTransform.position.z);

            if (PuzzlesToSpawn[i] != null) 
            {
                var newPuzzle = Instantiate(PuzzlesToSpawn[i], position, puzzleTransform.rotation);
                newPuzzle.transform.SetParent(puzzleTransform);
                Vector3 scale = new Vector3(1f,1f,1f);
                newPuzzle.transform.localScale = scale;
                activePuzzles.Add(newPuzzle);
            }
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
