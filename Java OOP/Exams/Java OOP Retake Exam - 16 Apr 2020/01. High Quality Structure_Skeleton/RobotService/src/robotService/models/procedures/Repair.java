package robotService.models.procedures;

import robotService.models.robots.interfaces.Robot;

public class Repair extends BaseProcedure {

    @Override
    public void doService(Robot robot, int procedureTime) {
        super.doService(robot, procedureTime);

        var happiness = robot.getHappiness() - 5;
        robot.setHappiness(happiness);

        if (robot.isRepaired()) {
            throw new IllegalArgumentException(
                    robot.getClass().getSimpleName() +
                            " is already repaired");
        }

        robot.setRepaired(true);
    }
}
