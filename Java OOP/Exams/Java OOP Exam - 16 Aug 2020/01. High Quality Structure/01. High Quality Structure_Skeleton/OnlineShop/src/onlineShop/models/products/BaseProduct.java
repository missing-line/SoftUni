package onlineShop.models.products;

import java.util.Locale;

import static onlineShop.common.constants.ExceptionMessages.*;

public abstract class BaseProduct implements Product {

    private double price;
    private int id;
    private String manufacturer;
    private String model;
    private double overallPerformance;

    protected BaseProduct(int id, String manufacturer, String model, double price, double overallPerformance) {
        setId(id);
        setManufacturer(manufacturer);
        setModel(model);
        setPrice(price);
        setOverallPerformance(overallPerformance);
    }

    public int getId() {
        return this.id;
    }

    public void setId(int id) {
        if (id <= 0) throw new IllegalArgumentException(INVALID_PRODUCT_ID);
        this.id = id;
    }

    public String getManufacturer() {
        return this.manufacturer;
    }

    public void setManufacturer(String manufacturer) {
        if (manufacturer == null) throw new IllegalArgumentException(INVALID_MANUFACTURER);
        this.manufacturer = manufacturer;
    }

    public String getModel() {
        return this.model;
    }

    public void setModel(String model) {
        if (model == null) throw new IllegalArgumentException(INVALID_MODEL);
        this.model = model;
    }

    public double getPrice() {
        return this.price;
    }

    public void setPrice(double price) {
        if (price <= 0) throw new IllegalArgumentException(INVALID_PRICE);
        this.price = price;
    }

    public double getOverallPerformance() {
        return this.overallPerformance;
    }

    public void setOverallPerformance(double overallPerformance) {
        if (overallPerformance <= 0) throw new IllegalArgumentException(INVALID_OVERALL_PERFORMANCE);
        this.overallPerformance = overallPerformance;
    }

    @Override
    public String toString() {
        return "Overall Performance: " +
                String.format(Locale.ROOT, "%.2f", this.getOverallPerformance()) +
                ". Price: " +
                String.format(Locale.ROOT,"%.2f", this.getPrice()) +
                " - " +
                this.getClass().getSimpleName() +
                ": " +
                this.getManufacturer() +
                " " +
                this.getModel() +
                " (Id: " +
                this.getId() +
                ")";
    }
}
