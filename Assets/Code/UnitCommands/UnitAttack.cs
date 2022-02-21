    using UnityEngine;

    public class UnitAttack : CommandExecutorBase<IAttack>, IAttack
    {
        public override void ExecuteSpecificCommand(IAttack command)
        {
            Debug.Log("Attack");
        }
    }