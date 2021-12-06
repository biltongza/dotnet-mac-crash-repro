using static Darwin.CopyFile;

using var state = new State();
Console.WriteLine("created state");
state.SetStatusCallback((Progress what, Stage stage, string source, string dest, State state) =>
{
    Console.WriteLine("got callback!!");
    return NextStep.Continue;
});
Console.WriteLine("set status callback");

var status = await Task.Run(() => Darwin.CopyFile.Copy("test.txt", "test2.txt", Flags.Clone, state));
Console.WriteLine("Copied!");
Console.WriteLine(status);