UmbracoToolkit
==============

Collection of Umbraco specific classes for development.

List of HtmlHelpers: <br>

<code>
//Normal Use </br>
@Html.BreadcrumbFor()
</br>
//Add CSS Class to root container (Div)</br>
@Html.BreadcrumbFor("Breadcrumbs")
</br>
//Include Separator html </br>
@Html.BreadcrumbFor(separatorHtml = "<i class='fa fa-right-chevron'></i>")
</code>
