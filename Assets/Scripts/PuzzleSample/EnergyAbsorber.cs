using UnityEngine;

public class EnergyAbsorber : MonoBehaviour
{
    [SerializeField] private EnergyContainer targetEnergyContainer;
    [SerializeField] private float absorptionSpeed = 10f;

    private void OnTriggerStay(Collider other)
    {
        if (!other.TryGetComponent<EnergyContainer>(out var otherEnergyContainer))
            return; //If other doesn't have an EnergyContainer, then return immediately.

        //Make sure we don't absorb more energy than otherEnergyContainer has available.
        var absorption = Mathf.Clamp(absorptionSpeed * Time.deltaTime, 0, otherEnergyContainer.Energy);

        //Remove energy from otherEnergyContainer by adding negative absorption.
        otherEnergyContainer.AddEnergy(-absorption);
        //Add energy to energyContainerToPutEnergyInto.
        targetEnergyContainer.AddEnergy(absorption);
    }
}