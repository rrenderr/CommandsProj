using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "MoveCommand", menuName = "Commands/MoveCommand", order = 0)]
public class MoveCommand : BaseCommand
{
    public Vector3 destPos;

    public override async Task Execute(GameObject go)
    {
        var startPos = go.transform.localPosition;
        
        for (var t=0f; t<duration; t+=Time.deltaTime) 
        {
            var normalizedTime = t / duration;
            var pos = Vector3.Lerp(startPos, destPos, normalizedTime);
            go.transform.localPosition = pos;
            await Task.Yield();
        }
    }
}
