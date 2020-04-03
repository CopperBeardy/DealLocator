using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;

namespace DealLocator.Mobile.Models
{
    public class CustomPin : Pin
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
