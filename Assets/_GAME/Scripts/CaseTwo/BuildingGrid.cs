using UnityEngine;

namespace CaseTwo
{
    public class BuildingGrid : MonoBehaviour
    {
        [SerializeField] private int width = 10;
        [SerializeField] private int height = 10;
        [SerializeField] private float cellSize = 1f;
        [SerializeField] private GameObject gridCellPrefab;

        private GridCell[,] _gridCells;
        private Vector3 _gridOffset;

        private void Start()
        {
            _gridCells = new GridCell[width, height];
            
            float xOffset = (width * cellSize) / 2f - (cellSize / 2f);
            float yOffset = (height * cellSize) / 2f - (cellSize / 2f);
            _gridOffset = new Vector3(-xOffset, 0, -yOffset);

            GenerateGrid();
        }

        private void GenerateGrid()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Vector3 worldPos = new Vector3(x * cellSize, 0, y * cellSize) + _gridOffset;
                    GameObject cell = Instantiate(gridCellPrefab, worldPos, Quaternion.identity, transform);
                    GridCell gridCell = cell.GetComponent<GridCell>();
                    gridCell.Initialize(this, new Vector2Int(x, y));
                    _gridCells[x, y] = gridCell;
                }
            }
        }

        public void ToggleBuilding(Vector2Int gridPos)
        {
            _gridCells[gridPos.x, gridPos.y].ToggleBuilding();
        }
    }
}