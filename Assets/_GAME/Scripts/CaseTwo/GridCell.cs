using UnityEngine;

namespace CaseTwo
{
    public class GridCell : MonoBehaviour
    {
        [SerializeField] private Color availableColor = new Color(0, 0, 1, 0.3f);
        [SerializeField] private Color occupiedColor = new Color(0, 0, 1, 0f);
        [SerializeField] private GameObject buildingPrefab;

        private MeshRenderer _renderer;
        private BuildingGrid _grid;
        private Vector2Int _gridPos;
        private GameObject _currentBuilding;

        public void Initialize(BuildingGrid grid, Vector2Int gridPos)
        {
            _grid = grid;
            _gridPos = gridPos;
            _renderer = GetComponent<MeshRenderer>();
            SetAvailable();
        }

        private void OnMouseDown()
        {
            _grid.ToggleBuilding(_gridPos);
        }

        public void ToggleBuilding()
        {
            if (_currentBuilding == null)
            {
                _currentBuilding = Instantiate(buildingPrefab, transform.position + Vector3.up * 0.5f, Quaternion.identity, transform);
                SetOccupied();
            }
            else
            {
                Destroy(_currentBuilding);
                SetAvailable();
            }
        }

        private void SetAvailable()
        {
            _renderer.material.color = availableColor;
        }

        private void SetOccupied()
        {
            _renderer.material.color = occupiedColor;
        }
    }
}