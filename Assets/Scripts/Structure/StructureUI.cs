using System;
using UnityEngine;
using UnityEngine.UI;

public class StructureUI : MonoBehaviour
{
   public Image HealthUi;
   public Image RepairUi;
   public StructreController structreController;
   private void OnEnable()
   {
      structreController.OnHealthChanged += OnOnHealthChanged;
      structreController.OnRepairChanged += OnOnRepairChanged;

   }

   private void OnDisable()
   {
      structreController.OnHealthChanged -= OnOnHealthChanged;
      structreController.OnRepairChanged -= OnOnRepairChanged;
   }

   private void OnOnRepairChanged(float obj)
   {
      RepairUi.fillAmount = obj / structreController.maxRepair;
   }

   private void OnOnHealthChanged(float obj)
   {
      HealthUi.fillAmount = obj / structreController.maxHeal;
   }

   private void Update()
   {
      
   }
}
