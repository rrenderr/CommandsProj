using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "RotateCommand", menuName = "Commands/RotateCommand", order = 0)]
public class RotateCommand : BaseCommand
{
    public Vector3 destRotation;

    public override async Task Execute(GameObject go)
    {
        var startRotation = go.transform.rotation;
        
        for (var t=0f; t<duration; t+=Time.deltaTime) 
        {
            var normalizedTime = t / duration;
            var rotation = Quaternion.Lerp(startRotation, Quaternion.Euler(destRotation), normalizedTime);
            go.transform.rotation = rotation;
            await Task.Yield();
        }
    }
}
