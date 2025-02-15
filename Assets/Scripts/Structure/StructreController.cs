using System;
using UnityEngine;

public class StructreController : MonoBehaviour
{
    public event Action<StructreController> OnStructureBuilt;
    private void OnTriggerEnter(Collider other)
    {
        OnStructureBuilt?.Invoke(this);
            
    }
}
