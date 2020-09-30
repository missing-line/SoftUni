package robotService.core;

import robotService.core.interfaces.Controller;
import robotService.models.garages.GarageImpl;
import robotService.models.garages.interfaces.Garage;
import robotService.models.procedures.Charge;
import robotService.models.procedures.Repair;
import robotService.models.procedures.Work;
import robotService.models.procedures.interfaces.Procedure;
import robotService.models.robots.BaseRobot;
import robotService.models.robots.Cleaner;
import robotService.models.robots.Housekeeper;
import robotService.models.robots.interfaces.Robot;

import static robotService.common.ExceptionMessages.*;
import static robotService.common.OutputMessages.*;

public class ControllerImpl implements Controller {

    private Garage garage;
    private Procedure charge;
    private Procedure repair;
    private Procedure work;

    public ControllerImpl() {
        this.garage = new GarageImpl();
        this.charge = new Charge();
        this.repair = new Repair();
        this.work = new Work();
    }

    @Override
    public String manufacture(String robotType, String name, int energy, int happiness, int procedureTime) {

        Robot robot = null;

        if (robotType.equals("Cleaner"))
            robot = new Cleaner(name, energy, happiness, procedureTime);
        else if (robotType.equals("Housekeeper"))
            robot = new Housekeeper(name, energy, happiness, procedureTime);
        else
            throw new IllegalArgumentException(String.format(INVALID_ROBOT_TYPE, robotType));

        this.garage.manufacture(robot);
        return String.format(ROBOT_MANUFACTURED, name);
    }

    @Override
    public String repair(String robotName, int procedureTime) {
        var robot = IsRobotExisting(robotName);

        this.repair.doService(robot, procedureTime);

        return String.format(REPAIR_PROCEDURE, robotName);
    }

    @Override
    public String work(String robotName, int procedureTime) {
        var robot = IsRobotExisting(robotName);

        this.work.doService(robot, procedureTime);

        return String.format(WORK_PROCEDURE, robotName, procedureTime);
    }

    @Override
    public String charge(String robotName, int procedureTime) {
        var robot = IsRobotExisting(robotName);

        this.charge.doService(robot, procedureTime);

        return String.format(CHARGE_PROCEDURE, robotName);
    }

    @Override
    public String sell(String robotName, String ownerName) {
        var robot = IsRobotExisting(robotName);

        this.garage.sell(robotName, ownerName);

        return String.format(SELL_ROBOT, ownerName, robotName);
    }

    @Override
    public String history(String procedureType) {
        if (procedureType.equals("Charge"))
            return this.charge.history();
        else if (procedureType.equals("Work"))
            return this.work.history();
        else
            return this.repair.history();
    }

    private Robot IsRobotExisting(String robotName) {

        if (!this.garage.getRobots().containsKey(robotName))
            throw new IllegalArgumentException(String.format(NON_EXISTING_ROBOT, robotName));

        var robot = this.garage.getRobots().get(robotName);

        return robot;
    }
}
