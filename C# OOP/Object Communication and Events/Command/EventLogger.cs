using System;
using System.Collections.Generic;
using System.Text;

public class EventLogger : Logger
{
    public override void Handle(LogType type, string msg)
    {
        switch (type)
        {
            case LogType.EVENT:
                Console.WriteLine(type.ToString() + ": " + msg);
                break;          
            default:
                break;
        }

        this.PassToSuccessor(type, msg);
    }
}

