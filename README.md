UmbracoToolkit
==============

Collection of Umbraco specific classes for development.

List of HtmlHelpers: <br>

<code>
//Normal Use
@Html.BreadcrumbFor()

//Add CSS Class to root container (Div)
@Html.BreadcrumbFor("Breadcrumbs")

//Include Separator html 
@Html.BreadcrumbFor(separatorHtml = "<i class='fa fa-right-chevron'></i>")
</code>
