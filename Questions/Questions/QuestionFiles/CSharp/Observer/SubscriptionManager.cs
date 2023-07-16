namespace Questions.QuestionFiles.CSharp.Observer
{
    internal class SubscriptionManager
    {
        public static GetUpdates RegisteredSubscribers { get; private set; }

        public void RegisterSubscription(GetUpdates updateSubscription)
            => RegisteredSubscribers += updateSubscription;

        public void UnregisterSubscription(GetUpdates updateSubscription)
            => RegisteredSubscribers -= updateSubscription;

        public static void ClearSubscriptions() => RegisteredSubscribers = null;

        public static void PushUpdates(string message)
        {
            if (RegisteredSubscribers == null) return;

            RegisteredSubscribers(message);
        }
    }
}
