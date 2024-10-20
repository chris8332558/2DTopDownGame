public class AttackCommand : ICommand
{
    public void Execute(GameActor aActor)
    {
        aActor.Attack();
	}
}
