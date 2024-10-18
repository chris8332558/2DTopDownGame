using UnityEngine;

public class MoveCommand : ICommand
{
    private Vector2 pos;

    public MoveCommand(Vector2 aPos)
    {
        pos = aPos;
	}

    public void Execute(GameActor anActor)
    {
        anActor.MoveTo(pos);
	}
}
