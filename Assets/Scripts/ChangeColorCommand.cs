using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "ChangeColorCommand", menuName = "Commands/ChangeColorCommand", order = 0)]
public class ChangeColorCommand : BaseCommand
{
    public Color destColor;

    public override async Task Execute(GameObject go)
    {
        var renderer = go.GetComponent<MeshRenderer>();
        var startColor = renderer.material.GetColor("_Color");
        
        for (var t=0f; t<duration; t+=Time.deltaTime) 
        {
            var normalizedTime = t / duration;
            var color = Color.Lerp(startColor, destColor, normalizedTime);
            renderer.material.SetColor("_Color", color);
            await Task.Yield();
        }
    }
}
