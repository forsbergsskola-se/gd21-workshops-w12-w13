using System;
using UnityEngine;

public class EnergyColorChanger : MonoBehaviour
{
    [SerializeField] private EnergyContainer energyContainer;
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private Color emptyColor = Color.grey;
    [SerializeField] private Color fullColor = Color.blue;

    private Material materialInstance;

    private void Start() => materialInstance = meshRenderer.material;
    private void OnDestroy() => Destroy(materialInstance);

    private void Update()
    {
        materialInstance.SetColor("_BaseColor", Color.Lerp(emptyColor, fullColor, energyContainer.EnergyFraction));
    }
}