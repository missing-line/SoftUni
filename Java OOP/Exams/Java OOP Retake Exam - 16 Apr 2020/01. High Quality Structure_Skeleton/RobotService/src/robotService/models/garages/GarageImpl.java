package robotService.models.garages;

import robotService.models.garages.interfaces.Garage;
import robotService.models.robots.interfaces.Robot;

import java.util.LinkedHashMap;
import java.util.Map;

import static robotService.common.ExceptionMessages.NOT_ENOUGH_CAPACITY;
import static robotService.common.ExceptionMessages.EXISTING_ROBOT;
import static robotService.common.ExceptionMessages.NON_EXISTING_ROBOT;

public class GarageImpl implements Garage {

    private int CAPACITY = 10;
    private Map<String, Robot> robots;

    public GarageImpl() {
        this.robots = new LinkedHashMap<>();
    }

    @Override
    public Map<String, Robot> getRobots() {
        return this.robots;
    }

    @Override
    public void manufacture(Robot robot) {

        if (this.robots.size() == CAPACITY) {
            throw new IllegalArgumentException(NOT_ENOUGH_CAPACITY);
        }
        if (this.robots.containsKey(robot.getName())) {
            throw new IllegalArgumentException(String.format(EXISTING_ROBOT, robot.getName()));
        }

        this.robots.put(robot.getName(), robot);
    }

    @Override
    public void sell(String robotName, String ownerName) {

        if (!this.robots.containsKey(robotName)) {
            throw new IllegalArgumentException(String.format(NON_EXISTING_ROBOT, robotName));
        }

        var robot = this.robots.get(robotName);

        robot.setOwner(ownerName);

        robot.setBought(true);

        this.robots.remove(robotName);
    }
}
