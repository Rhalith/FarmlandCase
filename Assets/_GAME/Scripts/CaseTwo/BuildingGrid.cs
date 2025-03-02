using UnityEngine;

namespace CaseTwo
{
    /// <summary>
    /// Manages the grid of cells for placing and toggling buildings.
    /// </summary>
    public class BuildingGrid : MonoBehaviour
    {
        [SerializeField] private int width = 10;      // The number of cells in the horizontal direction.
        [SerializeField] private int height = 10;     // The number of cells in the vertical direction.
        [SerializeField] private float cellSize = 1f; // The distance between the centers of each cell.
        [SerializeField] private GameObject gridCellPrefab; // Prefab for the individual grid cell.

        // 2D array to store references to the created GridCell objects.
        private GridCell[,] _gridCells;

        // Used to offset the entire grid, so it's centered around the origin (or another reference point).
        private Vector3 _gridOffset;

        private void Start()
        {
            // Initialize the 2D array based on the width and height.
            _gridCells = new GridCell[width, height];

            // Calculate offsets so that the grid is centered around (0,0,0).
            float xOffset = (width * cellSize) / 2f - (cellSize / 2f);
            float yOffset = (height * cellSize) / 2f - (cellSize / 2f);
            _gridOffset = new Vector3(-xOffset, 0, -yOffset);

            // Generate the grid of cells once the script starts.
            GenerateGrid();
        }

        /// <summary>
        /// Instantiates grid cells in a 2D loop and stores them in the _gridCells array.
        /// </summary>
        private void GenerateGrid()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    // Calculate the position of this cell in world space.
                    Vector3 worldPos = new Vector3(x * cellSize, 0, y * cellSize) + _gridOffset;

                    // Create a new cell from the provided prefab.
                    GameObject cell = Instantiate(gridCellPrefab, worldPos, Quaternion.identity, transform);

                    // Get the GridCell component from the newly instantiated cell.
                    GridCell gridCell = cell.GetComponent<GridCell>();

                    // Pass a reference to this grid and the cell's position to the GridCell component.
                    gridCell.Initialize(this, new Vector2Int(x, y));

                    // Store the reference to this grid cell in the _gridCells array.
                    _gridCells[x, y] = gridCell;
                }
            }
        }

        /// <summary>
        /// Toggles whether a specific cell at gridPos has a building or not.
        /// </summary>
        /// <param name="gridPos">The coordinates of the cell in the grid.</param>
        public void ToggleBuilding(Vector2Int gridPos)
        {
            _gridCells[gridPos.x, gridPos.y].ToggleBuilding();
        }
    }
}
