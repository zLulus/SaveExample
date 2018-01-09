using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MyMapNS {
    public class App : Application {

        public static NavigationPage NavigationTestPage;

        public App() {
            var pins = new List<UserTaskEntInfo>() { };         
            pins.Add(new UserTaskEntInfo() { Name = "上海市浦东新区滨江大道", Longitude = 31.2379863826, Latitude = 121.4959153979 });
            pins.Add(new UserTaskEntInfo() { Name = "上海市浦东新区即墨路", Longitude = 31.2435242682, Latitude = 121.5104350816 });
            NavigationTestPage = new NavigationPage(new MapPage() { Pins = pins });
            MainPage = NavigationTestPage;
        }

        protected override void OnStart() {
            // Handle when your app starts
        }

        protected override void OnSleep() {
            // Handle when your app sleeps
        }

        protected override void OnResume() {
            // Handle when your app resumes
        }
    }
}
