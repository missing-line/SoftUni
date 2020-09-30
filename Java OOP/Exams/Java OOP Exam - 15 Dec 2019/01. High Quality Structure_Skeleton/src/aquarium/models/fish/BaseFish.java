package aquarium.models.fish;

import static aquarium.common.ExceptionMessages.*;

public abstract class BaseFish implements Fish {

    private String name;
    private String species;
    private double price;
    private int size;

    protected BaseFish(String name, String species, double price) {
        this.setName(name);
        this.setSpecies(species);
        this.setPrice(price);
    }

    protected void setSize(int size) {
        this.size = size;
    }

    @Override
    public void setName(String name) {
        if (name == null && name.trim().length() < 1) throw new NullPointerException(FISH_NAME_NULL_OR_EMPTY);
        this.name = name;
    }

    private void setSpecies(String species) {
        if (species == null && species.trim().length() < 1) throw new NullPointerException(SPECIES_NAME_NULL_OR_EMPTY);
        this.species = species;
    }

    @Override
    public int getSize() {
        return this.size;
    }

    @Override
    public String getName() {
        return this.name;
    }

    @Override
    public double getPrice() {
        return this.price;
    }

    private void setPrice(double price) {
        if (price <= 0) throw new IllegalArgumentException(FISH_PRICE_BELOW_OR_EQUAL_ZERO);
        this.price = price;
    }
}
