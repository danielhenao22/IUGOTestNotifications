using AzureNotificationHub;
using AzureNotificationHub.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Test2
{
    class Program
    {
        public static void MethoAsync()
        {
            Console.WriteLine("Start");
            //string pns = "fYxJbIr90E4:APA91bFUO5Q006mrHBmsRh4EBgQOCkNBQYbOv0DqzMX46QL-la_5_mfbixoBpk660ACL6GOMQ19ooibnS1qN9o76drr_ra8R_Tvbp02ftOjLsqYdPrBvqZmX4uT5D9cjlyF4iuxRmsVv";
            AzureNotificationHubClient hub = new AzureNotificationHubClient("", "iugo-notification-push");
            //hub.CreateRegistrationID().Wait();
            //hub.CreateOrUpdateRegistration(new GcmRegistrationDescription(
            //    "1",
            //    "2018-10-20T23:59:59.999Z",
            //    "",
            //    "device2",
            //    pns)).Wait();
            //hub.CreateOrUpdateRegistration(new GcmTemplateRegistrationDescription(
            //   "1",
            //   "2018-10-20T23:59:59.999Z",
            //   "5640214195339354765-6091654439096819311-1",
            //   "Tdevice3",
            //   pns,
            //   "{ \"data\":{ \"message\":\"{$(Nombre)+ ' Hola2 ' + $(Apellido)}\"}}",
            //   "TemplateName")).Wait();
            Task<List<RegistrationDescription>> rd = hub.ReadAllRegistrations();
            rd.Wait();
            foreach (RegistrationDescription r in rd.Result)
            {
                Console.WriteLine("ID: "+r.RegistrationId);
                hub.DeleteRegistration(r.RegistrationId).Wait();
                Console.WriteLine("Deleted ID: " + r.RegistrationId);
                Console.WriteLine("-------------------------------------------");
            }

            Console.WriteLine("Press any key");
            Console.ReadLine();
            //foreach (RegistrationDescription register in rd.Result)
            //{
            //    if (register.GetType() == typeof(GcmTemplateRegistrationDescription))
            //    {
            //        GcmTemplateRegistrationDescription gcmTemplate = (GcmTemplateRegistrationDescription)register;
            //        string name = gcmTemplate.TemplateName;

            //    }
            //}
            //hub.DeleteRegistration("4597787621203353778-3373062488283882018-2").Wait();


            //hub.CreateRegistration(new AppleTemplateRegistrationDescription(
            //    "5648214195339354765-6091654439096819311-5",
            //    "Tdevice3",
            //    "740f4707 bebcf74f 9b7c25d4 8e335894 5f6aa01d a5ddb387 462c7eaf 61bb78ad",
            //    "{ \"data\":{ \"message\":\"{$(Nombre)+ ' Hola2 ' + $(Apellido)}\"}}")).Wait();

            //TemplateNotification tn = new TemplateNotification("{\"Nombre\" : \"Daniel\", \"Apellido\":\"Henao\" }");
            //Task<string> var = hub.SendTemplateNotification(tn, tag: "Tdevice3");

            //var.Wait();

            //string a = var.Result;

            //Task<List<RegistrationDescription>> rd2 = hub.ReadAllRegistrations();
            //rd2.Wait();
        }

        static void Main(string[] args)
        {
            MethoAsync();
        }
    }
}
