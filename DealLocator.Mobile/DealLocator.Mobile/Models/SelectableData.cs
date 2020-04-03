using System;
using System.Collections.Generic;
using System.Text;

namespace DealLocator.Mobile.Models
{
    public class SelectableData<T>
    {
        public T Data { get; set; }
        public bool Selected { get; set; }
    }
}
