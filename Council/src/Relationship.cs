namespace Council;

public class Relationship {
    public readonly Opinion opinion;
    public readonly Person source;
    public readonly Person destination;

    public Relationship(Person source, Person destination, Opinion opinion){
        this.source = source;
        this.destination = destination;
        this.opinion = opinion;
    }

    public bool swaysOppose(){
        return ((destination.opinion == Opinion.StronglyOpposed && opinion >= Opinion.Agree) ||           //Src likes Dest and Dest Strongly Opposes
                (destination.opinion == Opinion.StronglyAgree   && opinion == Opinion.StronglyOpposed)); //Src Hates Dest and Dest Strongly Agrees
    }

    public bool swaysAgree(){
        return ((destination.opinion == Opinion.StronglyAgree   && opinion >= Opinion.Agree) ||           //Src likes Dest and Dest Strongly Agrees
                (destination.opinion == Opinion.StronglyOpposed && opinion == Opinion.StronglyOpposed)); //Src Hates Dest and Dest Strongly Opposes
    }
}