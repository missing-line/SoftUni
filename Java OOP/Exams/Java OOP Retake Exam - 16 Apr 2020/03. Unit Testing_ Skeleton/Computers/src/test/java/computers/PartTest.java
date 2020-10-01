package computers;


import org.junit.Assert;
import org.junit.Test;

public class PartTest {

    @Test
    public void Should_Be_Instance_CorrectWithName(){
        var part = new Part("name", 1);

        Assert.assertEquals(part.getName(), "name");
    }

    @Test
    public void Should_Be_Instance_CorrectWithPrice(){
        var part = new Part("name", 1);

        Assert.assertEquals(part.getPrice(),1, 0.0);
    }

    @Test
    public void Should_Be_SetName_Correct() {
        var part = new Part("name", 1);

        part.setName("newName");

        Assert.assertEquals(part.getName(), "newName");
    }

    @Test
    public void Should_Be_SetPrice_Correct() {
        var part = new Part("name", 1);

        part.setPrice(12);

        Assert.assertEquals(part.getPrice(), 12, 0.0);
    }
}
