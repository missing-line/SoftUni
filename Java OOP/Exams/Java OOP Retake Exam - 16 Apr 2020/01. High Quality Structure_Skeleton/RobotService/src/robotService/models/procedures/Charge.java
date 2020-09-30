package robotService.models.procedures;

import robotService.models.robots.interfaces.Robot;


public class Charge extends BaseProcedure {

    @Override
    public void doService(Robot robot, int procedureTime) {
        super.doService(robot, procedureTime);

        var currentHappinessAndNewValue = robot.getHappiness() + 12;
        var currentEnergyAndNewValue = robot.getEnergy() + 10;

        robot.setHappiness(currentHappinessAndNewValue);
        robot.setEnergy(currentEnergyAndNewValue);
    }
}
