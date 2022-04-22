using UnityEngine;
using UnityEngine.Events;

public class EnergyContainer : MonoBehaviour
{
    [SerializeField] private float maxEnergy = 100f;
    [SerializeField] private float energy;
    [SerializeField] private UnityEvent onFullyCharged; //Could make this public.

    public float Energy => energy; //Public getter
    public float EnergyFraction => energy / maxEnergy;

    //Pass in a negative value to remove energy. Could also be separated into one method for adding, and another method for removing.
    public void AddEnergy(float energyToAdd)
    {
        energy += energyToAdd;

        if (energy >= 100)
        {
            onFullyCharged.Invoke();
        }

        energy = Mathf.Clamp(energy, 0, maxEnergy);
    }
}