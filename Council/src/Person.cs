namespace Council;

public class Person {
    public readonly string name;
    public Opinion opinion;
    public string thought;
    public Person(string name, Opinion opinion, string thought){
        this.name = name;
        this.opinion = opinion;
        this.thought = thought;
    }

    public void SwayOpposed(){
        switch(this.opinion){
            case Opinion.Opposed:
                this.opinion = Opinion.StronglyOpposed;
                break;
            case Opinion.Neutral:
                this.opinion = Opinion.Opposed;
                break;
            case Opinion.Agree:
                this.opinion = Opinion.Neutral;
                break;
            case Opinion.StronglyAgree:
                this.opinion = Opinion.Agree;
                break;
        }
    }

    public void SwayAgree(){
        switch(this.opinion){
            case Opinion.StronglyOpposed:
                this.opinion = Opinion.Opposed;
                break;
            case Opinion.Opposed:
                this.opinion = Opinion.Neutral;
                break;
            case Opinion.Neutral:
                this.opinion = Opinion.Agree;
                break;
            case Opinion.Agree:
                this.opinion = Opinion.StronglyAgree;
                break;
        }
    }
    public static readonly Person nobody = new Person("", Opinion.Neutral, "");

    public bool isNobody(){
        return this == Person.nobody;
    }
}