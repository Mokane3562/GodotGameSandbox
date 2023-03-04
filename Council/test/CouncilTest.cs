namespace Council;

using NUnit.Framework;

public abstract class CouncilTest
{
    private Council _council = null!;

    [SetUp]
    public void Setup()
    {
        _council = new Council(
            new string[]
            {
                "Bob",
                "Mary",
                "Sue",
                "Jeff",
                "Kyle"
            },
            new Opinion[]
            {
                Opinion.StronglyOpposed,
                Opinion.Neutral,
                Opinion.StronglyAgree,
                Opinion.Agree,
                Opinion.Neutral
            },
            new string[]
            {
                "We cannnot allow this to happen in our town!",
                "I don't really know; Bob and Sue both make good points.",
                "If we don't do this what does that say about who we are?!",
                "It's probably a good idea, but I don't know enough to argue with Bob.",
                "Bob and Sue are too wound up about this in my opinion; and Bob's being kinda of an asshole. I wonder what Jeff thinks of all this?"
            }
        );
        _council.InitRelationshipGraph(
            new string[]
            {
                "Bob",
                "Mary",
                "Sue",
                "Jeff",
                "Kyle"
            },
            new string[]
            {
                "Mary", "Sue", "Jeff", "Kyle",
                "Bob", "Sue", "Jeff", "Kyle",
                "Bob", "Mary", "Jeff", "Kyle",
                "Bob", "Mary", "Sue", "Kyle",
                "Bob", "Mary", "Sue", "Jeff"
            },
            new Opinion[]
            {
                Opinion.Agree, Opinion.StronglyOpposed, Opinion.Neutral, Opinion.Neutral,
                Opinion.Agree, Opinion.Agree, Opinion.Agree, Opinion.Neutral,
                Opinion.StronglyOpposed, Opinion.Neutral, Opinion.Neutral, Opinion.Neutral,
                Opinion.Agree, Opinion.Neutral, Opinion.Neutral, Opinion.Neutral,
                Opinion.Opposed, Opinion.Neutral, Opinion.Neutral, Opinion.Agree
            }
        );
    }

    [Test]
    public void Test1()
    {
        // Options: Agree, Neutral, or Oppose
        const Opinion playerOpinion = Opinion.Agree;
        // Options: Bob, Mary, Sue, Jeff, Kyle, and Nobody
        const string nameOfSwayedPerson = "Sue";

        bool playerSwayingAgree = true;
        if (!nameOfSwayedPerson.Equals("Nobody"))
        {
            // Options: true for Agree or false for Oppose
            playerSwayingAgree = true;
        }

        VoteResult result = _council
            .SwayPerson(nameOfSwayedPerson, playerSwayingAgree)
            .Converse()
            .TallyVote(playerOpinion);
        Assert.That(result, Is.EqualTo(VoteResult.Passed));
    }
}