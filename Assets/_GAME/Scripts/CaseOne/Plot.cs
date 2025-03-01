using UnityEngine;

namespace Scripts.CaseOne
{
    public class Plot : MonoBehaviour
    {
        private Crop plantedCrop;
    

        private void OnMouseDown()
        {
            var chosenCrop = CropChooser.Instance.SelectCrop();
            if (chosenCrop == null) return;

            if (IsEmpty())
            {
                PlantCrop(chosenCrop);
            }
            else if (plantedCrop.IsFullyGrown())
            {
                HarvestCrop();
            }
        }

        private void PlantCrop(Crop cropPrefab)
        {
            if (!IsEmpty()) return;

            plantedCrop = Instantiate(cropPrefab, transform.position, Quaternion.identity, transform);
            plantedCrop.StartGrowing();
        }

        private void HarvestCrop()
        {
            if (IsEmpty() || !plantedCrop.IsFullyGrown()) return;

            Destroy(plantedCrop.gameObject);
            plantedCrop = null;
        }

        private bool IsEmpty() => plantedCrop == null;
    }
}