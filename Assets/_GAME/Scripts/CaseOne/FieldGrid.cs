using UnityEngine;

namespace Scripts.CaseOne
{
    /// <summary>
    /// Generates a grid of "plots" on a plane.
    /// </summary>
    public class FieldGrid : MonoBehaviour
    {
        [SerializeField] private int gridWidth = 5;    // Number of plots along the x-axis.
        [SerializeField] private int gridHeight = 5;   // Number of plots along the z-axis.
        [SerializeField] private float plotSpacing = 1f; // Distance between the centers of each plot.
        [SerializeField] private GameObject plotPrefab;   // Prefab for the individual plot.
        [SerializeField] private Transform planeTransform; // Reference to the plane on which plots will be placed.
    
        private void Start()
        {
            // Create the grid of plots when the game starts.
            GenerateGrid();
        }

        /// <summary>
        /// Instantiates a grid of plots, arranged based on the specified width, height, and spacing.
        /// </summary>
        private void GenerateGrid()
        {
            // Calculate offsets so that the grid is centered around the plane's position.
            float offsetX = (gridWidth - 1) * plotSpacing * 0.5f;
            float offsetZ = (gridHeight - 1) * plotSpacing * 0.5f;

            // This is the center of the plane from which we offset the plots.
            Vector3 planeCenter = planeTransform.position;

            // Loop through the width and height to place each plot.
            for (int x = 0; x < gridWidth; x++)
            {
                for (int y = 0; y < gridHeight; y++)
                {
                    // Calculate the position for this plot in the grid.
                    Vector3 position = new Vector3(
                        planeCenter.x + (x * plotSpacing - offsetX),
                        planeCenter.y + 0.01f, 
                        planeCenter.z + (y * plotSpacing - offsetZ)
                    );
                    
                    // Rotate the plot so it faces up/down (depending on the model).
                    Quaternion rotation = Quaternion.Euler(-90, 0, 0);

                    // Instantiate a new plot at the calculated position.
                    Instantiate(plotPrefab, position, rotation, transform);
                }
            }
        }
    }
}
