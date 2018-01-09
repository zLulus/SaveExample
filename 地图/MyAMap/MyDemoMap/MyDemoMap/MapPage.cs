using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyMapNS {

    public class MapPage : ContentPage {
        public IEnumerable<UserTaskEntInfo> Pins { set; get; }

    }
}
