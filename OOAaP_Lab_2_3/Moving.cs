using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

public interface IMoving
{
    Vector Position { get; set; }
    Vector Velocity { get; }
}
public class MoveCommand : ICommand
{
    private readonly IMoving obj;

    public MoveCommand(IMoving obj)
    {
        this.obj = obj;
    }

    public void Execute()
    {
        obj.Position += obj.Velocity;
    }
}
