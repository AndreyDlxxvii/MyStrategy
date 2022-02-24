using UnityEngine;
using Zenject;


public class UiModelInstaller : MonoInstaller
{
    [SerializeField] private AssetsContext _legacyContext;
    [SerializeField] private Vector3Value _vector3Value;
    [SerializeField] private AttackableValue _attackableValue;
    [SerializeField] private SelectableValue _selectableValue;

    public override void InstallBindings()
    {
        Container.Bind<IAwaitable<IAttackable>>().FromInstance(_attackableValue);
        Container.Bind<IAwaitable<ISelectable>>().FromInstance(_selectableValue);
        Container.Bind<IAwaitable<Vector3>>().FromInstance(_vector3Value);
        
        Container.Bind<AssetsContext>().FromInstance(_legacyContext);
        Container.Bind<Vector3Value>().FromInstance(_vector3Value);
        Container.Bind<AttackableValue>().FromInstance(_attackableValue);

        Container.Bind<CommandCreatorBase<IProduceUnitCommand>>()
            .To<ProduceUnitCommandCommandCreator>().AsTransient();
        Container.Bind<CommandCreatorBase<IAttack>>()
            .To<AttackUnitCommandCommandCreator>().AsTransient();
        Container.Bind<CommandCreatorBase<IMove>>()
            .To<MoveUnitCommandCommandCreator>().AsTransient();
        Container.Bind<CommandCreatorBase<IPatrol>>()
            .To<PatrolUnitCommandCommandCreator>().AsTransient();
        Container.Bind<CommandCreatorBase<IStop>>()
            .To<StopUnitCommandCommandCreator>().AsTransient();

        Container.Bind<CommandButtonsModel>().AsTransient();
    }
}