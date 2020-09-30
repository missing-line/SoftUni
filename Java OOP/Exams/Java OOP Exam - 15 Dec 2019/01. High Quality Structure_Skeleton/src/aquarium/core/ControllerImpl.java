package aquarium.core;

import aquarium.models.aquariums.BaseAquarium;
import aquarium.models.aquariums.FreshwaterAquarium;
import aquarium.models.aquariums.SaltwaterAquarium;
import aquarium.models.decorations.BaseDecoration;
import aquarium.models.decorations.Decoration;
import aquarium.models.decorations.Ornament;
import aquarium.models.decorations.Plant;
import aquarium.models.fish.BaseFish;
import aquarium.models.fish.Fish;
import aquarium.models.fish.FreshwaterFish;
import aquarium.models.fish.SaltwaterFish;
import aquarium.repositories.DecorationRepository;

import java.util.*;

import static aquarium.common.ConstantMessages.*;
import static aquarium.common.ExceptionMessages.*;

public class ControllerImpl implements Controller {

    private DecorationRepository decorationRepository;
    private Collection<BaseAquarium> aquariums;

    public ControllerImpl() {
        this.decorationRepository = new DecorationRepository();
        this.aquariums = new ArrayList<>();
    }

    @Override
    public String addAquarium(String aquariumType, String aquariumName) {

        BaseAquarium aquarium = null;

        if (aquariumType.equals("FreshwaterAquarium")) aquarium = new FreshwaterAquarium(aquariumName);
        else if(aquariumType.equals("SaltwaterAquarium")) aquarium = new SaltwaterAquarium(aquariumName);
        else throw new IllegalArgumentException(INVALID_AQUARIUM_TYPE);

        this.aquariums.add(aquarium);
        return String.format(SUCCESSFULLY_ADDED_AQUARIUM_TYPE, aquariumType);
    }

    @Override
    public String addDecoration(String type) {

        BaseDecoration decoration = null;

        if (type.equals("Ornament")) decoration = new Ornament();
        else if(type.equals("Plant")) decoration = new Plant();
        else throw new IllegalArgumentException(INVALID_DECORATION_TYPE);

        this.decorationRepository.add(decoration);
        return String.format(SUCCESSFULLY_ADDED_DECORATION_TYPE, type);
    }

    @Override
    public String insertDecoration(String aquariumName, String decorationType) {
        var decoration = this.decorationRepository.findByType(decorationType);

        if (decoration == null) throw new IllegalArgumentException(
                String.format(NO_DECORATION_FOUND, decorationType));

        this.decorationRepository.remove(decoration);

        var aquarium = GetAquarium(aquariumName);

        aquarium.addDecoration(decoration);

        return String.format(SUCCESSFULLY_ADDED_DECORATION_IN_AQUARIUM, decorationType, aquariumName);
    }

    @Override
    public String addFish(String aquariumName, String fishType, String fishName, String fishSpecies, double price) {

        BaseFish fish = null;

        if (fishType.equals("FreshwaterFish")) fish = new FreshwaterFish(fishName, fishSpecies, price);
        else if(fishType.equals("SaltwaterFish")) fish = new SaltwaterFish(fishName, fishSpecies, price);
        else throw new IllegalArgumentException(INVALID_FISH_TYPE);;

        var aquarium = GetAquarium(aquariumName);

        var aquariumType = aquarium.getClass().getSimpleName();

        if (fishType.equals("FreshwaterFish") &&
                aquariumType.equals("FreshwaterAquarium")) {
            aquarium.addFish(fish);
            return String.format(SUCCESSFULLY_ADDED_FISH_IN_AQUARIUM, fishType, aquariumName);
        } else if (fishType.equals("SaltwaterFish") &&
                aquariumType.equals("SaltwaterAquarium")) {
            aquarium.addFish(fish);
            return String.format(SUCCESSFULLY_ADDED_FISH_IN_AQUARIUM, fishType, aquariumName);
        } else return WATER_NOT_SUITABLE;
    }

    @Override
    public String feedFish(String aquariumName) {

        var aquarium = GetAquarium(aquariumName);

        aquarium.feed();

        return String.format(FISH_FED, aquarium.getFish().size());
    }

    @Override
    public String calculateValue(String aquariumName) {

        var aquarium = GetAquarium(aquariumName);

        var decorationPrice = aquarium.getDecorations().stream().mapToDouble(Decoration::getPrice).sum();
        var fishPrice = aquarium.getFish().stream().mapToDouble(Fish::getPrice).sum();

        var priceFormat = String.format(Locale.ROOT, "%.2f", (decorationPrice + fishPrice));

        return String.format("The value of Aquarium %s is %s.", aquariumName, priceFormat);
    }

    @Override
    public String report() {
        StringBuilder sb = new StringBuilder();
        this.aquariums.forEach(a -> sb.append(a.getInfo()));
        return sb.toString();
    }

    private BaseAquarium GetAquarium(String name) {
        return this.aquariums
                .stream()
                .filter(Objects::nonNull)
                .filter(a -> a.getName().equals(name))
                .findAny()
                .orElse(null);
    }
}
