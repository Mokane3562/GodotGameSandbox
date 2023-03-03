namespace Council;

using System;
using System.Linq;

public class Council {

        private readonly Person[] _councilMembers;
        private readonly Relationship[] _relationships;

        public Council(string[] names, Opinion[] opinions, string[] thoughts){
            _councilMembers = names.Zip(opinions, thoughts)
                                  .Select(tuple => new Person(tuple.First, tuple.Second, tuple.Third))
                                  .ToArray();
            _relationships = new Relationship[names.Length * (names.Length - 1)];
        }

        public bool ValidName(string name){
            var person = GetPersonByName(_councilMembers, name);
            if (person.isNobody() && !name.Equals("Nobody")){
                return false;
            }
            return true;
        }

        public bool ValidOpinion(string opinion) {
            return opinion.Equals("Agree") || opinion.Equals("Oppose");
        }

        public bool ValidVote(string opinion) {
            return opinion.Equals("Agree") || opinion.Equals("Oppose") || opinion.Equals("Neutral");
        }

        public Opinion VoteFromString(string opinion){
            return (opinion.Equals("Agree")   ?  Opinion.Agree    : 
                   (opinion.Equals("Oppose")  ?  Opinion.Opposed  :
                  /*opinion.Equals("Neutral") ?*/Opinion.Neutral));
        }

        public Council InitRelationshipGraph(string[] sources, string[] destinations, Opinion[] feelings){
            /*  |   0    |   1    |   2    | ... | <- n-1 entries per row
             *  |  n-1   |   n    |  n+1   | ... |
             *  | 2(n-1) |  2(n)  | 2(n+1) | ... |
             *  ...
             *  |n-1(n-1)| n-1(n) |n-1(n+1)| ... | <- n rows
             */
            int n = sources.Length;
            for (int i = 0; i<n; i++) {
                for (int j = i*(n-1); j<((i+1)*(n-1)); j++){
                    _relationships[j] = new Relationship(
                        this.GetPersonByName(_councilMembers, sources[i]), 
                        this.GetPersonByName(_councilMembers, destinations[j]), 
                        feelings[j]
                    );
                }
            }
            return this;
        }

        Func<Person[], string, Person> GetPersonByName = (councilMembers, name) => {
            foreach (Person person in councilMembers) {
                if (person.name.Equals(name)) return person;
            }
            return Person.nobody;
        };


        public VoteResult TallyVote(Opinion playerOpinion){
            return _councilMembers.Select(member => member.opinion.Vote())
                                 .Append(playerOpinion.Vote())
                                 .Aggregate((tally, next) => tally + next)
                                 .ToVoteResult();
        }
        
        public Council Converse(){
            //get all people who are being swayed in opposition
            var swayedOpposed = _relationships.Where(relationship => relationship.swaysOppose())
                                             .Select(relationship => relationship.source)
                                             .Distinct()
                                             .ToArray();
            //and all people being swayed to agree
            var swayedAgree = _relationships.Where(relationship => relationship.swaysAgree())
                                           .Select(relationship => relationship.source)
                                           .Distinct()
                                           .ToArray();
            //and find all those who are being swayed in both directions
            var unswayed = swayedOpposed.Intersect(swayedAgree);
            //remove unswayed people from the previous lists
            swayedOpposed = swayedOpposed.Where(person => !unswayed.Contains(person))
                                         .ToArray();
            swayedAgree = swayedAgree.Where(person => !unswayed.Contains(person))
                                     .ToArray();
            //apply the sway to their opinion
            foreach(Person p in swayedOpposed) { p.SwayOpposed(); }
            foreach(Person p in swayedAgree) { p.SwayAgree(); }
            return this;
        }

        public Council SwayPerson(String name, bool agree){
            if(agree) {
                this.GetPersonByName(_councilMembers, name).SwayAgree();
            } else {
                this.GetPersonByName(_councilMembers, name).SwayOpposed();
            }
            return this;
        }

    }