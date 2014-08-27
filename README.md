UmbracoToolkit
==============

Collection of Umbraco specific classes for development.

List of HtmlHelpers: <br>

```
//Normal Use
@Html.BreadcrumbFor()

//Add CSS Class to root container (Div)
@Html.BreadcrumbFor("Breadcrumbs")

//Include Separator html </br>
@Html.BreadcrumbFor(separatorHtml = "<i class='fa fa-right-chevron'></i>")
```
