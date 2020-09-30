package aquarium.models.aquariums;

import aquarium.models.decorations.Decoration;
import aquarium.models.fish.Fish;

import java.util.ArrayList;
import java.util.Collection;

import static aquarium.common.ExceptionMessages.AQUARIUM_NAME_NULL_OR_EMPTY;

public abstract class BaseAquarium implements Aquarium {

    private String name;
    private int capacity;
    private Collection<Decoration> decorations;
    private Collection<Fish> fish;

    protected BaseAquarium(String name, int capacity) {
        this.setName(name);
        this.capacity = capacity;
        this.decorations = new ArrayList<>();
        this.fish = new ArrayList<>();
    }

    @Override
    public int calculateComfort() {
        return this.decorations
                .stream()
                .mapToInt(Decoration::getComfort)
                .sum();
    }

    @Override
    public String getName() {
        return this.name;
    }

    @Override
    public void addFish(Fish fish) {
        if (this.fish.size() >= capacity) throw new IllegalStateException("Not enough capacity.");

        this.fish.add(fish);
    }

    @Override
    public void removeFish(Fish fish) {
        this.fish.remove(fish);
    }

    @Override
    public void addDecoration(Decoration decoration) {
        this.decorations.add(decoration);
    }

    @Override
    public void feed() {
        this.fish.forEach(Fish::eat);
    }

    @Override
    public String getInfo() {

        return this.getName() + " (" + this.getClass().getSimpleName() + "):" + System.lineSeparator() +
                "Fish: " + this.GetAllFish() + System.lineSeparator() +
                "Decorations: " + this.decorations.size() + System.lineSeparator() +
                "Comfort: " + this.calculateComfort();
    }

    @Override
    public Collection<Fish> getFish() {
        return this.fish;
    }

    @Override
    public Collection<Decoration> getDecorations() {
        return this.decorations;
    }

    private void setName(String name) {
        if (name == null && name.trim().isEmpty()) throw new NullPointerException(AQUARIUM_NAME_NULL_OR_EMPTY);
        this.name = name;
    }

    private String GetAllFish() {
        if (this.fish.size() == 0) return "none";

        Collection<String> listNames = new ArrayList<>();

        for (Fish fish : this.fish) {
            listNames.add(fish.getName());
        }

        return String.join(" ", listNames);
    }
}
