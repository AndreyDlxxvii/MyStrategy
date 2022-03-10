using Zenject;

public class UiModelInstaller : MonoInstaller
{
    //[SerializeField] private AssetsContext _legacyContext;
    public override void InstallBindings()
    {
        //Container.Bind<AssetsContext>().FromInstance(_legacyContext);

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