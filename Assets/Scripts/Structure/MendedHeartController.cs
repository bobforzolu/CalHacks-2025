using System;
using System.Collections.Generic;
using UnityEngine;

public class MendedHeartController : MonoBehaviour
{
   public List<GameObject> hearts = new List<GameObject>();
   public int Phase;
   
   public List<StructreController> structre = new List<StructreController>();
   public Transform structures;

   private void Awake()
   {
      iniatilizePhase();
      foreach (StructreController structreController in structures.GetComponentsInChildren<StructreController>())
      {
         structreController.OnStructureBuilt += OnStuctureBuilted;
      }
   }

   public void OnStuctureBuilted( StructreController structreController )
   {
      if (!structre.Contains(structreController))
      {
         structre.Add(structreController);
         AdvnaceHeartPhase();
         
      }
   }

  private void iniatilizePhase()
  {
     
     Phase = 0;
     foreach (GameObject heart in hearts)
     {
        heart.SetActive(false);
     }
   }

   public void AdvnaceHeartPhase()
   {
      Phase++;
      hearts[Phase].SetActive(true);
   }
}
