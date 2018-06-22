using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWeatherApp.Core.dto.Models
{
    public class ListItem
    {
        public string FieldName { get; set; }
        public string Value { get; set; }

        public ListItem(string fieldName, string value) {
            FieldName = fieldName;
            Value = value;
        }
     
    }
}
