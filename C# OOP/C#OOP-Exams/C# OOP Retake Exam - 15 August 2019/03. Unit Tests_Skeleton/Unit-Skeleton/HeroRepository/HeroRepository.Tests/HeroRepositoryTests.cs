using System;
using NUnit.Framework;

public class HeroRepositoryTests
{
    //HeroRepository
    [Test]
    public void Should_Initializat_Correct()
    {
        var repo = new HeroRepository();

        Assert.That(repo.Heroes.Count, Is.EqualTo(0));
    }

    [Test]
    public void Should_ArgumentNullException_Null_Create_Her0()
    {
        var repo = new HeroRepository();

        Assert.Throws<ArgumentNullException>(()
           => repo.Create(null),
           "Hero is null");
    }

    [Test]
    public void Should_Add_Correct_InCreate()
    {
        var repo = new HeroRepository();
        var hero = new Hero("Opa", 7);
        repo.Create(hero);

        Assert.That(repo.Heroes.Count, Is.EqualTo(1));
    }

    [Test]
    public void Should_Throw_InvalidOperationException_Hero_Is_In_Collection()
    {
        var repo = new HeroRepository();
        var hero = new Hero("Opa", 7);
        repo.Create(hero);

        Assert.Throws<InvalidOperationException>(()
            => repo.Create(hero),
            "Hero with name Opa already exists");
    }

    [Test]
    public void Should_Remove_Correct()
    {
        var repo = new HeroRepository();
        var hero = new Hero("Opa", 7);
        repo.Create(hero);
        bool actual = repo.Remove("Opa");

        Assert.That(actual, Is.EqualTo(true));
    }

    [Test]
    public void Should_Throw_ArgumentNullException_Hero_Is_Null()
    {
        var repo = new HeroRepository();

        Assert.Throws<ArgumentNullException>(()
           => repo.Remove(null),
          "Name cannot be null");
    }

    //GetHero
    [Test]
    public void Sould_Get_Hero()
    {
        var repo = new HeroRepository();
        var hero1 = new Hero("Opa1", 7);
        var hero2 = new Hero("Opa2", 71);
        var hero3 = new Hero("Opa3", 17);

        repo.Create(hero1);
        repo.Create(hero2);
        repo.Create(hero3);

        var actual = repo.GetHero("Opa2");

        Assert.That(actual,Is.EqualTo(hero2));
    }
    [Test]
    public void Sould_Get_Hero_With_HightestLever()
    {
        var repo = new HeroRepository();
        var hero1 = new Hero("Opa1", 7);
        var hero2 = new Hero("Opa2", 71);
        var hero3 = new Hero("Opa3", 17);

        repo.Create(hero1);
        repo.Create(hero2);
        repo.Create(hero3);

        var actual = repo.GetHeroWithHighestLevel();

        Assert.That(actual, Is.EqualTo(hero2));
    }

}