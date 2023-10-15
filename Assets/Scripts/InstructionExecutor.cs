using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


[System.Serializable]
class Instruction
{
    public List<BaseCommand> commands;
}

public class InstructionExecutor : MonoBehaviour
{
    [SerializeField]
    private List<Instruction> instructions;
    
    void Start()
    {
        foreach (var instruction in instructions)
        {
            // don't wait instruction continue
            ExecuteInstruction(instruction);
            Debug.Log("Start Instruction");
        }
    }
    
    private async Task ExecuteInstruction(Instruction instruction)
    {
        foreach (var command in instruction.commands)
        {
            await command.Execute(gameObject);
        }
    }
}
