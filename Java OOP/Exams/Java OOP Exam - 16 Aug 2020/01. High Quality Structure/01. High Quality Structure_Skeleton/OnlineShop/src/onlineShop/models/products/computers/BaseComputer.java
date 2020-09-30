package onlineShop.models.products.computers;

import onlineShop.models.products.BaseProduct;
import onlineShop.models.products.Product;
import onlineShop.models.products.components.Component;
import onlineShop.models.products.peripherals.Peripheral;

import static onlineShop.common.constants.ExceptionMessages.*;

import java.util.ArrayList;
import java.util.List;
import java.util.Locale;

public abstract class BaseComputer extends BaseProduct implements Computer {

    private List<Component> components;
    private List<Peripheral> peripherals;

    protected BaseComputer(int id, String manufacturer, String model, double price, double overallPerformance) {
        super(id, manufacturer, model, price, overallPerformance);
        this.components = new ArrayList<>();
        this.peripherals = new ArrayList<>();
    }

    @Override
    public List<Component> getComponents() {
        return this.components;
    }

    @Override
    public List<Peripheral> getPeripherals() {
        return this.peripherals;
    }

    @Override
    public void addComponent(Component component) {

        var isNotUnique = this.components
                .stream()
                .anyMatch(c -> c.getClass().getSimpleName().equals(component.getClass().getSimpleName()));

        if (isNotUnique) throw new IllegalArgumentException(
                String.format(EXISTING_COMPONENT, component.getClass().getSimpleName(), this.getClass().getSimpleName(), super.getId()));

        this.components.add(component);
    }

    @Override
    public Component removeComponent(String componentType) {
        var find = this.components
                .stream()
                .filter(x -> x.getClass().getSimpleName().equals(componentType))
                .findAny()
                .orElse(null);

        if (find == null) throw new IllegalArgumentException(
                String.format(NOT_EXISTING_COMPONENT, componentType, this.getClass().getSimpleName(), super.getId()));

        this.components.remove(find);

        return find;
    }

    @Override
    public void addPeripheral(Peripheral peripheral) {
        var findItem = this.peripherals
                .stream()
                .filter(x -> x.getClass().getSimpleName().equals(peripheral.getClass().getSimpleName()))
                .findAny()
                .orElse(null);

        if (findItem != null) throw new IllegalArgumentException(
                String.format(EXISTING_PERIPHERAL, peripheral.getClass().getSimpleName(), this.getClass().getSimpleName(), super.getId()));

        this.peripherals.add(peripheral);
    }

    @Override
    public Peripheral removePeripheral(String peripheralType) {
        var findItem = this.peripherals
                .stream()
                .filter(x -> x.getClass().getSimpleName().equals(peripheralType))
                .findAny()
                .orElse(null);

        if (findItem == null) throw new IllegalArgumentException(
                String.format(NOT_EXISTING_PERIPHERAL, peripheralType, this.getClass().getSimpleName(), super.getId()));

        this.peripherals.remove(findItem);

        return findItem;
    }

    @Override
    public double getPrice() {

        var componentsPrice = this.getComponents()
                .stream()
                .mapToDouble(Product::getPrice)
                .sum();

        var peripheralPrice = this.getPeripherals()
                .stream()
                .mapToDouble(Product::getPrice)
                .sum();

        return componentsPrice + peripheralPrice + super.getPrice();
    }

    @Override
    public double getOverallPerformance() {

        if (this.components.size() > 0) {

            var allOverallPerformanceAverage = this.components
                    .stream()
                    .mapToDouble(Product::getOverallPerformance)
                    .average()
                    .orElse(0.0);

            return allOverallPerformanceAverage + super.getOverallPerformance();
        }

        return super.getOverallPerformance();
    }

    @Override
    public String toString() {
        return super.toString() +
                System.lineSeparator() +
                " Components (" + this.components.size() + "):" +
                this.GetComponentsListingFormat() +
                " Peripherals (" + this.peripherals.size() + ");" +
                " Average Overall Performance (" + String.format(Locale.ROOT, "%.2f", this.GetOverallPerformanceAverage()) + "):" +
                this.GetPeripheralListingFormat();
    }

    private double GetOverallPerformanceAverage() {

        return this.getPeripherals()
                .stream()
                .mapToDouble(Product::getOverallPerformance)
                .average()
                .orElse(0.0);
    }

    private String GetComponentsListingFormat() {

        StringBuilder sb = new StringBuilder();
        sb.append(System.lineSeparator());

        for (Component component : this.getComponents()) {
            sb.append("  ").append(component.toString());
            sb.append(System.lineSeparator());
        }

        return sb.toString();
    }

    private String GetPeripheralListingFormat() {

        StringBuilder sb = new StringBuilder();
        sb.append(System.lineSeparator());

        for (int i = 0; i < this.peripherals.size(); i++) {

            if (this.peripherals.get(i) == this.peripherals.get(this.peripherals.size() - 1)) {
                sb.append("  ").append(this.peripherals.get(i).toString());
            } else {

                sb.append("  ").append(this.peripherals.get(i).toString());
                sb.append(System.lineSeparator());
            }
        }

        return sb.toString();
    }
}
