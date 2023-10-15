using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class BaseCommand : ScriptableObject
{
    public float duration;
    public virtual async Task Execute(GameObject go)
    {
        await Task.Yield();
    }
}
