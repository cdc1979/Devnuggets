#Devnuggets Toolkit

This toolkit is a collection of helper libraries for performing common tasks in a C#.NET/MVC project.

You can install from nuget using:

Install-Package Devnuggets.Toolkit -Version 1.0.2

Examples

Checkout the Devnuggets.Test project for some sample code.

###SQL/MYSQL Helpers

Simple classes for executing Raw SQL, and querying using DataSets.

###MongoDB Helper

- CopyCollection
- Compact Collection
- Create Indexes

<pre>
using (MongoConnection m = new MongoConnection("mydatabase", new MongoConnectionStringFromWebConfig()))
{
    Console.WriteLine(m.GetStats());
}
</pre>

###CDN Helper
Outputs script tags for loading common libraries e.g. jquery/knockout/bootstrap from CDN.
Can select preferred CDN source (will revert to whatever is available if one CDN doesnt host the file)
####in Your MVC Razor View..
<pre>
@Html.AddCdn(new List<string>(){"jquery","knockout","bootstrap","fontawesome","datatables"}, CdnSourceType.MICROSOFT_AJAX));
</pre>