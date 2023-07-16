using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.QuestionFiles.CSharp.Observer
{
    public class Runner
    {
        public static void RunViaInternalEvent()
        {
            SubscriptionManager.ClearSubscriptions();

            var sub1 = new FirstSubscriber();
            var sub2 = new SecondSubscriber();

            var mgr = new SubscriptionManager();
            mgr.RegisterSubscription(sub1.GetUpdate);
            mgr.RegisterSubscription(sub2.GetUpdate);

            var pub = new Publisher();
            pub.PublishUpdate("Update pushed from publisher.");
        }

        public static void RunViaInternalMethods()
        {
            SubscriptionManager.ClearSubscriptions();

            var sub1 = new FirstSubscriber();
            var sub2 = new SecondSubscriber();

            var mgr = new SubscriptionManager();
            mgr.RegisterSubscription(sub1.ShowMessage);
            mgr.RegisterSubscription(sub2.ShowMessage);

            var pub = new Publisher();
            pub.PublishUpdate("Update pushed from publisher.");
        }
    }
}
