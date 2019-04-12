using System;

class Program
{
    static void Main(string[] args)
    {
        Logger combatLogger = new CombatLogger();
        Logger eventLogger = new EventLogger();

        combatLogger.SetSuccessor(eventLogger);

        var warrior = new Warrior("A", 5, combatLogger);
        var dragon = new Dragon("A", 5, 10);

        ICommand command = new AttackCommand(warrior);

    }
}

