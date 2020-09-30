package robotService.models.procedures;

import robotService.models.robots.interfaces.Robot;


public class Work extends BaseProcedure {
    @Override
    public void doService(Robot robot, int procedureTime) {
        super.doService(robot, procedureTime);

        var currentHappinessAndNewValue = robot.getHappiness() + 12;
        robot.setHappiness(currentHappinessAndNewValue);

        var currentEnergyAndNewValue = robot.getEnergy() - 6;
        robot.setEnergy(currentEnergyAndNewValue);
    }
}
