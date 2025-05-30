using Stateless;

public class Bug
{
    public enum State { Open, Assigned, Defered, Closed, Rejected, InProcess, Blocked }
    private enum Trigger { Assign, Defer, Close, Reject, InProc, Block }
    private StateMachine<State, Trigger> sm;

    public Bug(State state)
    {
        sm = new StateMachine<State, Trigger>(state);
        sm.Configure(State.Open)
              .Permit(Trigger.Assign, State.Assigned);
        sm.Configure(State.Assigned)
              .Permit(Trigger.Close, State.Closed)
              .Permit(Trigger.Defer, State.Defered)
              .Permit(Trigger.Reject, State.Rejected)
              .Permit(Trigger.InProc, State.InProcess)
              .Permit(Trigger.Block, State.Blocked)
              .Ignore(Trigger.Assign);
        sm.Configure(State.Closed)
              .Permit(Trigger.Assign, State.Assigned);
        sm.Configure(State.Defered)
              .Permit(Trigger.Assign, State.Assigned)
              .Permit(Trigger.Reject, State.Rejected);
        sm.Configure(State.InProcess)
              .Permit(Trigger.Defer, State.Defered)
              .Permit(Trigger.Block, State.Blocked)
              .Permit(Trigger.Close, State.Closed);
        sm.Configure(State.Blocked)
              .Permit(Trigger.Defer, State.Defered);
        sm.Configure(State.Rejected)
              .Permit(Trigger.Assign, State.Assigned);
    }
    public void Close()
    {
        sm.Fire(Trigger.Close);
        Console.WriteLine("Close");
    }
    public void Assign()
    {
        sm.Fire(Trigger.Assign);
        Console.WriteLine("Assign");
    }
    public void Defer()
    {
        sm.Fire(Trigger.Defer);
        Console.WriteLine("Defer");
    }
    public void Reject()
    {
        sm.Fire(Trigger.Reject);
        Console.WriteLine("Reject");
    }
    public void InProc()
    {
        sm.Fire(Trigger.InProc);
        Console.WriteLine("InProc");
    }
    public void Block()
    {
        sm.Fire(Trigger.Block);
        Console.WriteLine("Block");
    }
    public State getState()
    {
        return sm.State;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var bug = new Bug(Bug.State.Open);
        bug.Assign();
        bug.Close();
        bug.Assign();
        bug.Reject();
        bug.Assign();
        bug.InProc();
        bug.Block();
        bug.Defer();
        bug.Assign();
        Console.WriteLine(bug.getState());
    }
}