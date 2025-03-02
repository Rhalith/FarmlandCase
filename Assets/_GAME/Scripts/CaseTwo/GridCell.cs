using UnityEngine;

namespace CaseTwo
{
    /// <summary>
    /// Represents a single cell in the building grid that can be toggled to
    /// place or remove a building.
    /// </summary>
    public class GridCell : MonoBehaviour
    {
        [SerializeField] private Color availableColor = new Color(0, 0, 1, 0.3f); // Cell color when it has no building.
        [SerializeField] private Color occupiedColor = new Color(0, 0, 1, 0f);   // Cell color when it has a building.
        [SerializeField] private GameObject buildingPrefab;                     // Prefab for the building placed on this cell.

        private MeshRenderer _renderer; // Reference to this cell's MeshRenderer to change its color.
        private BuildingGrid _grid;     // Reference back to the parent grid.
        private Vector2Int _gridPos;    // The x,y coordinates of this cell in the grid.
        private GameObject _currentBuilding; // A reference to the building placed on this cell, if any.

        /// <summary>
        /// Initializes the grid cell with references to its parent grid and grid coordinates.
        /// Also sets the cell's initial appearance to "available".
        /// </summary>
        /// <param name="grid">Reference to the BuildingGrid this cell belongs to.</param>
        /// <param name="gridPos">Coordinates of this cell in the grid.</param>
        public void Initialize(BuildingGrid grid, Vector2Int gridPos)
        {
            _grid = grid;
            _gridPos = gridPos;
            _renderer = GetComponent<MeshRenderer>();
            SetAvailable();
        }

        /// <summary>
        /// Called by Unity when the user clicks on the GameObject’s collider.
        /// Toggles the building on this cell via the parent grid.
        /// </summary>
        private void OnMouseDown()
        {
            _grid.ToggleBuilding(_gridPos);
        }

        /// <summary>
        /// Toggles the presence of a building on this cell. If there's no building, create one.
        /// If there is already a building, remove it.
        /// </summary>
        public void ToggleBuilding()
        {
            if (_currentBuilding == null)
            {
                // Instantiate a buildingPrefab slightly above the cell.
                _currentBuilding = Instantiate(buildingPrefab, transform.position + Vector3.up * 0.5f, Quaternion.identity, transform);
                SetOccupied();
            }
            else
            {
                // Destroy the existing building and mark the cell as available.
                Destroy(_currentBuilding);
                SetAvailable();
            }
        }

        /// <summary>
        /// Sets the cell to a color that indicates it has no building.
        /// </summary>
        private void SetAvailable()
        {
            _renderer.material.color = availableColor;
        }

        /// <summary>
        /// Sets the cell to a color that indicates it is occupied by a building.
        /// </summary>
        private void SetOccupied()
        {
            _renderer.material.color = occupiedColor;
        }
    }
}
