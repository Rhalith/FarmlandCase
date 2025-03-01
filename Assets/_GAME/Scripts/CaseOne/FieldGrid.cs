using UnityEngine;

namespace Scripts.CaseOne
{
    public class FieldGrid : MonoBehaviour
    {
        [SerializeField] private int gridWidth = 5;
        [SerializeField] private int gridHeight = 5;
        [SerializeField] private float plotSpacing = 1f; // Ensure proper spacing
        [SerializeField] private GameObject plotPrefab; // Assign in Inspector
        [SerializeField] private Transform planeTransform; // Assign the plane in Inspector
    

        private void Start()
        {
            GenerateGrid();
        }

        private void GenerateGrid()
        {

            float offsetX = (gridWidth - 1) * plotSpacing * 0.5f;
            float offsetZ = (gridHeight - 1) * plotSpacing * 0.5f;

            Vector3 planeCenter = planeTransform.position;

            for (int x = 0; x < gridWidth; x++)
            {
                for (int y = 0; y < gridHeight; y++)
                
                {
                    Vector3 position = new Vector3(
                        planeCenter.x + (x * plotSpacing - offsetX),
                        planeCenter.y + 0.01f, 
                        planeCenter.z + (y * plotSpacing - offsetZ)
                    );
                
                    Quaternion rotation = Quaternion.Euler(-90, 0, 0);
                    Instantiate(plotPrefab, position, rotation, transform);
                }
            }
        }
    }
}