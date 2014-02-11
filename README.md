#Devnuggets Toolkit

This toolkit is a collection of helper libraries for performing common tasks in a C#.NET/MVC project.  You can install from nuget using 

Install-Package Devnuggets.Toolkit -Version 1.0.0

Examples

###CDN Helper
Outputs script tags for loading common libraries e.g. jquery/bootstrap from CDN.
Can select preferred CDN source (will revert to whatever is available if one CDN doesnt host the file)
<pre>
HtmlHelper h = null;
Console.WriteLine(h.AddCdn(new List<string>(){"jquery","knockout","bootstrap","fontawesome","datatables"}, CdnSourceType.MICROSOFT_AJAX));
</pre>