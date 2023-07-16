using System;

namespace Questions.QuestionFiles.CSharp.Observer
{
    public delegate void GetUpdates(string message);

    internal class FirstSubscriber
    {
        public GetUpdates GetUpdate { get; }
        public FirstSubscriber() => GetUpdate += ShowMessage;

        public void ShowMessage(string message)
            => Console.WriteLine($"Update for first: {message}");
    }

    internal class SecondSubscriber
    {
        public GetUpdates GetUpdate { get; }
        public SecondSubscriber() => GetUpdate += ShowMessage;

        public void ShowMessage(string message)
            => Console.WriteLine($"Update for second: {message}");
    }
}
