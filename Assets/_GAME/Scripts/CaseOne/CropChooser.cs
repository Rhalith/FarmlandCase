using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Scripts.CaseOne
{
    public class CropChooser : MonoBehaviour
    {
        [SerializeField] private Crop strawberryPrefab;
        [SerializeField] private Crop pumpkinPrefab;
        
        public static CropChooser Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject); // Prevent duplicate instances
                return;
            }
        }

        public Crop SelectCrop()
        {
            return (Random.Range(0, 2) == 0) ? strawberryPrefab : pumpkinPrefab;
        }
    }
}