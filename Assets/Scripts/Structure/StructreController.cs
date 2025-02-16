using System;
using System.Components;
using DG.Tweening;
using UnityEngine;

public class StructreController : MonoBehaviour, IHealth
{
    public int maxHeal = 20;
    public int currentHeal;
    public int maxRepair;
    public int repairValue;
    
    public float repairDuration;
    public bool isRepairing;
    public bool repairFinished;
    public event Action<StructreController> OnStructureBuilt;
    public event Action OnrepairStarted;

    private Tween repairTween; // Reference to the DOTween animation
    
    public event Action<float> OnHealthChanged;
    public event Action<float> OnRepairChanged;


    private void Start()
    {
        currentHeal = maxHeal;
    }

 

    public void StartRepair()
    {
        repairTween = DOTween.To(() => (float)repairValue, x => repairValue = Mathf.RoundToInt(x), (float)maxRepair, repairDuration)
            .OnUpdate(() =>
            {
                OnRepairChanged?.Invoke(repairValue);
            })
            .OnComplete(() => 
            {
                repairFinished = true;
                isRepairing = false;
                OnStructureBuilt?.Invoke(this);

                Debug.Log("Repair Finished");
            }).OnStart(() =>
            {
                OnrepairStarted?.Invoke();
            });    
        
    }

    public void PuaseRepair()
    {
        
    }

 

    public void TakeDamege()
    {
        currentHeal -= 1;
        OnHealthChanged?.Invoke(currentHeal);
        Debug.Log(currentHeal);

        if (currentHeal <= 0)
        {
            transform.gameObject.SetActive(false);
        }
    }

    public void HealHealth()
    {
        throw new NotImplementedException();
    }
}

public class StructureEventsArgs : EventArgs
{ 
    public int maxHeal ;
    public int currentHeal;
    public int maxRepair;
    public int repairValue;
    
    public float repairDuration;
   
}
