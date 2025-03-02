using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Scripts.CaseOne
{
    /// <summary>
    /// Chooses which crop (strawberry or pumpkin) will be planted.
    /// </summary>
    public class CropChooser : MonoBehaviour
    {
        [SerializeField] private Crop strawberryPrefab; // Assign the strawberry crop prefab in the Inspector.
        [SerializeField] private Crop pumpkinPrefab;    // Assign the pumpkin crop prefab in the Inspector.
        
        // A singleton instance for global access.
        public static CropChooser Instance { get; private set; }

        private void Awake()
        {
            // Ensure only one instance of CropChooser exists.
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                // If another instance exists, destroy this one.
                Destroy(gameObject);
                return;
            }
        }

        /// <summary>
        /// Returns either a strawberry or a pumpkin crop randomly.
        /// </summary>
        public Crop SelectCrop()
        {
            // Random.Range(0,2) will return either 0 or 1.
            return (Random.Range(0, 2) == 0) ? strawberryPrefab : pumpkinPrefab;
        }
    }
}