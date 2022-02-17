    using UnityEngine;

    public class ProduceUnit : CommandExecutorBase<IProduceUnitCommand>
    {
        [SerializeField] private Transform _parentTransform;
        public override void ExecuteSpecificCommand(IProduceUnitCommand command)
        {
            Instantiate(command.UnitPrefab , new Vector3(Random.Range(0, 10), 0, Random.Range(0, 10)),
            Quaternion.identity, _parentTransform);
        }
    }