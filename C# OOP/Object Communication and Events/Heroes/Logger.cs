
public abstract class Logger : IHandler
{
    private IHandler succssesor;
    public abstract void Handle(LogType type, string msg);


    public void SetSuccessor(IHandler handler)
    {
        this.succssesor = handler;
    }

    public void PassToSuccessor(LogType type, string msg)
    {
        if (this.succssesor != null)
        {
            this.succssesor.Handle(type, msg);
        }
    }
}

