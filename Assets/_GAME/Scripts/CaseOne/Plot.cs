using UnityEngine;

namespace Scripts.CaseOne
{
    /// <summary>
    /// Represents a single plot that can hold a crop. The player can click on
    /// the plot to plant a new crop or harvest an existing one.
    /// </summary>
    public class Plot : MonoBehaviour
    {
        // Reference to the crop instance planted in this plot (if any).
        private Crop plantedCrop;
    
        /// <summary>
        /// Detects clicks on the plot. Plants a new crop if empty, or harvests if fully grown.
        /// </summary>
        private void OnMouseDown()
        {
            // Randomly choose which crop to plant (strawberry or pumpkin).
            var chosenCrop = CropChooser.Instance.SelectCrop();
            if (chosenCrop == null) return; // If no crop was chosen, just return.

            if (IsEmpty())
            {
                // If no crop is currently planted, then plant a new one.
                PlantCrop(chosenCrop);
            }
            else if (plantedCrop.IsFullyGrown())
            {
                // If the plot is not empty and the crop is fully grown, harvest it.
                HarvestCrop();
            }
        }

        /// <summary>
        /// Instantiates a crop at the plot's location and starts its growth process.
        /// </summary>
        private void PlantCrop(Crop cropPrefab)
        {
            // Prevent planting if a crop is already there.
            if (!IsEmpty()) return;

            // Create the new crop as a child of this plot.
            plantedCrop = Instantiate(cropPrefab, transform.position, Quaternion.identity, transform);
            plantedCrop.StartGrowing();
        }

        /// <summary>
        /// Harvests the fully-grown crop by destroying its GameObject.
        /// </summary>
        private void HarvestCrop()
        {
            // Only allow harvesting if there's a crop and it's fully grown.
            if (IsEmpty() || !plantedCrop.IsFullyGrown()) return;

            // Remove the crop from the plot.
            Destroy(plantedCrop.gameObject);
            plantedCrop = null;
        }

        /// <summary>
        /// Checks if this plot currently has no crop planted.
        /// </summary>
        private bool IsEmpty() => plantedCrop == null;
    }
}
