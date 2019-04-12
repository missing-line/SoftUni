using System;
public interface IHandler
{
    void Handle(LogType type, String msg);
    void SetSuccessor(IHandler handler);

}

