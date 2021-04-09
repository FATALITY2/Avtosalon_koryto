using AutocentreKorytoClientBusinessLogics.BusinessLogics;
using AutocentreKorytoClientBusinessLogics.Interfaces;
using AutocentreKorytoClientBusinessLogics.ViewModels;
using AutocentreKorytoClientDatabaseImplement.Implements;
using System;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace AutocentreKorytoClientView
{
    static class Program
    {
        public static UserViewModel User { get; set; }

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormRegistration>());
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<ICostStorage, CostsStorage>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<ICarStorage, CarStorage>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IPaymentStorage, PaymentStorage>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IPurchaseStorage, PurchaseStorage>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IUserStorage, UserStorage>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<CostLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<CarLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<PaymentLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<PurchaseLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<UserLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ReportLogic>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
