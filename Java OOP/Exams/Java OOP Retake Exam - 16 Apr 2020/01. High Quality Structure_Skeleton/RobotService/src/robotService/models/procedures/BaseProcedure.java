package robotService.models.procedures;

import robotService.models.procedures.interfaces.Procedure;
import robotService.models.robots.interfaces.Robot;

import java.util.ArrayList;
import java.util.Collection;

import static robotService.common.ExceptionMessages.INSUFFICIENT_PROCEDURE_TIME;

public abstract class BaseProcedure implements Procedure {

    protected Collection<Robot> robots;

    protected BaseProcedure() {
        this.robots = new ArrayList<>();
    }

    @Override
    public String history() {

        StringBuilder builder = new StringBuilder();
        builder.append(getClass().getSimpleName());
        builder.append(System.lineSeparator());

        for (Robot robot : robots) {
            builder
                    .append(robot.toString())
                    .append(System.lineSeparator());
        }
        return builder
                .toString()
                .trim();
    }

    @Override
    public void doService(Robot robot, int procedureTime){

        if (robot.getProcedureTime() < procedureTime)
            throw new IllegalArgumentException(INSUFFICIENT_PROCEDURE_TIME);

        var procedure = robot.getProcedureTime() - procedureTime;
        robot.setProcedureTime(procedure);
        this.robots.add(robot);
    }
}
