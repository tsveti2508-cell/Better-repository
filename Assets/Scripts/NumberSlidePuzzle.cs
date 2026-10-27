using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class NumberSlidePuzzle : MonoBehaviour
{
    [Header("Puzzle Buttons")]
    public Button[] buttons = new Button[9];
    [Header("Puzzle Settings")]
    [Min(1)]
    public int shuffleMoves = 40;
    [Header("Completion")]
    public GameObject strandsHint;
    [Header("Optional")]
    public GameObject puzzlePanelToHide;
    private int[] tiles = new int[9];
    private bool solved = false;
    private bool initialized = false;
    private void Awake()
    {
        InitializePuzzle();
    }
    private void InitializePuzzle()
    {
        if (initialized)
            return;
        // Check that all buttons are assigned
        if (buttons == null || buttons.Length != 9)
        {
            Debug.LogError(
            "NumberSlidePuzzle: Exactly 9 buttons are required!"
            );
            return;
        }
        for (int i = 0; i < 9; i++)
        {
            if (buttons[i] == null)
            {
                Debug.LogError(
                "NumberSlidePuzzle: Button " + i + " is missing!"
                );
                return;
            }
        }
        initialized = true;
        // Connect buttons to puzzle logic
        for (int i = 0; i < 9; i++)
        {
            int index = i;
            buttons[i].onClick.AddListener(
            () => MoveTile(index)
            );
        }
        // Hide the completion hint
        if (strandsHint != null)
        {
            strandsHint.SetActive(false);
        }
        ShufflePuzzle();
        UpdateVisuals();
    }
    private void ShufflePuzzle()
    {
        // Start with solved puzzle
        for (int i = 0; i < 8; i++)
        {
            tiles[i] = i + 1;
        }
        tiles[8] = 0;
        int emptyIndex = 8;
        int previousIndex = -1;
        // Shuffle using only valid movements
        for (int i = 0; i < shuffleMoves; i++)
        {
            int[] possibleMoves = new int[4];
            int count = 0;
            for (int j = 0; j < 9; j++)
            {
                if (IsAdjacent(j, emptyIndex) &&
                j != previousIndex)
                {
                    possibleMoves[count] = j;
                    count++;
                }
            }
            if (count == 0)
                continue;
            int randomMove =
            possibleMoves[UnityEngine.Random.Range(0, count)];
            tiles[emptyIndex] = tiles[randomMove];
            tiles[randomMove] = 0;
            previousIndex = emptyIndex;
            emptyIndex = randomMove;
        }
        // Make sure puzzle is not already solved
        if (IsSolved())
        {
            ShufflePuzzle();
        }
    }
    private bool IsAdjacent(int a, int b)
    {
        int rowA = a / 3;
        int colA = a % 3;
        int rowB = b / 3;
        int colB = b % 3;
        return Mathf.Abs(rowA - rowB) +
        Mathf.Abs(colA - colB) == 1;
    }
    public void MoveTile(int index)
    {
        if (!initialized || solved)
            return;
        if (index < 0 || index >= 9)
            return;
        int emptyIndex = Array.IndexOf(tiles, 0);
        // Only allow movement next to empty space
        if (!IsAdjacent(index, emptyIndex))
            return;
        // Swap tile with empty space
        tiles[emptyIndex] = tiles[index];
        tiles[index] = 0;
        UpdateVisuals();
        // Check if puzzle is completed
        if (IsSolved())
        {
            CompletePuzzle();
        }
    }
    private void UpdateVisuals()
    {
        for (int i = 0; i < 9; i++)
        {
            TMP_Text buttonText =
            buttons[i].GetComponentInChildren<TMP_Text>();
            if (buttonText != null)
            {
                buttonText.text =
                tiles[i] == 0 ? "" : tiles[i].ToString();
            }
            // Empty space cannot be clicked
            buttons[i].interactable = tiles[i] != 0;
            // Hide the image of the empty tile
            Image buttonImage = buttons[i].GetComponent<Image>();
            if (buttonImage != null)
            {
                buttonImage.enabled = tiles[i] != 0;
            }
        }
    }
    private bool IsSolved()
    {
        for (int i = 0; i < 8; i++)
        {
            if (tiles[i] != i + 1)
                return false;
        }
        return tiles[8] == 0;
    }
    private void CompletePuzzle()
    {
        solved = true;
        Debug.Log("NUMBER SLIDE PUZZLE COMPLETED!");
        // Show clue for next puzzle
        if (strandsHint != null)
        {
            strandsHint.SetActive(true);
        }
        // Optional: Hide the number puzzle
        if (puzzlePanelToHide != null)
        {
            puzzlePanelToHide.SetActive(false);
        }
    }
    public void ResetPuzzle()
    {
        solved = false;
        if (strandsHint != null)
        {
            strandsHint.SetActive(false);
        }
        if (puzzlePanelToHide != null)
        {
            puzzlePanelToHide.SetActive(true);
        }
        ShufflePuzzle();
        UpdateVisuals();
    }
}