using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Tests : PageTest
{
    [Test]
    public async Task HomepageHasmelansonsInTitleAndHiImSamuelMelansonHeading()
    {
        await Page.GotoAsync("https://melansons.vercel.app/");

        // Expect a title "to contain" a substring.
        await Expect(Page).ToHaveTitleAsync("melanson[s]");

        // create a locator
        var headingElement = Page.GetByRole(AriaRole.Heading, new PageGetByRoleOptions() { Name = "Hi, I'm samuel Melanson" });

        // Expect an attribute "to be strictly equal" to the value.
        await Expect(headingElement).ToHaveTextAsync(new Regex("Hi, I'm Samuel Melanson"));
    }
}