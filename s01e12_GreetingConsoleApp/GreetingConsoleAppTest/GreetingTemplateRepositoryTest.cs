using GreetingConsoleApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GreetingConsoleAppTest
{
    [TestClass]
    public class GreetingTemplateRepositoryTest
    {
        [TestMethod]
        public void test_GetGreetingTemplate()
        {
            var myTemplate = new GreetingTemplateRepository();

            var myIDList = myTemplate.GetGreetingTemplateIDs();
            
            Assert.IsNotNull(myTemplate.GetGreetingTemplate(myIDList[0]));
            Assert.IsNotNull(myTemplate);
            Assert.IsNotNull(myTemplate.GreetingTemplates);
            
        }

        [TestMethod]

        public void test_SaveGreetingTemplate()
        {
            var myTemplate = new GreetingTemplateRepository();
            var greet = new Greeting();
            var originalCount = myTemplate.GreetingTemplates.Count;

            myTemplate.SaveGreetingTemplate(myTemplate.uniqID(), greet);

            var newCount = myTemplate.GreetingTemplates.Count;

            //did the count go up by 1?
            Assert.AreEqual(originalCount+1, newCount);

            try
            {
                myTemplate.SaveGreetingTemplate(myTemplate.GetGreetingTemplateIDs()[0], greet);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "key already exists");
                Console.WriteLine("executed");
            }

            var lastCount = myTemplate.GreetingTemplates.Count;
            Assert.AreEqual(lastCount, newCount);
        }

        [TestMethod]

        public void test_GetSetByLengthMethodsShouldReturnSame()
        {
            var myTemplate = new GreetingTemplateRepository();

            var ListByLinq = myTemplate.GetGreetingTemplatesByLengthWithLinq(17);
            var ListByLambda = myTemplate.GetGreetingTemplatesByLengthWithLambda(17);
            var ListByForeach = myTemplate.GetGreetingTemplatesByLengthWithForeach(17);

            Assert.AreEqual(ListByForeach.Count(), ListByLinq.Count());
            Assert.AreEqual(ListByLambda.Count(), ListByLinq.Count());
            Assert.AreEqual(ListByForeach.Count(), ListByLambda.Count());
        }


        [TestMethod]

        public void test_GetGreetingTemplatesByLengthWithLinq()
        {
            var myTemplate = new GreetingTemplateRepository();

            List<int> myListOfLengths = new List<int>();

            //Get a list of lengths of the Greeting messages in myTemplate
            foreach (Greeting g in myTemplate.GreetingTemplates.Values)
            {
                myListOfLengths.Add(g.Message.Length);
            }

            //sort them from long to short
            myListOfLengths.Reverse(); //This I find very strange, I can't seem to rename the sorted list

            //count how many messages have the same length as the longest messgae
            int counter = 0;
            while (myListOfLengths[counter] == myListOfLengths[counter + 1])
            {
                counter++;
            }

            //retrieve the IEnumerable containing the greetings with the longest message
            int numListedByLinq = myTemplate.GetGreetingTemplatesByLengthWithLinq(myListOfLengths[0]).Count();

            //check whether that is equal to how we counted
            Assert.AreEqual(numListedByLinq, counter + 1);


        }

        [TestMethod]

        public void test_GetGreetingTemplatesBySearchStringWithLinq()
        {
            var myTemplate = new GreetingTemplateRepository();

            System.Guid guid = System.Guid.NewGuid();

            var myGreeting = new Greeting();
            myGreeting.Message = guid.ToString();

            myTemplate.SaveGreetingTemplate(myTemplate.uniqID(), myGreeting);

            var myResult = myTemplate.GetGreetingTemplatesBySearchStringWithLinq(guid.ToString()).ToList();

            // I struggle with how to access elements of an IEnumberable, should we always convert to list?

            Assert.AreEqual(myResult[0].Message, guid.ToString());
            


        }


    }
}