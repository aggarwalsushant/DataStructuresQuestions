namespace Questions.QuestionFiles.CSharp.Observer
{
    internal class Publisher
    {
        public event GetUpdates RaiseUpdate;
        public Publisher() => RaiseUpdate += SubscriptionManager.PushUpdates;

        public void PublishUpdate(string update)
            => RaiseUpdate($"Publisher: {update}");
    }
}
