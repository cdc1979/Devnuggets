#Devnuggets Toolkit

This toolkit is a collection of helper libraries for performing common tasks in a C#.NET/MVC project.

You can install from nuget using:

Install-Package Devnuggets.Toolkit -Version 1.1.0

Examples

Checkout the Devnuggets.Samples project for some sample code.

###Twitter Bootstrap Helpers

-Render List of POCO Objects to Table, inject buttons

<pre>
@Html.TableBuilder(Model, new TableOptions() { TableStyle = SetTableStyle.STRIPED, TableHover = SetTableHover.HOVER })
</pre>

-Render List of POCO Objects to Thumbnails

<pre>
    List<Thumbnail> t = new List<Thumbnail>();
    t.Add(new Thumbnail() { Paragraph = "Test paragraph", Heading = "test"  });
    t.Add(new Thumbnail() { Paragraph = "Test paragraph 2" });
    t.Add(new Thumbnail() { Paragraph = "Test paragraph 3" });
    t.Add(new Thumbnail() { Paragraph = "Test paragraph 4" });
    t.Add(new Thumbnail() { Paragraph = "Test paragraph 5" });
    t.Add(new Thumbnail() { Paragraph = "Test paragraph 6" });    
</pre>

<pre>
@Html.ThumbnailBuilder(t, 4)
</pre>

###Anti Robot

Add _@Html.AntiRobot()_ to your form. 

Then add _[AntiRobot(5)]_ to your controller action, where the parameter is the 
number of seconds delay to allow for the form to be submitted. (One of the ways we
can block robots is to add a minimum delay for a form to be filled in, clearly a human will
take longer than a few secons to fill in a form)

The Anti Robot helper also adds a hidden "Honey Pot" field to your form, which
is intended to remain hidden, and empty, and the form submit will fail if its not.
i.e. a robot filled in that field automatically.

###SQL/MYSQL Helpers

Simple classes for executing Raw SQL, and querying using DataSets.

MySQL Example:

<pre>
using (MySqlHelper m = new MySqlHelper(ConfigurationManager.AppSettings["mysql.connectionstring"]))
{
    string sql = "SELECT * FROM myTable";
    DataTable dt = m.GetDataset(sql).Tables[0];
    foreach (DataRow r in dt.Rows)
    {
	}
}
</pre>

###MongoDB Helper

The mongodb helper is designed to simplify common tasks into one or two lines of code.  This is handy
when needing to ensure lots of indexes are created, or to perform many automated admin tasks.

- CopyCollection(s)
- Compact Collection(s)
- Create Indexes(s)
- Access Collections

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
@Html.AddCdn("jquery","knockout","bootstrap","fontawesome","datatables"}, CdnSourceType.MICROSOFT_AJAX)
</pre>

###Utility Classes

Just a set of useful static classes for repetetive work.

- String Functions
- Data Functions
- Date Functions
- String Extension Methods