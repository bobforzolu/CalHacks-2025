using System;
using UnityEngine;

public class SKillCOntroller : MonoBehaviour
{
   public PlayerController player;
   public GameObject wife;
   public GameObject hasband;

   private void Awake()
   {
      player.OnActivePlayerChanged += PlayerOnOnActivePlayerChanged;
   }

   private void OnDestroy()
   {
      player.OnActivePlayerChanged -= PlayerOnOnActivePlayerChanged;

   }

   private void PlayerOnOnActivePlayerChanged(ActivePlayer obj)
   {
      if (obj == ActivePlayer.husband)
      {
         wife.SetActive(false);
         hasband.SetActive(true);
      }
      else
      {
         wife.SetActive(true);
         hasband.SetActive(false);
      }
   }
}
