using Sitecore.Configuration;
using Sitecore.Diagnostics;
using Sitecore.Pipelines.RenderField;
using System;
using System.Web;

namespace Sitecore.Support.Pipelines.RenderField
{
    public class GetTextFieldValue
    {
        public void Process([NotNull] RenderFieldArgs args)
        {
            Assert.ArgumentNotNull(args, "args");

            this.EncodeFieldValue(args);

            var typeKey = args.FieldTypeKey;
            if (typeKey.Equals("text", StringComparison.InvariantCulture) || typeKey.Equals("single-line text", StringComparison.InvariantCulture))
            {
                args.WebEditParameters.Add("prevent-line-break", "true");
            }
        }

        protected virtual void EncodeFieldValue([NotNull] RenderFieldArgs args)
        {
            Assert.ArgumentNotNull(args, "args");
            if (Settings.Rendering.HtmlEncodedFieldTypes.Contains(args.FieldTypeKey))
            {
                args.Result.FirstPart = HttpUtility.HtmlEncode(args.Result.FirstPart);
            }
        }
    }
}