using Sitecore.Abstractions;
using Sitecore.Configuration.KnownSettings;
using Sitecore.Diagnostics;
using Sitecore.Pipelines.RenderField;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Sitecore.Support.Pipelines.RenderField
{
    public class GetTextFieldValue: Sitecore.Pipelines.RenderField.GetTextFieldValue
    {
        private static readonly BindingFlags _bflags = BindingFlags.NonPublic | BindingFlags.Static;
        private static readonly PropertyInfo SettingsInstance_Prop = typeof(Sitecore.Configuration.Settings).GetProperty("SettingsInstance", _bflags);
        private static readonly BaseSettings SettingsInstance = SettingsInstance_Prop.GetValue(null) as Sitecore.Abstractions.BaseSettings;

        protected override void EncodeFieldValue([NotNull] RenderFieldArgs args)
        {
            Assert.ArgumentNotNull(args, "args");
            if (SettingsInstance.Rendering().HtmlEncodedFieldTypes.Contains(args.FieldTypeKey))
            {
                args.Result.FirstPart = HttpUtility.HtmlEncode(args.Result.FirstPart);
            }
        }
    }
}