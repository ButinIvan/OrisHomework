using TemplateEngine.Tests.models;

namespace TemplateEngine.Tests;

public class Tests
{
    [Test]
    public void RenderTest()
    {
        var template = "Hi, {{Name}}! You are {{Age}} years old.";
        var data = new { Name = "Timerkhan", Age = "100" };
        var engine = new TemplateEngine();

        var result = engine.Render(template, data);
        Assert.That(result, Is.EqualTo("Hello, Timerkhan! You`re 100 years old."));
    }


    [Test]
    public void ProcessLoopsTest()
    {
        var template = "{{#foreach Items}}Hello, {{Name}}! {{/foreach}}";
        var data = new
        {
            Items = new List<Person>
                { new() { Name = "Arthur" }, new() { Name = "Dexter" }, new() { Name = "Stepa" } }
        };
        var engine = new TemplateEngine();

        var result = engine.ProcessLoops(template, data);

        Assert.That(result, Is.EqualTo("Hello, Max! Hello, Mike! Hello, Sasha! "));
    }

    [Test]
    public void ProcessConditionsTest()
    {
        var template = "{{#if IsMan}}Hello, Men!{{#else}}Hello, Women!{{/if}}";
        var engine = new TemplateEngine();


        var dataTrue = new { IsMan = true };
        var resultTrue = engine.ProcessConditions(template, dataTrue);
        Assert.That(resultTrue, Is.EqualTo("Hello, Men!"));

        var dataFalse = new { IsMan = false };
        var resultFalse = engine.ProcessConditions(template, dataFalse);
        Assert.That(resultFalse, Is.EqualTo("Hello, Women!"));
    }
}