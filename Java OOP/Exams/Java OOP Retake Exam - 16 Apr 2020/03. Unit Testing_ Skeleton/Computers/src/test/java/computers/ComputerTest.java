package computers;

import org.junit.Assert;
import org.junit.Test;

public class ComputerTest {

    @Test
    public void should_Be_Initialization_Correct() {

        String name = "someName";

        var computer = new Computer(name);

        Assert.assertEquals(computer.getName(), name);
    }

    @Test(expected = IllegalArgumentException.class)
    public void Should_Throw_IllegalArgumentException_With_EmptyName() {
        new Computer("");
    }

    @Test(expected = IllegalArgumentException.class)
    public void Should_Throw_IllegalArgumentException_With_Null() {
        new Computer(null);
    }

    @Test
    public void Should_Add_Part_Correct() {
        var part = new Part("part", 1.1);

        var computer = new Computer("name");

        computer.addPart(part);

        Assert.assertEquals(computer.getParts().size(), 1);
    }

    @Test(expected = IllegalArgumentException.class)
    public void Should_Throw_Add_Part_With_Null_Part() {

        var computer = new Computer("name");

        computer.addPart(null);

    }

    @Test
    public void Should_Get_Part_Correct() {
        var part = new Part("part", 1.1);

        var computer = new Computer("name");

        computer.addPart(part);

        var getPart = computer.getPart("part");

        Assert.assertEquals(part, getPart);
    }

    @Test(expected = UnsupportedOperationException.class)
    public void Should_Throw_Exception() {
        var computer = new Computer("name");
        computer.getParts().add(new Part("pName", 1));
    }

    @Test
    public void Should_GetTotalPrice_Correct_WithParts() {
        var actual = Double.parseDouble("3");

        var part = new Part("part", 1);
        var part1 = new Part("part1", 1);
        var part2 = new Part("part2", 1);

        var computer = new Computer("name");

        computer.addPart(part);
        computer.addPart(part1);
        computer.addPart(part2);

        var totalPrice = computer.getTotalPrice();

        Assert.assertEquals(totalPrice, actual, 0.0);
    }

    @Test
    public void Should_GetTotalPrice_Correct_WithOutParts() {

        var computer = new Computer("name");

        var totalPrice = computer.getTotalPrice();

        Assert.assertEquals(totalPrice, 0, 0.0);
    }

    @Test
    public void Should_Remove_Part_Correct() {
        var part = new Part("part", 1);
        var part1 = new Part("part1", 1);
        var part2 = new Part("part2", 1);

        var computer = new Computer("name");

        computer.addPart(part);
        computer.addPart(part1);
        computer.addPart(part2);

        computer.removePart(part);

        Assert.assertEquals(computer.getParts().size(), 2);
    }
}