using System.Runtime.CompilerServices;
using UnityEngine;

public class slidingpuzzlegamemanager : MonoBehaviour
{
    [SerializeField] private Transform gameTransform;
    [SerializeField] private Transform piecePrefab;

    private int emptylocation;
    private int size;

    private void CreateGamePieces(float gapThickness)
    {
        //make board width 1 in total, so 3 squares in width 1, bc size = 3
        float width = 1 / (float)size;
        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                Transform piece = Instantiate(piecePrefab, gameTransform);
                // centre the puzzle on x and y axes
                piece.localPosition = new Vector3(0, +1 - (2 * width * row) - width, -1 + (2 * width * col) + width);
                piece.localScale = ((2 * width) - gapThickness) * Vector3.one;
                piece.name = $"{(row * size) + col}";
                // empty on bottom right
                if ((row == size - 1) && (col == size - 1))
                {
                    emptylocation = (size * size) - 1;
                    piece.gameObject.SetActive(false);
                }
                else
                {
                    float gap = gapThickness / 2;
                    Mesh mesh = piece.GetComponent<MeshFilter>().mesh;
                    Vector2[] uv = new Vector2[4];
                    uv[0] = new Vector2((width * col) + gap, 1 - ((width * (row + 1)) - gap));
                    uv[1] = new Vector2((width * (col + 1)) - gap, 1 - ((width * (row + 1)) - gap));
                    uv[2] = new Vector2((width * col) + gap, 1 - ((width * row) + gap));
                    uv[3] = new Vector2((width * (col + 1)) - gap, 1 - ((width * row) + gap));

                    mesh.uv = uv;
                }


            }
        }

    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        size = 3;
        CreateGamePieces(0.01f);
    }

    // Update is called once per frame
  
}
    

