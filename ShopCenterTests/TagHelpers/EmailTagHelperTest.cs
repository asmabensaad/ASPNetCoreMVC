using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Moq;
using ShopCenter.TagHelprs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCenterTests.TagHelpers
{
    public  class EmailTagHelperTest
    {
        public void Generates_Email_Link()
        {
            //Arrange
            EmailTagHelper emailTagHelper = new EmailTagHelper()
            {
                Adress = "test@shopcenter.com",
                Content = "Email"

            };
            ;
            var tagHelperContext = new TagHelperContext(new TagHelperAttributeList(),
                new Dictionary<object, object>(), string.Empty);
            var content =new Mock<TagHelperContent>();
            var tagHelperOutput =new TagHelperOutput("a",new TagHelperAttributeList(),
                (Cache , encoder) => Task.FromResult(content.Object));


            //Action
            emailTagHelper.Process(tagHelperContext, tagHelperOutput);
            //Assert
            Assert.Equal("Email", tagHelperOutput.Content.GetContent());
            Assert.Equal("a", tagHelperOutput.TagName);
            Assert.Equal("mailto:info@shopcenter.com", tagHelperOutput.Attributes[0].Value);
        }
    }
}
