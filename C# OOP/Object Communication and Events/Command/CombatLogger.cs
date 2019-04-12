using System;
public class CombatLogger : Logger
{
    public override void Handle(LogType type, string msg)
    {
        switch (type)
        {
            case LogType.ATTACK:
                Console.WriteLine(type.ToString() + ": " + msg);
                break;
            case LogType.MAGIC:
                Console.WriteLine(type.ToString() + ": " + msg);
                break;
            default:
                break;
        }

        this.PassToSuccessor(type, msg);
    }
}

