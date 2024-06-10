using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Intellexi.TrailRacing.CommandService;

public class KebabRoutingConvention
    : IControllerModelConvention
{
    private readonly Regex _regex;

    public KebabRoutingConvention()
    {
        _regex = new Regex(
            "(?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z])",
            RegexOptions.Compiled,
            TimeSpan.FromSeconds(2));
    }

    public void Apply(ControllerModel controller)
    {
        foreach (var selector in controller.Selectors)
        {
            selector.AttributeRouteModel = ReplaceControllerTemplate(selector, controller.ControllerName);
        }

        foreach (var selector in controller.Actions.SelectMany(action => action.Selectors))
        {
            selector.AttributeRouteModel = ReplaceControllerTemplate(selector, controller.ControllerName);
        }
    }

    private AttributeRouteModel ReplaceControllerTemplate(
        SelectorModel selector,
        string name)
    {
        if (selector.AttributeRouteModel == null) return null;

        return new AttributeRouteModel
        {
            Template = selector.AttributeRouteModel!.Template?.Replace("[controller]", PascalToKebabCase(name)),
        };
    }

    private string PascalToKebabCase(string value)
    {
        if (!string.IsNullOrEmpty(value))
        {
            return _regex.Replace(value, "-$1").Trim().ToLower();
        }

        return value;
    }
}