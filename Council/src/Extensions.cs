namespace Council;

public static class Extensions
{
    public static int Vote(this Opinion opinion){
        var vote = 0;
        switch(opinion){
            case Opinion.StronglyOpposed: 
                vote = -1;
                break;
            case Opinion.Opposed: 
                vote = -1;
                break;
            case Opinion.Neutral: 
                vote = 0;
                break;
            case Opinion.Agree: 
                vote = 1;
                break;
            case Opinion.StronglyAgree: 
                vote = 1;
                break;
        }
        return vote;
    }
    
    public static VoteResult ToVoteResult(this int vote){
        if(vote > 0){
            return VoteResult.Passed;
        } else if (vote < 0) {
            return VoteResult.Fails;
        } else {
            return VoteResult.Tie;
        }
    }
}