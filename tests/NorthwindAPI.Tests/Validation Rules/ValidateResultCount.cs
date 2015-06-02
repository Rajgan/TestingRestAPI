using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

using Microsoft.VisualStudio.TestTools.WebTesting;
using Newtonsoft.Json.Linq;

namespace NorthwindAPI.Tests
{
    [DisplayName("Result count validation rule")]
    [Description("This rule checks to see the REST API returns number of items requested")]
    public class ValidateResultCount : ValidationRule
    {
        public String PageSizeElementPath { get; set; }
        public String ResultElementPath { get; set; }
        public override void Validate(object sender, ValidationEventArgs e)
        {
            var jsonString = e.Response.BodyString;
            var json = JObject.Parse(jsonString);
            if (json == null)
            {
                e.IsValid = false;
                e.Message = "Response received not in JSON format";
            }
            else
            {
                //extract pageSize from response
                var pageSizeJToken = json.SelectToken(PageSizeElementPath).Value<Int32>();
                var resultsJArray = json.SelectToken(ResultElementPath).Value<JArray>();
                if(resultsJArray.Count != pageSizeJToken)
                {
                    e.IsValid = false;
                    e.Message = "Results count does not match the page size";
                }
                else
                    e.IsValid = true;
            }
        }
    }
}
