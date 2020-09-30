package onlineShop.core;

import onlineShop.core.interfaces.Controller;
import onlineShop.models.products.Product;
import onlineShop.models.products.components.*;
import onlineShop.models.products.computers.BaseComputer;
import onlineShop.models.products.computers.Computer;
import onlineShop.models.products.computers.DesktopComputer;
import onlineShop.models.products.computers.Laptop;
import onlineShop.models.products.peripherals.*;

import java.util.*;

import static onlineShop.common.constants.ExceptionMessages.*;
import static onlineShop.common.constants.OutputMessages.*;

public class ControllerImpl implements Controller {

    private List<BaseComputer> computers;
    private List<BaseComponent> components;
    private List<BasePeripheral> peripherals;

    public ControllerImpl() {
        this.computers = new ArrayList<>();
        this.components = new ArrayList<>();
        this.peripherals = new ArrayList<>();
    }

    @Override
    public String addComputer(String computerType, int id, String manufacturer, String model, double price) {

        var isAdded = this.computers.stream()
                .anyMatch(c -> c.getId() == id);

        if (isAdded) throw new IllegalArgumentException(EXISTING_COMPUTER_ID);

        var computer = CreateComputer(computerType, computerType, id, manufacturer, model, price);

        this.computers.add(computer);

        return String.format(ADDED_COMPUTER, id);
    }

    @Override
    public String addPeripheral(int computerId, int id, String peripheralType, String manufacturer, String model, double price, double overallPerformance, String connectionType) {

        var computer = this.CheckComputerExistOrNot(computerId);

        var isExist = this.peripherals
                .stream()
                .anyMatch(c -> c.getId() == id);

        if (isExist) throw new IllegalArgumentException(EXISTING_PERIPHERAL_ID);

        var peripheral = this.CreatePeripheral(peripheralType, id, manufacturer, model, price, overallPerformance, connectionType);
        computer.addPeripheral(peripheral);

        return String.format(ADDED_PERIPHERAL, peripheralType, id, computerId);
    }

    @Override
    public String removePeripheral(String peripheralType, int computerId) {

        var computer = this.CheckComputerExistOrNot(computerId);
        var peripheral = computer.removePeripheral(peripheralType);
        return String.format(REMOVED_PERIPHERAL, peripheralType, peripheral.getId());
    }

    @Override
    public String addComponent(int computerId, int id, String componentType, String manufacturer, String model, double price, double overallPerformance, int generation) {

        var computer = this.CheckComputerExistOrNot(computerId);

        var isExist = this.components
                .stream()
                .anyMatch(c -> c.getId() == id);

        if (isExist) throw new IllegalArgumentException(EXISTING_COMPONENT_ID);

        var component = this.CreateComponent(componentType, id, manufacturer, model, price, overallPerformance, generation);

        computer.addComponent(component);
        this.components.add(component);

        return String.format(ADDED_COMPONENT, componentType, id, computerId);
    }

    @Override
    public String removeComponent(String componentType, int computerId) {

        var computer = this.CheckComputerExistOrNot(computerId);
        var component = computer.removeComponent(componentType);

        return String.format(REMOVED_COMPONENT, componentType, component.getId());
    }

    @Override
    public String buyComputer(int id) {
        var computer = this.CheckComputerExistOrNot(id);

        this.computers.remove(computer);

        return computer.toString();
    }

    @Override
    public String BuyBestComputer(double budget) {

        var computer = Collections.max(this.computers, Comparator.comparing(BaseComputer::getOverallPerformance));

        if (computer == null || computer.getPrice() > budget) throw new IllegalArgumentException(
                String.format(CAN_NOT_BUY_COMPUTER, budget));

        this.computers.remove(computer);

        return computer.toString();
    }

    @Override
    public String getComputerData(int id) {
        var computer = this.CheckComputerExistOrNot(id);
        return computer.toString();
    }

    private BasePeripheral CreatePeripheral(String type, int id, String manufacturer, String model, double price, double overallPerformance, String connectionType) {
        if (!type.equals("Headset") &&
                !type.equals("Keyboard") &&
                !type.equals("Monitor") &&
                !type.equals("Mouse")) throw new IllegalArgumentException(INVALID_PERIPHERAL_TYPE);

        if (type.equals("Headset"))
            return new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
        else if (type.equals("Keyboard"))
            return new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
        else if (type.equals("Monitor"))
            return new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
        else return new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
    }

    private BaseComputer CreateComputer(String computerType, String type, int id, String manufacturer, String model, double price) {
        if (!computerType.equals("Laptop") && !computerType.equals("DesktopComputer"))
            throw new IllegalArgumentException(INVALID_COMPUTER_TYPE);

        if (type.equals("Laptop")) {
            return new Laptop(id, manufacturer, model, price);
        }
        return new DesktopComputer(id, manufacturer, model, price);
    }

    private BaseComponent CreateComponent(String type, int id, String manufacturer, String model, double price, double overallPerformance, int generation) {

        if (!type.equals("Motherboard") &&
                !type.equals("PowerSupply") &&
                !type.equals("CentralProcessingUnit") &&
                !type.equals("RandomAccessMemory") &&
                !type.equals("SolidStateDrive") &&
                !type.equals("VideoCard")) throw new IllegalArgumentException(INVALID_COMPONENT_TYPE);


        if (type.equals("Motherboard"))
            return new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
        else if (type.equals("PowerSupply"))
            return new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
        else if (type.equals("CentralProcessingUnit"))
            return new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
        else if (type.equals("RandomAccessMemory"))
            return new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
        else if (type.equals("SolidStateDrive"))
            return new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
        else return new VideoCard(id, manufacturer, model, price, overallPerformance, generation);

    }

    private BaseComputer CheckComputerExistOrNot(int id) {
        var isExist = this.computers
                .stream()
                .anyMatch(c -> c.getId() == id);

        if (!isExist) throw new IllegalArgumentException(NOT_EXISTING_COMPUTER_ID);

        var computer = this.computers.stream().filter(c -> c.getId() == id).findAny().orElse(null);

        return computer;
    }
}
