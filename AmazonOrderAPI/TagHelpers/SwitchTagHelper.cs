using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace AmazonOrderAPI.TagHelpers
{
    [HtmlTargetElement("toggle-button")]
    public class SwitchTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var divSlider = new TagBuilder("div");
            try
            {
                var childContent = await output.GetChildContentAsync();
                divSlider.AddCssClass("slider round");

                output.TagName = "label";
                output.Attributes.Add("class", "switch");
                output.Content.AppendHtml(childContent);
                output.Content.AppendHtml(divSlider);
                output.TagMode = TagMode.StartTagAndEndTag;
            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                divSlider = null;
            }
           
        }
    }
}