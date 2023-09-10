# Complete guide to ASP.NET Core MVC (.NET 8) [E-Commerce App]

- ... - 52 - MVC project
- 53 - ... - Razor Pages

GitHub Code: https://github.com/bhrugen/Bulky_MVC


<!-- TOC -->

- [Complete guide to ASP.NET Core MVC .NET 8 [E-Commerce App]](#complete-guide-to-aspnet-core-mvc-net-8-e-commerce-app)
    - [Section 1: Welcome & Getting Started](#section-1-welcome--getting-started)
        - [Course Overview [11]](#course-overview-11)
        - [Create MVC Project [12]](#create-mvc-project-12)
        - [Project File [13]](#project-file-13)
        - [Launch Settings [14]](#launch-settings-14)
        - [wwwroot and appsettings [15]](#wwwroot-and-appsettings-15)
            - [wwwroot - static content css, js, 3rd party libs, nuget packages, images, files, pdfs, powerpoints, etc.](#wwwroot---static-content-css-js-3rd-party-libs-nuget-packages-images-files-pdfs-powerpoints-etc)
            - [appsettings.json - Connection Strings, Secrets, Keys, DB connections, Azure DB, storage etc.](#appsettingsjson---connection-strings-secrets-keys-db-connections-azure-db-storage-etc)
            - [Swith to prod](#swith-to-prod)
        - [Program File [16]](#program-file-16)
        - [MVC Architecture [17]](#mvc-architecture-17)
        - [Routing Overview [18]](#routing-overview-18)
        - [Routing in Action [19]](#routing-in-action-19)
        - [Default Views [20]](#default-views-20)
        - [Go Easy on Yourself! [21]](#go-easy-on-yourself-21)
    - [Section 2: Category CRUD Operations](#section-2-category-crud-operations)
        - [Create Category Model [22]](#create-category-model-22)
        - [Data Annotations [23]](#data-annotations-23)
        - [Connection String [24]](#connection-string-24)
        - [Nuget Packages for Entity Framework Core [25]](#nuget-packages-for-entity-framework-core-25)
        - [Setup ApplicationDbContext [26]](#setup-applicationdbcontext-26)
        - [Create Database - Update-Database [27]](#create-database---update-database-27)
        - [Create Category Table [28]](#create-category-table-28)
            - [Add DbSet to AppDbContext:](#add-dbset-to-appdbcontext)
            - [Add-Migration](#add-migration)
            - [Update-Database](#update-database)
        - [Add Category Controller [29]](#add-category-controller-29)
        - [Add Category Link in Header [30]](#add-category-link-in-header-30)
        - [Seed Category Table [31]](#seed-category-table-31)
            - [Add OnModelCreating in  AppDbContext](#add-onmodelcreating-in--appdbcontext)
            - [Add-Migration SeedCategoryTable](#add-migration-seedcategorytable)
            - [Update-Database](#update-database)
        - [Get all Categories [32]](#get-all-categories-32)
        - [Hot Reload [33]](#hot-reload-33)
        - [Display all Categories [34]](#display-all-categories-34)
        - [Bootswatch Theme and Bootstrap Icons [35]](#bootswatch-theme-and-bootstrap-icons-35)
        - [Design Category List Page [36]](#design-category-list-page-36)
        - [Create Category UI [37]](#create-category-ui-37)
        - [Input Tag Helpers [38]](#input-tag-helpers-38)
        - [Create Category [39]](#create-category-39)
        - [Built-In Server Side Validations [40]](#built-in-server-side-validations-40)
        - [Custom Validations [41]](#custom-validations-41)
        - [Asp Validation Summary [42]](#asp-validation-summary-42)
        - [Client Side Validation [43]](#client-side-validation-43)
        - [Edit and Delete Buttons [44]](#edit-and-delete-buttons-44)
        - [Get Category Details to Edit [45]](#get-category-details-to-edit-45)
        - [Update Category [46]](#update-category-46)
        - [Update Category in Action [47]](#update-category-in-action-47)
        - [Get and Post Action for Delete Category [48]](#get-and-post-action-for-delete-category-48)
        - [Delete Category in Action [49]](#delete-category-in-action-49)
        - [TempData [50]](#tempdata-50)
        - [Partial Views [51]](#partial-views-51)
        - [Toastr Notification [52]](#toastr-notification-52)
        - [Share Toastr Notification across the project [52]](#share-toastr-notification-across-the-project-52)
    - [Section 3: Razor Project](#section-3-razor-project)
        - [Create Razor Project [53]](#create-razor-project-53)
        - [What's Different in Razor Project? [54]](#whats-different-in-razor-project-54)
        - [Setup EF Core [55]](#setup-ef-core-55)
        - [Create first Razor Page [56]](#create-first-razor-page-56)
        - [Display all Categories [57]](#display-all-categories-57)
            - [MVC View vs. Razor Page [57]](#mvc-view-vs-razor-page-57)
        - [Create Category UI [58]](#create-category-ui-58)
        - [Create Category Post Handler [59]](#create-category-post-handler-59)
            - [[BindProperty], [BindProperties]](#bindproperty-bindproperties)
            - [RedirectToPage](#redirecttopage)
        - [Edit and Delete Category [60]](#edit-and-delete-category-60)
        - [Toastr Notifications and Partial Views [61]](#toastr-notifications-and-partial-views-61)
    - [Section 4: N-Tier Architecture](#section-4-n-tier-architecture)
        - [Create More Projects [62]](#create-more-projects-62)
        - [Modify Styling Refresh [63]](#modify-styling-refresh-63)
        - [Modify Styling [64]](#modify-styling-64)
        - [Modify UI of Category Pages [65]](#modify-ui-of-category-pages-65)
        - [N-Tier Architecture [66]](#n-tier-architecture-66)
        - [How to Reset Database [67]](#how-to-reset-database-67)
        - [Bonus - Dependency Injection Service Lifetimes [68]](#bonus---dependency-injection-service-lifetimes-68)
    - [Section 5: Repository Pattern](#section-5-repository-pattern)
        - [IRepository Interface [69]](#irepository-interface-69)
        - [Implement Repository Interface [70]](#implement-repository-interface-70)
        - [ICategoryRepository [71]](#icategoryrepository-71)
        - [Implement Category Repository [72]](#implement-category-repository-72)
        - [Replace DbContext with Category Repository [73]](#replace-dbcontext-with-category-repository-73)
            - [Do not use DbContext directly in Controller, use repository instead.](#do-not-use-dbcontext-directly-in-controller-use-repository-instead)
            - [Do not forget to register our repo](#do-not-forget-to-register-our-repo)
        - [How Easy is it to move to a Different Database? [74]](#how-easy-is-it-to-move-to-a-different-database-74)
        - [Renaming Project and Solving Issues [75]](#renaming-project-and-solving-issues-75)
        - [UnitOfWork Implementation [76]](#unitofwork-implementation-76)
        - [UnitOfWork in Action [77]](#unitofwork-in-action-77)
            - [Pros and Cons](#pros-and-cons)
        - [Areas in .NET [78]](#areas-in-net-78)
            - [Customer vs Admin Page](#customer-vs-admin-page)
        - [Dropdown in NavBar [79]](#dropdown-in-navbar-79)
    - [Section 6: Product CRUD](#section-6-product-crud)
        - [Create Product Model [80]](#create-product-model-80)
        - [Seed Product and Assignment 1 [81]](#seed-product-and-assignment-1-81)
        - [Assignment 1 Solution - Product Repository and UnitOfWork [82]](#assignment-1-solution---product-repository-and-unitofwork-82)
            - [Push Products to the DB](#push-products-to-the-db)
            - [Implement Product Repo](#implement-product-repo)
            - [Config Product Repo in UoW](#config-product-repo-in-uow)
        - [Assignment 2 - Product CRUD Operations [83]](#assignment-2---product-crud-operations-83)
            - [Create Product Controller and Action methods Create/Edit/Delete/Index](#create-product-controller-and-action-methods-createeditdeleteindex)
            - [Create Views for Create/Edit/Delete/Index](#create-views-for-createeditdeleteindex)
            - [Add Client-Side and Server-Side Validation](#add-client-side-and-server-side-validation)
        - [Assignment 2 Solution - Product CRUD Operations [84]](#assignment-2-solution---product-crud-operations-84)
        - [Add Foreign Key in EF Core [85]](#add-foreign-key-in-ef-core-85)
        - [Add Image Url Column [86]](#add-image-url-column-86)
        - [Projections in EF Core [87]](#projections-in-ef-core-87)
        - [Viewbag in Action [88]](#viewbag-in-action-88)
        - [ViewData in Action [89]](#viewdata-in-action-89)
        - [Remember TempData [89]](#remember-tempdata-89)
        - [View Models in Action [90]](#view-models-in-action-90)
        - [File Upload Input [91]](#file-upload-input-91)
        - [Combine, Create, and Edit Pages [92]](#combine-create-and-edit-pages-92)
        - [Rich Text Editor [93]](#rich-text-editor-93)
        - [Create Product [94]](#create-product-94)
        - [Display Image on Update [95]](#display-image-on-update-95)
        - [Handle Image on Update [96]](#handle-image-on-update-96)
        - [Custom Product Update [97]](#custom-product-update-97)
        - [Loading Navigation Properties [98]](#loading-navigation-properties-98)
        - [Use of DataTables API [99]](#use-of-datatables-api-99)
        - [Load DataTables [100]](#load-datatables-100)
        - [Datatable column count [101]](#datatable-column-count-101)
        - [Edit Product Link in DataTable [102]](#edit-product-link-in-datatable-102)
        - [Delete Product [103]](#delete-product-103)
        - [SweetAlerts [104]](#sweetalerts-104)
    - [Section 7: Home and Details Page](#section-7-home-and-details-page)
        - [Home Page [105]](#home-page-105)
        - [Details Action Method [106]](#details-action-method-106)
        - [Details UI [107]](#details-ui-107)
    - [Section 8: Identity in .NET Core](#section-8-identity-in-net-core)
        - [Scaffold Identity [108]](#scaffold-identity-108)
        - [Scaffold Identity Issue NET8 [109]](#scaffold-identity-issue-net8-109)
        - [Understand what Got Added [110]](#understand-what-got-added-110)
        - [Add Identity Tables [111]](#add-identity-tables-111)
            - [What is missing?](#what-is-missing)
            - [Add-Migration addIdentityTables](#add-migration-addidentitytables)
        - [Extend Identity User [112]](#extend-identity-user-112)
            - [What is Discriminator field?](#what-is-discriminator-field)
        - [Register a User [113]](#register-a-user-113)
        - [Register an Application User [114]](#register-an-application-user-114)
        - [Create Roles in Database [115]](#create-roles-in-database-115)
        - [Assign Roles on Registration [116]](#assign-roles-on-registration-116)
        - [Authorization in Project [117]](#authorization-in-project-117)
        - [Update Login and Register UI [118]](#update-login-and-register-ui-118)
        - [Register Other Fields [119]](#register-other-fields-119)
        - [UI Bug [120]](#ui-bug-120)
    - [Section 9: Company CRUD](#section-9-company-crud)
        - [Why do we have a Company Role? [121]](#why-do-we-have-a-company-role-121)
        - [Assignment 3 [122]](#assignment-3-122)
        - [Assignment 3 Solution - Company CRUD Operations [123]](#assignment-3-solution---company-crud-operations-123)
        - [Display Company Dropdown [124]](#display-company-dropdown-124)
        - [Toggle Company Dropdown [125]](#toggle-company-dropdown-125)
        - [Register Company User [126]](#register-company-user-126)
    - [Section 10: Shopping Cart](#section-10-shopping-cart)
        - [Add Shopping Cart Model [127]](#add-shopping-cart-model-127)
        - [Add Shopping Cart to Repository and UoW [128]](#add-shopping-cart-to-repository-and-uow-128)
        - [Add ApplicationUser Repository [129]](#add-applicationuser-repository-129)
        - [What will be Model for Details Page? [130]](#what-will-be-model-for-details-page-130)
        - [Add to Cart [131]](#add-to-cart-131)
        - [Fix Issue with Add to Cart [132]](#fix-issue-with-add-to-cart-132)
        - [A Weird Bug [133]](#a-weird-bug-133)
            - [dbSet.AsNoTracking](#dbsetasnotracking)
        - [Shopping Cart UI [134]](#shopping-cart-ui-134)
        - [Get Shopping Cart [135]](#get-shopping-cart-135)
        - [Get Order Total in Shopping Cart [136]](#get-order-total-in-shopping-cart-136)
        - [Dynamic Shopping Cart [137]](#dynamic-shopping-cart-137)
        - [Update Quantity in Shopping Cart [138]](#update-quantity-in-shopping-cart-138)
        - [Order Summary UI [139]](#order-summary-ui-139)
    - [Section 11: Order Confirmation](#section-11-order-confirmation)
        - [Create Order Header and Details Model [140]](#create-order-header-and-details-model-140)
        - [Fix DateOnly EFCore7 Issue](#fix-dateonly-efcore7-issue)
        - [Add Order Header and Detail Repository [141]](#add-order-header-and-detail-repository-141)
        - [Make ShoppingCartVM more Dynamic [142]](#make-shoppingcartvm-more-dynamic-142)
        - [Summary GET Action Method [143]](#summary-get-action-method-143)
        - [Load Summary UI with Data [144]](#load-summary-ui-with-data-144)
        - [Order Status [145]](#order-status-145)
        - [Summary POST Action [146]](#summary-post-action-146)
        - [Place Order for Company Accounts [147]](#place-order-for-company-accounts-147)
        - [Register for Stripe Account [148]](#register-for-stripe-account-148)
        - [Configure Stripe in Project [149]](#configure-stripe-in-project-149)
        - [Add Helper Methods in Order Header Repository [150]](#add-helper-methods-in-order-header-repository-150)
        - [Stripe in Action [151]](#stripe-in-action-151)
        - [Confirm Stripe Payment [152]](#confirm-stripe-payment-152)
            - [Stripe Payment Status](#stripe-payment-status)
            - [Order Confirmation](#order-confirmation)
        - [Order Placed Successfully with Stripe [153]](#order-placed-successfully-with-stripe-153)
    - [Section 12: Order Management](#section-12-order-management)
        - [OrderVM and Order Controller [154]](#ordervm-and-order-controller-154)
        - [Order List UI [155]](#order-list-ui-155)
        - [Add Status Filter [156]](#add-status-filter-156)
        - [Make Status Selected Active [157]](#make-status-selected-active-157)
        - [Demo - Filters in Order List [158]](#demo---filters-in-order-list-158)
        - [Order Details Get Action [159]](#order-details-get-action-159)
        - [Loading Order Details Header [160]](#loading-order-details-header-160)
        - [Display Order Details [161]](#display-order-details-161)
        - [Update Order Details [162]](#update-order-details-162)
        - [Only Admin and Employee Can See all Orders [163]](#only-admin-and-employee-can-see-all-orders-163)
        - [Order Processing Buttons Logic [164]](#order-processing-buttons-logic-164)
        - [Ship Order [165]](#ship-order-165)
            - [Fields Validation](#fields-validation)
            - [StartProcessing and ShipOrder](#startprocessing-and-shiporder)
        - [Cancel Order [166]](#cancel-order-166)
            - [Cancel Order](#cancel-order)
            - [Stripe Refund Event](#stripe-refund-event)
            - [Double Refund StripeException](#double-refund-stripeexception)
        - [There is some mess with Order and Payment Statuses](#there-is-some-mess-with-order-and-payment-statuses)
        - [Process Delayed Payment [167]](#process-delayed-payment-167)
    - [Section 13: Advance Concepts](#section-13-advance-concepts)
        - [Authorization [168]](#authorization-168)
        - [Session in .NET Core [169]](#session-in-net-core-169)
        - [Remove from Session and Bug [170]](#remove-from-session-and-bug-170)
            - [Login](#login)
            - [Remove and Minus Action Methods](#remove-and-minus-action-methods)
        - [Bug Solution and Logout [171]](#bug-solution-and-logout-171)
            - [Logout: Clear Session](#logout-clear-session)
        - [Create View Component [172]](#create-view-component-172)
        - [View Component in Action [173]](#view-component-in-action-173)
        - [Facebook Social Login [174]](#facebook-social-login-174)
        - [Facebook Login in Action [175]](#facebook-login-in-action-175)
        - [Creating Admin and Employee Accounts [176]](#creating-admin-and-employee-accounts-176)
        - [Session Bug [177]](#session-bug-177)
    - [Section 14: Deployment & Email](#section-14-deployment--email)
        - [DBInitializer [178]](#dbinitializer-178)
        - [DBInitializer Implementation [179]](#dbinitializer-implementation-179)
        - [DBInitializer in Action [180]](#dbinitializer-in-action-180)
        - [SendGrid Email Setup [181]](#sendgrid-email-setup-181)
        - [SendGrid in Action [182]](#sendgrid-in-action-182)
        - [Create Azure SQL Server and Database [183]](#create-azure-sql-server-and-database-183)
        - [Downgrade to Net 7 [184]](#downgrade-to-net-7-184)
        - [Azure Production Deployment [185]](#azure-production-deployment-185)
        - [Azure Deployment in Action [186]](#azure-deployment-in-action-186)
        - [Facebook Url [187]](#facebook-url-187)
        - [Facebook Url Error [188]](#facebook-url-error-188)
    - [Section 15: User Management](#section-15-user-management)
        - [Display User List [189]](#display-user-list-189)
        - [Display Company Name [190]](#display-company-name-190)
        - [Display Roles [191]](#display-roles-191)
        - [Lock Unlock Action Method [192]](#lock-unlock-action-method-192)
        - [Lock Unlock in Action [193]](#lock-unlock-in-action-193)
        - [Assignment 4 - User Role [194]](#assignment-4---user-role-194)
        - [Assignment 4 Solution Part 1 - View Code [195]](#assignment-4-solution-part-1---view-code-195)
        - [Assignment 4 Solution Part 2 - Role Logic [196]](#assignment-4-solution-part-2---role-logic-196)
    - [Section 16: Multiple Product Image](#section-16-multiple-product-image)
        - [Next Task [197]](#next-task-197)
        - [Remove ImageUrl from Product [198]](#remove-imageurl-from-product-198)
        - [Product Image Table [199]](#product-image-table-199)
        - [Add Product Image Repository [200]](#add-product-image-repository-200)
        - [Upload Images on Product Upsert [201]](#upload-images-on-product-upsert-201)
        - [Demo - Upload Images [202]](#demo---upload-images-202)
        - [Display Image on Update Product Page [203]](#display-image-on-update-product-page-203)
        - [Delete Image [204]](#delete-image-204)
        - [Delete Product [205]](#delete-product-205)
        - [Display Image in Shopping Cart [206]](#display-image-in-shopping-cart-206)
        - [Bootstrap Carousel [207]](#bootstrap-carousel-207)
        - [Assignment 5 - User Controller [208]](#assignment-5---user-controller-208)
        - [Assignment 5 Solution - User Controller [209]](#assignment-5-solution---user-controller-209)
        - [Microsoft Social Login [210]](#microsoft-social-login-210)
        - [Upgrade .NET Version [211]](#upgrade-net-version-211)
        - [Deploy Application to Azure using Visual Studio [212]](#deploy-application-to-azure-using-visual-studio-212)

<!-- /TOC -->

## Section 1: Welcome & Getting Started

### Course Overview [11]

- N-Tier Arch
- Repository Pattern and UoW
- TempData/ViewBag/ViewData in .NET Core - When should use each of them?
- Api Controllers, Razor Pages
- SweetAlerts, Rich Text Editor, Data Tables
- Scaffold Identity (Razor Class Library)
- Roles and Auth in .NET Core
- Stripe Payment/ Refund with .NET Core
- Sessions
- Emails with SendGrid
- User Management
- Social Login using Facebook
- Seed Db with DbInitializer
- Deploy to Azure

### Create MVC Project [12]
### Project File [13]

Project - right click - edit project file

nugets will be here

```xml
<Project Sdk="Microsoft.NET.Sdk.Web">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
  </PropertyGroup>

</Project>
```

### Launch Settings [14]

launchSettings.json

build profiles - check VS Build button

```json
{
  "$schema": "http://json.schemastore.org/launchsettings.json",
  "iisSettings": {
    "windowsAuthentication": false,
    "anonymousAuthentication": true,
    "iisExpress": {
      "applicationUrl": "http://localhost:1990",
      "sslPort": 44367
    }
  },
  "profiles": {   // build profiles
    "http": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": true,
      "applicationUrl": "http://localhost:5279",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development" // env vars, for example credit card could be different for dev and for prod
      }
    },
    "https": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": true,
      "applicationUrl": "https://localhost:7209;http://localhost:5279",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    },
    "IIS Express": {
      "commandName": "IISExpress",
      "launchBrowser": true,
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
  }
}
```

### wwwroot and appsettings [15]

#### wwwroot - static content (css, js, 3rd party libs, nuget packages, images, files, pdfs, powerpoints, etc.)

All statics goes here

- site.css
- site.js
- lib
  - bootstrap
  - jquery
  - jquery-validations
  - jquery-validations...

#### appsettings.json - Connection Strings, Secrets, Keys, DB connections, Azure DB, storage etc.

appsettings.Development.json

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

#### Swith to prod

Project -> Add new item - json AppSetting File

appsettings.Production.json

```txt
launchSettings.json - change
"ASPNETCORE_ENVIRONMENT": "Development"
to
"ASPNETCORE_ENVIRONMENT": "Production"
and settings from the appsettings.Production.json will be used
```

### Program File [16]

In the older versions we used to have 2 files

- Program.cs
- Startup.cs

Today they are combined into 1 file Program.cs

```cs
var builder = WebApplication.CreateBuilder(args);

// 1. Add services to the container.
builder.Services.AddControllersWithViews();
var app = builder.Build();
// DIs will be here...

// 2. Configure the HTTP request pipeline.
// 
if (!app.Environment.IsDevelopment()) // check setting in Json, app.Environment.IsEnvironment() could be used
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// if dev - see ex
// if not - page 

app.UseHttpsRedirection(); 
app.UseStaticFiles();      //configure wwwroot path

app.UseRouting();

app.UseAuthorization();

// How the routing should work ?
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // id can be defined or null

app.Run();
```

### MVC Architecture [17]

MVC

- Model - shape of the data
- View - UI, forms, charts, html controls
- Controller - fetch from data from the DB, handles the user request, acts as an interface between the Model and the View  

1. Request
2. Getdata from DB
3. Get Presentation

Controller have action methods

Action methods define endpoints of the controller

### Routing Overview [18]

Default route

```cs
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
```

Domain name = localhost + port name

https://localhost:5555/Category/Index/3

https://localhost:5555/{controller}/{action}/{id?}

### Routing in Action [19]

Rules defined:

**Controllers** folder
  - Home**Controller** class, filename

**Views** folder
  - **Home** folder

Models not all always needed

https://localhost:7209/

https://localhost:7209/Home/Index

the result is the same pade (default route, if no controller and action defined)

```cs
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BulkyWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
```

```cs
        public IActionResult Index()
        {
            return View();
        }
// What view will Action return?
// if the view name is not defined - the same as action name
// Home controller - Index.cshtml

return View("Privacy"); // can override will retrun Privacy view
```

What view will Action return?
if the view name is not defined - the same as action name
Home controller - Index.cshtml

### Default Views [20]

- _Layout.cshtml
  - css, js, hlml
  - @RenderBody() - building helper, here is the View from the Controller
- _ValidationScriptsPartial.cshtml
- _ Underscore = this view will be used throught our app.
- Partial View = Cannot be displayed by itsself - i will be used as part of main view
- Error.cshtml

**- How do the app knows that _Layout is the master page?**
  
  - **Defined in _ViewStart.cshtml**:

```
  @{
    Layout = "_Layout";
  }
```

_ViewImports.cshtml (global import file for Views (not for models))

```
@using BulkyWeb
@using BulkyWeb.Models
@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
```

### Go Easy on Yourself! [21]

```cs
public IActionResult Index()
{
    return View();
}
```

In .NET Core, an IActionResult is an interface that represents the result of an action method in an MVC or Web API application. It allows you to return different types of results from your action methods to control the HTTP response sent back to the client. Here are some common types that can be returned as IActionResult:

**ViewResult**: Represents an HTML view to be rendered and returned to the client in an MVC application. For example:

```cs
public IActionResult Index()
{
    return View();
}
```
**PartialViewResult**: Represents a partial HTML view to be rendered and returned to the client in an MVC application. For example:
```cs
public IActionResult PartialView()
{
    return PartialView();
}
```

**JsonResult**: Represents a JSON object that will be serialized and returned to the client in a Web API application. For example:

```cs
public IActionResult GetJsonData()
{
    var data = new { Name = "John", Age = 30 };
    return Json(data);
}
```

**ContentResult**: Represents a plain text or HTML content that will be returned to the client. For example:

```cs
public IActionResult GetText()
{
    return Content("This is some plain text.");
}
```

**FileResult**: Represents a file to be downloaded by the client. For example:

```cs
public IActionResult DownloadFile()
{
    byte[] fileBytes = ... // Load file bytes here
    return File(fileBytes, "application/octet-stream", "example.txt");
}
```

**RedirectResult**: Represents a redirection response to another URL. For example:

```cs
public IActionResult RedirectToHome()
{
    return Redirect("/home/index");
}
```

**NotFoundResult**: Represents a 404 Not Found response.

```cs
public IActionResult NotFoundExample()
{
    return NotFound();
}
```

**BadRequestResult**: Represents a 400 Bad Request response.
```cs
public IActionResult BadRequestExample()
{
    return BadRequest();
}
```

**StatusCodeResult**: Represents a custom status code response. For example:

```cs
public IActionResult CustomStatusCode()
{
    return StatusCode(403); // Returns a 403 Forbidden status code
}
```

These are just some of the common types that can be returned as IActionResult. There are additional result types and custom implementations you can create to handle specific use cases.

## Section 2: Category CRUD Operations
### Create Category Model [22]
### Data Annotations [23]

```cs
using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        public int DisplayOrder { get; set; }
    }
}

```
### Connection String [24]

In appsettings.json:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server:.;Database=Bulky;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
```

### Nuget Packages for Entity Framework Core [25]

[x] Include prerelease

- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools (for migrations)

### Setup ApplicationDbContext [26]

AppDbContext.cs

```cs
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
```

Program.cs

```cs
builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
```

### Create Database - Update-Database [27]

Package Manager Console

**update-database**

An error occurred while accessing the Microsoft.Extensions.Hosting services. Continuing without the application service provider. Error: Failed to load configuration from file

update-database -verbose

appsettings.json - Properties - Copy Always

```
[FIXED] I also had the issue "An error occurred while accessing the Microsoft.Extensions.Hosting services. Continuing without the application service provider. Error: Failed to load configuration from file ... appsettings.json"
 I fixed it: Downgraded from Latest 8.0.0-preview.6.23329.4 to latest stable 7.0.9, rebuilt solution => and update-database started working.
```

```
PM> update-database
Build started...
Build succeeded.
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (270ms) [Parameters=[], CommandType='Text', CommandTimeout='60']
      CREATE DATABASE [Bulky];
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (134ms) [Parameters=[], CommandType='Text', CommandTimeout='60']
      IF SERVERPROPERTY('EngineEdition') <> 5
      BEGIN
          ALTER DATABASE [Bulky] SET READ_COMMITTED_SNAPSHOT ON;
      END;
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (7ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT 1
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (7ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE TABLE [__EFMigrationsHistory] (
          [MigrationId] nvarchar(150) NOT NULL,
          [ProductVersion] nvarchar(32) NOT NULL,
          CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
      );
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT 1
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (13ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT OBJECT_ID(N'[__EFMigrationsHistory]');
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (16ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT [MigrationId], [ProductVersion]
      FROM [__EFMigrationsHistory]
      ORDER BY [MigrationId];
Microsoft.EntityFrameworkCore.Migrations[20405]
      No migrations were applied. The database is already up to date.
No migrations were applied. The database is already up to date.
Done.
```

### Create Category Table [28]

#### Add DbSet to AppDbContext:

```cs
public DbSet<Category> Categories { get; set; }
```

#### Add-Migration

**Add-Migration AddCategoryTableToDb**

```
Build started...
Build succeeded.
To undo this action, use Remove-Migration.
```

- Migrations folder was created
  - 20230731201532_AddCategoryTableToDb.cs

```cs
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulkyWeb.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryTableToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
```
#### Update-Database

```
PM> Update-Database
Build started...
Build succeeded.
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (20ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT 1
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (13ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT OBJECT_ID(N'[__EFMigrationsHistory]');
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (1ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT 1
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT OBJECT_ID(N'[__EFMigrationsHistory]');
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (2ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT [MigrationId], [ProductVersion]
      FROM [__EFMigrationsHistory]
      ORDER BY [MigrationId];
Microsoft.EntityFrameworkCore.Migrations[20402]
      Applying migration '20230731201532_AddCategoryTableToDb'.
Applying migration '20230731201532_AddCategoryTableToDb'.
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (13ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE TABLE [Categories] (
          [Id] int NOT NULL IDENTITY,
          [Name] nvarchar(max) NOT NULL,
          [DisplayOrder] int NOT NULL,
          CONSTRAINT [PK_Categories] PRIMARY KEY ([Id])
      );
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (3ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
      VALUES (N'20230731201532_AddCategoryTableToDb', N'7.0.9');
Done.
```

```sql
SELECT TOP (1000) [MigrationId]
      ,[ProductVersion]
  FROM [Bulky].[dbo].[__EFMigrationsHistory]
-- MigrationId	ProductVersion
--20230731201532_AddCategoryTableToDb	7.0.9
```

### Add Category Controller [29]

```cs
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

```

https://localhost:7209/Category

https://localhost:7209/Category/Index

InvalidOperationException: The view 'Index' was not found. The following locations were searched: /Views/Category/Index.cshtml /Views/Shared/Index.cshtml

Search:
  - Category Folder, Index.cshtml
  - Shared folder

Add Views\Category\Index.cshtml

### Add Category Link in Header [30]

_Layout.cshtml

```html
<li class="nav-item">
    <a class="nav-link text-dark" asp-controller="Category" asp-action="Index">Category</a>
</li>
```

### Seed Category Table [31]

#### Add OnModelCreating in  AppDbContext 

```cs
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                    new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                    new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                    new Category { Id = 3, Name = "History", DisplayOrder = 3 }
                );

            base.OnModelCreating(modelBuilder);
        }
```

#### Add-Migration SeedCategoryTable

```cs
namespace BulkyWeb.Migrations
{
    /// <inheritdoc />
    public partial class SeedCategoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "DisplayOrder", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Action" },
                    { 2, 2, "SciFi" },
                    { 3, 3, "History" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
```

#### Update-Database

```
PM> Update-Database
Build started...
Build succeeded.
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (19ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT 1
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (14ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT OBJECT_ID(N'[__EFMigrationsHistory]');
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (1ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT 1
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (1ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT OBJECT_ID(N'[__EFMigrationsHistory]');
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (8ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT [MigrationId], [ProductVersion]
      FROM [__EFMigrationsHistory]
      ORDER BY [MigrationId];
Microsoft.EntityFrameworkCore.Migrations[20402]
      Applying migration '20230731214118_SeedCategoryTable'.
Applying migration '20230731214118_SeedCategoryTable'.
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (38ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DisplayOrder', N'Name') AND [object_id] = OBJECT_ID(N'[Categories]'))
          SET IDENTITY_INSERT [Categories] ON;
      INSERT INTO [Categories] ([Id], [DisplayOrder], [Name])
      VALUES (1, 1, N'Action'),
      (2, 2, N'SciFi'),
      (3, 3, N'History');
      IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DisplayOrder', N'Name') AND [object_id] = OBJECT_ID(N'[Categories]'))
          SET IDENTITY_INSERT [Categories] OFF;
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (1ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
      VALUES (N'20230731214118_SeedCategoryTable', N'7.0.9');
Done.
```

### Get all Categories [32]

Remember, the AppDbContext was added as a service in Program.cs:

```cs
builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
```

so:

```cs
using Microsoft.AspNetCore.Mvc;
using BulkyWeb.Data;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _db;

        public CategoryController(AppDbContext db)
        {
            _db = db;    
        }

        public IActionResult Index()
        {
            var categoryList = _db.Categories.ToList();
            return View();
        }
    }
```

### Hot Reload [33]

VS - Run project - fire button - Hot Reload on File Save option

So it is possible to modify the page and observe changes on the fly.

### Display all Categories [34]

Pass the model to the View:

```cs
var categoryList = _db.Categories.ToList();
return View(categoryList);
```

```html
@model List<Category>
<h1>Category List</h1>
<table class="table table-bordered table-striped">
    
    <thead>
    <tr>
        <th>
            Category Name
        </th>
        <th>
            Category Order
        </th>
    </tr>
    </thead>

    <tbody>
        @foreach(var obj in Model.OrderBy(u => u.DisplayOrder))
        {
        <tr>
            <td> @obj.Name </td>
            <td> @obj.DisplayOrder </td>
        </tr>
        }
    </tbody>
</table>
```

### Bootswatch Theme and Bootstrap Icons [35]

https://bootswatch.com/

https://icons.getbootstrap.com/

```
CDN
Include the icon fonts stylesheet—in your website <head> or via @import in CSS—from jsDelivr and get started in seconds. See icon font docs for examples.
```

copy CDN

```html
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.5/font/bootstrap-icons.css">
```
to _Layout.cshtml

Search heart-fill icon

https://icons.getbootstrap.com/icons/heart-fill/


### Design Category List Page [36]

```html
@model List<Category>

    <div class="container">
        <div class="row pt-4 pb-3"> @* In Bootstrap Row is divided into 12 columns *@
            <div class="col-6">
                <h2 class="text-primary">Category List</h2>
            </div>

            <div class="col-6 text-end">
                <a asp-controller="" asp-action="" class="btn btn-primary">
                <i class="bi bi-plus-circle"></i> Create New Category
                </a>
            </div>
    </div>

        <table class="table table-bordered table-striped">
    
            <thead>
            <tr>
                <th>
                    Category Name
                </th>
                <th>
                    Category Order
                </th>
            </tr>
            </thead>

            <tbody>
                @foreach(var obj in Model.OrderBy(u => u.DisplayOrder))
                {
                <tr>
                    <td> @obj.Name </td>
                    <td> @obj.DisplayOrder </td>
                </tr>
                }
            </tbody>
        </table>
</div>
```

### Create Category UI [37]

```
return View();//in controller
@model Category//in cshtml view
You can pass View(new Category());
But by default it creates new Model i.e. new Category 
```

```html
@model Category

<form method="post">
    <div class="border p-3 mt-4">
        <div class="row pb-2">
            <h2 class="text-primary">Create Category</h2>
            <hr/>
        </div>
        <div class="mb-3 row p-1">
            <label class="p-0">Name</label>
            <input type="text" class="form-control" />
        </div>
        <div class="mb-3 row p-1">
            <label class="p-0">Display Order</label>
            <input type="text" class="form-control" />
        </div>

        <div class="row">
            <div class="col-6 col-md-3">
                <button type="submit" class="btn btn-primary form-control" style="width:200px">Create</button>
            </div>
            <div class="col-6 col-md-3">
                <a asp-controller="Category" asp-action="Index" class="btn btn-outline-secondary form-control" style="width:200px">
                    Back to List
                </a>
            </div>
        </div>
    </div>
</form>
```


### Input Tag Helpers [38]

asp-for tag helper

for the label - int can take a display name from the models annotation

```cs
[Required]
[DisplayName("Category Name")]
public string Name { get; set; } = string.Empty;
```

```html
<div class="mb-3 row p-1">
    <label asp-for="Name" class="p-0"></label>
    <input asp-for="Name" type="text" class="form-control" />
</div>
<div class="mb-3 row p-1">
    <label asp-for="DisplayOrder" class="p-0"></label>
    <input asp-for="DisplayOrder" type="text" class="form-control" />
</div>
```

### Create Category [39]

```cs
[HttpPost]
public IActionResult Create(Category obj)
{
    _db.Categories.Add(obj);
    _db.SaveChanges();
    return RedirectToAction("Index");
}
```

### Built-In Server Side Validations [40]

```cs
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }
        //...
        [DisplayName("Display Order")]
        [Range(1,100, ErrorMessage = "The field Display Order must be between 1 - 100 (my custom message)")]
        public int DisplayOrder { get; set; }
```

```html
<span asp-validation-for="Name" class="text-danger"></span>
```

### Custom Validations [41]

```cs
        public IActionResult Create(Category obj)
        {
            if (obj.Name.Equals(obj.DisplayOrder.ToString()))
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name");
            }

            if (ModelState.IsValid)
            //...
```

```html
<div asp-validation-summary="All"></div>
```

### Asp Validation Summary [42]

```cs
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name");
            }

            if (obj.Name != null && obj.Name.ToLower() == "test")
            {
                ModelState.AddModelError("", $"{obj.Name} is an invalid value"); 
                // the key is not specified, so this message will be available in asp-validation-summary
            }
```
```html
<div asp-validation-summary="All"></div>
```
asp-validation-summary
- All
- ModelOnly
- None

### Client Side Validation [43]

Server Side Validations - hits the debugging poibt ib the controller, page reloads, spinner on the top => it is going to the server

JavaScript - Client Side

_ValidationScriptsPartial.cshtml

```html
<script src="~/lib/jquery-validation/dist/jquery.validate.min.js"></script>
<script src="~/lib/jquery-validation-unobtrusive/jquery.validate.unobtrusive.min.js"></script>
```

So include partial view _ValidationScriptsPartial.cshtml

Shared folder is default for partial views

```html
@section Scripts{
    @{
    <partial name="_ValidationScriptsPartial"/>
    }
}
```

- Client-Side Validation don't hit the server.
- More dynamic
- But "Create" button will hit server.

### Edit and Delete Buttons [44]

```html
<td>
    <div class="w-75 btn-group" role="group">
        <a asp-controller="Category" asp-action="Edit" class="btn btn-primary mx-2">
            <i class="bi bi-pencil-square"></i> Edit
        </a>
        <a asp-controller="Category" asp-action="Delete" class="btn btn-outline-danger mx-2">
            <i class="bi bi-trash3-fill"></i> Delete
        </a>
    </div>
</td>
```

### Get Category Details to Edit [45]
```
Add
asp-route-id="@obj.Id"
```
```html
<a asp-controller="Category" asp-action="Edit" asp-route-id="@obj.Id" class="btn btn-primary mx-2">
    <i class="bi bi-pencil-square"></i> Edit
</a>
```

```cs
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            //var category = _db.Categories.Find(id); // id is primary key
            var category = _db.Categories.FirstOrDefault(c => c.Id == id); // works even is id is not primary
            //var category = _db.Categories.Where(category => category.Id == id).FirstOrDefault();
            if (category == null)
            {
                return NotFound();
            }
            
            return View(category);
        }
```

### Update Category [46]

Add Razor View (it is different)

- View name
- Template
- ...
- [] Create as partial view
- [x] Use a layout page

Scaffolding...

Similar to Create, (but with no server validation)

### Update Category in Action [47]

**Make sure that the Id is populated!**

In our case Id = Id

But if the Id has another name, it should be specified!

```html
<input asp-for="Id" hidden /> @* it is not required for the "Id" but it is required for another name *@
```

### Get and Post Action for Delete Category [48]

```cs
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var category = _db.Categories.FirstOrDefault(c => c.Id == id);
            
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // used the id as a parameter, not the obj,
        // so the POST method name should be different,
        // and so - declared the Action Name [HttpPost, ActionName("Delete")] 
        [HttpPost, ActionName("Delete")] 
        public IActionResult DeletePost(int? id)
        {
            Category? obj = _db.Categories.Find(id);
            if (obj == null) 
            {
                return NotFound();
            }

            _db.Categories.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
```

### Delete Category in Action [49]

Delete View - same as Edit bu without any validation

To pass the required id,

the button should contain `asp-route-id="@obj.Id"`

```html
<a asp-controller="Category" asp-action="Delete" asp-route-id="@obj.Id" class="btn btn-outline-danger mx-2">
```

### TempData [50]

- Only for 1 request, than is goes away
- Refresh the page - it will be dismissed

https://learn.microsoft.com/en-us/aspnet/core/fundamentals/app-state?view=aspnetcore-7.0#tempdata

```cs
_db.Categories.Update(obj);
_db.SaveChanges();
TempData["success"] = "Category updated successfully";
```

```cs
@if (TempData["success"] != null)
{
    <h2>@TempData["success"]</h2>
}
```

We used tempdata to share the notification

### Partial Views [51]

But what if we need it for Orders, user info etc?

- Use Partial View

Shared\_Notification.cshtml

use it:

```html
<partial name="_Notification" />
```

### Toastr Notification [52]

https://codeseven.github.io/toastr/

https://codeseven.github.io/toastr/demo.html

copy CDN

//cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/css/toastr.css

a it to styling
``` 
remove <h2>@TempData["error"]</h2>
```
as follows

```html
@if (TempData["success"] != null)
{
    <script src="~/lib/jquery/dist/jquery.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/js/toastr.min.js"></script>
    @* <script src="//cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/js/toastr.js"></script> *@ @* Debug version *@

    @* <h2>@TempData["success"]</h2> *@
    <script type="text/javascript">
        toastr.success('@TempData["success"]');   @* Note: '' is important =) *@
    </script>
    
}

@if (TempData["error"] != null)
{
    @* <h2>@TempData["error"]</h2> *@
    <script src="~/lib/jquery/dist/jquery.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/js/toastr.min.js"></script>
    <script type="text/javascript">
        toastr.error('@TempData["error"]');
    </script>
}

```

Note: '   ' are important =)
 
### Share Toastr Notification across the project [52]

Share toastr functionality for all views:

Move from Index Page to _Layout, before the @RenderBody()

```html
            <partial name="_Notification" />
            @RenderBody()
```

## Section 3: Razor Project

### Create Razor Project [53]
### What's Different in Razor Project? [54]

```cs
//1
builder.Services.AddRazorPages();
//vs.
builder.Services.AddControllersWithViews();

//2
app.MapRazorPages(); //(exact routing Index = Index, Privacy=Privacy)
//vs.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Category}/{action=Index}/{id?}");
//pattern: "{controller=Home}/{action=Index}/{id?}");

// 3. No folders Models Views Controllers
// 4. @page directive in view
// 5. Index.cshtml, Index.cshtml.cs = page model

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet() // "On" is required
        {

        }
    }
}
```

NB! 

Package Manager Console - Select current project!

Add-Migration addCategoryToDb

Update-Database

And we have our new DB

### Setup EF Core [55]

- Do not add reference to BulkyWeb, it is separate project
- Copy AppDbContext and cn strings, and the rest same setup from BulkyWeb 
- namespace - BulkyWebRazor_Temp.Models, not BulkyWeb

### Create first Razor Page [56]

- We don't have views, we have Razor pages
- With razor pages we don't have complex routing with controllers, actions, route params etc.
- Add Empty Razor page - Pages\Categories\Index.cshtml

```html
@page
@model BulkyWebRazor_Temp.Categories.IndexModel
@{
}
```

https://localhost:7138/categories/index

### Display all Categories [57]

#### MVC View vs. Razor Page [57]

- Model.**CategoryList**.OrderBy - page model
- **no** asp-action
- **no** asp-controller
- asp-route-id **is still valid**

MVC view:
```html
<a asp-controller="Category" asp-action="Delete" asp-route-id="@obj.Id" class="btn btn-outline-danger mx-2">
```
Razor page:
```html
<a asp-page="Category/delete" asp-route-id="@obj.Id" class="btn btn-outline-danger mx-2">
    <i class="bi bi-trash3-fill"></i> Delete
</a>
```

### Create Category UI [58]

If there is no View

- With the MVC app - you will see Page not found page
- But with the Razor pages - it will not even redirect

```html
<a asp-page="/categories/create" class="btn btn-primary">
```

/categories/create

need '/' before categories/create

### Create Category Post Handler [59]

#### [BindProperty], [BindProperties]

Our Category was null

Because in Razor pages we need [BindProperty]

**We have explicitly bind properties that we want to access after POST of the form.**

```cs
        [BindProperty]
        public Category Category { get; set; }
```

Bind all props in a page model:

```cs
    [BindProperties]
    public class CreateModel : PageModel
    {...
```

#### RedirectToPage

so we don't need an obj parameter in our OnPost():

```cs
        public IActionResult OnPost()
        {
            _db.Categories.Add(Category);
            _db.SaveChanges();
            return RedirectToPage("Index");
        }
```

- in MVC we have RedirectToAction()
- in Razor pages we have **RedirectToPage()**

### Edit and Delete Category [60]

Be sure to check if(ModelState.IsValid) 

### Toastr Notifications and Partial Views [61]

Add _Notification page into the Shared folder,

remove _Notification.cshtml.cs, we don't need it

**DotNet Identity is built on top of Razor Pages**

## Section 4: N-Tier Architecture

### Create More Projects [62]

### Modify Styling Refresh [63]

In the next video we will be modifying the style. 

If the changes do not reflect in the browser make sure to hard refresh by pressing **Ctrl+ F5**.

### Modify Styling [64]

https://bootswatch.com/

https://bootswatch.com/sandstone/

https://github.com/bhrugen/Bulky_MVC

### Modify UI of Category Pages [65]

### N-Tier Architecture [66]

### How to Reset Database [67]

- You can rollback migration, add new model, etc.

- Delete the Bulky DB in SSMS
- Delete Migrations
- Package Manager Console 
  - **Set target project Bulky.DataAccess!**
  - add-migration AddCategoryToDbAndSeedTable
  - Update-Database

```sql
SELECT *  FROM [Bulky].[dbo].[__EFMigrationsHistory]
-- MigrationId	ProductVersion 
-- 20230820110305_AddCategoryToDbAndSeedTable	7.0.9
```

```
PM> Update-Database
Build started...
Build succeeded.
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (247ms) [Parameters=[], CommandType='Text', CommandTimeout='60']
      CREATE DATABASE [Bulky];
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (58ms) [Parameters=[], CommandType='Text', CommandTimeout='60']
      IF SERVERPROPERTY('EngineEdition') <> 5
      BEGIN
          ALTER DATABASE [Bulky] SET READ_COMMITTED_SNAPSHOT ON;
      END;
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (11ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT 1
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (18ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE TABLE [__EFMigrationsHistory] (
          [MigrationId] nvarchar(150) NOT NULL,
          [ProductVersion] nvarchar(32) NOT NULL,
          CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
      );
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (1ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT 1
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (16ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT OBJECT_ID(N'[__EFMigrationsHistory]');
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (22ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT [MigrationId], [ProductVersion]
      FROM [__EFMigrationsHistory]
      ORDER BY [MigrationId];
Microsoft.EntityFrameworkCore.Migrations[20402]
      Applying migration '20230820110305_AddCategoryToDbAndSeedTable'.
Applying migration '20230820110305_AddCategoryToDbAndSeedTable'.
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (4ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE TABLE [Categories] (
          [Id] int NOT NULL IDENTITY,
          [Name] nvarchar(300) NOT NULL,
          [DisplayOrder] int NOT NULL,
          CONSTRAINT [PK_Categories] PRIMARY KEY ([Id])
      );
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (41ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DisplayOrder', N'Name') AND [object_id] = OBJECT_ID(N'[Categories]'))
          SET IDENTITY_INSERT [Categories] ON;
      INSERT INTO [Categories] ([Id], [DisplayOrder], [Name])
      VALUES (1, 1, N'Action'),
      (2, 2, N'SciFi'),
      (3, 3, N'History');
      IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DisplayOrder', N'Name') AND [object_id] = OBJECT_ID(N'[Categories]'))
          SET IDENTITY_INSERT [Categories] OFF;
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (2ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
      VALUES (N'20230820110305_AddCategoryToDbAndSeedTable', N'7.0.9');
Done.
```

### Bonus - Dependency Injection Service Lifetimes [68]

DI Services Lifetime:

- **Transient** - whenever we want object - create a new object, do nor reuse this object
- **Scoped** - 1 per HTTP request, same object is reused for this HTTP request, for the next HTTP request - new instance will be created.
  - Recommended
- **Singleton** - 1 instance for the app instance, once per application lifetime

## Section 5: Repository Pattern

NB!
- in Edit(), we also call _db.SaveChanges();
- In generic repository we don't like to have Update() and Add()
- The reason is simple: Updating a Category could differ from updating a Product or something else 
- So keep Update and SaveChanges **OUT of REPO**

### IRepository Interface [69]

```cs
using System.Linq.Expressions;

namespace Bulky.DataAccess.Repository.IRepository
{
    internal interface IRepository<T> where T : class
    {
        // T = Category
        IEnumerable<T> GetAll();
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);

        //void Update(T entity);
        //NB!
        //in Edit(), we also call _db.SaveChanges();
        //In generic repository we don't like to have Update() and Add()
        //The reason is simple: Updating a Category could differ from updating a Product or something else 
        //So keep Update and SaveChanges **OUT of REPO**

    }
}

```

### Implement Repository Interface [70]

We need DbSet:

_db.Categories ==is== dbSet and _db.Categories.Add() becomes => dbSet.Add()

```cs
using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Bulky.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _db;
        internal DbSet<T> dbSet;
        public Repository(AppDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
            //We need DbSet:
            // _db.Categories ==is== dbSet and _db.Categories.Add() becomes=> dbSet.Add()
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }
    }
}

```

### ICategoryRepository [71]

It also contains methods from IRepository + our Update() and Save() methods

```cs
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category obj);
        
        void Save();
    }
```

### Implement Category Repository [72]

```cs
using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;

namespace Bulky.DataAccess.Repository
{
    // Basic functionality - from Repository<Category>, and Update could differ
    // And have to inject app db context for it (Repository<Category>)
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private AppDbContext _db;

        public CategoryRepository(AppDbContext db) : base(db) // and pass to base (Repository<Category>)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Category obj)
        {
            _db.Update(obj);
        }
    }
}

```

### Replace DbContext with Category Repository [73]

#### Do not use DbContext directly (in Controller), use repository instead.

```
An unhandled exception occurred while processing the request.
InvalidOperationException: Unable to resolve service for type 'Bulky.DataAccess.Repository.IRepository.ICategoryRepository' while attempting to activate 'BulkyWeb.Controllers.CategoryController'.
```

Right!

#### Do not forget to register our repo

```cs
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
```

### How Easy is it to move to a Different Database? [74]

Change Connection string (get server name from SSMS)

### Renaming Project and Solving Issues [75]

- Clean \Bulky\.vs\
- Delete BulkyWeb.csproj.user 
- Restart VS
- Rename Projects
- Replace All Bulky -> BulkyBook
- But leave the Connection String in appsettings.json: "DefaultConnection": "Server=.;Database=Bulky;Trusted_Connection=True;TrustServerCertificate=True"
- Restart VS
- Update project refs if there is a need 

- Issue: System.InvalidOperationException: 'An exception has been raised that is likely due to a transient failure. Consider enabling transient error resiliency by adding 'EnableRetryOnFailure' to the 'UseSqlServer' call.'
- Solution: Update connection string

- Issue: Broken footer
- Solution: Rebuild to bind all css in _Layout

```xml
    <link rel="stylesheet" href="~/BulkyBookWeb.styles.css" asp-append-version="true" />
```

### UnitOfWork Implementation [76]

### UnitOfWork in Action [77]

UnitOfWork instead of using repo directly

#### Pros and Cons

- Advantage: Access to all repositories
- Disadvantage: If we need the access only to Category? We will have the access to all repos registered in UoW 

### Areas in .NET [78]

One more hierarchy level

#### Customer vs Admin Page

BulkyBookWeb - Add - New Scaffolded Item - MVC Area - Admin
- Admin
- Customer

Routing is changed

Scaffolding has generated all the files and added the required dependencies.

However the Application's Startup code may require additional changes for things to work end to end.
Add the following code to the Configure method in your Application's Startup class if not already done:
```cs
        app.UseEndpoints(endpoints =>
        {
          endpoints.MapControllerRoute(
            name : "areas",
            pattern : "{area=Customer}/{controller=Home}/{action=Index}/{id?}"
            //pattern : "{area = Admin}/{controller=Home}/{action=Index}/{id?}" // Use =
          );
        });
```

So

```cs
app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Category}/{action=Index}/{id?}");
```

- Admin (area)
  - Controllers
  - Data
  - Models
  - Views

Remove Data and Models (they are in different projects)

The same - for the Customer

Move 
- Controllers and Views (Category and Home folders)
- CategoryController -> Admin
- HomeController -> Customer
- Views (Category and Home folders)
- _ViewImports.cshtml
- _ViewStart.cshtml

Q: How to tell a controller that it belongs to a specific area ?

A: 

```cs
[Area("Customer")]
```

Issue:

System.TypeInitializationException: 'The type initializer for 'Microsoft.Extensions.DependencyInjection.DependencyInjectionEventSource' threw an exception.'

```
System.TypeInitializationException
  HResult=0x80131534
  Message=The type initializer for 'Microsoft.Extensions.DependencyInjection.DependencyInjectionEventSource' threw an exception.
  Source=Microsoft.Extensions.DependencyInjection
  StackTrace:
   at Microsoft.Extensions.DependencyInjection.ServiceProvider..ctor(ICollection`1 serviceDescriptors, ServiceProviderOptions options)
   at Microsoft.Extensions.DependencyInjection.ServiceCollectionContainerBuilderExtensions.BuildServiceProvider(IServiceCollection services, ServiceProviderOptions options)
   at Microsoft.Extensions.Hosting.HostApplicationBuilder.Build()
   at Microsoft.AspNetCore.Builder.WebApplicationBuilder.Build()
   at Program.<Main>$(String[] args) in F:\bla\git\patel-netcore-mvc\Bulky\BulkyWeb\Program.cs:line 17

  This exception was originally thrown at this call stack:
    [External Code]

Inner Exception 1:
TypeLoadException: Could not load type 'System.Runtime.CompilerServices.NullableContextAttribute' from assembly 'System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'.
```

Solution: Cleaned project files

### Dropdown in NavBar [79]

<https://getbootstrap.com/>

<https://getbootstrap.com/docs/5.3/components/navbar/#how-it-works>

## Section 6: Product CRUD

### Create Product Model [80]

```cs
using System.ComponentModel.DataAnnotations;

namespace BulkyBook.Models.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        [Required]
        public string ISBN { get; set; }
        
        [Required]
        public string Author { get; set; }
        
        [Required]
        [Display(Name = "List Price")]
        [Range(1, 1000)]
        public double ListPrice { get; set; }

        [Required]
        [Display(Name = "Price for 1-50")]
        [Range(1, 1000)]
        public double Price { get; set; }

        [Required]
        [Display(Name = "Price for 50+")]
        [Range(1, 1000)]
        public double Price50 { get; set; }

        [Required]
        [Display(Name = "Price for 100+")]
        [Range(1, 1000)]
        public double Price100 { get; set; }

        //TODO: Category and image 
    }
}
```

### Seed Product and Assignment 1 [81]
### Assignment 1 Solution - Product Repository and UnitOfWork [82]

#### Push Products to the DB

- Add-Migration AddProductTableToDb
- Update-Database

#### Implement Product Repo

```cs
using BulkyBook.Models.Models;

namespace BulkyBook.DataAccess.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product obj);
    }
}
```

```cs
using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models.Models;

namespace BulkyBook.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private AppDbContext _db;

        public ProductRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product obj)
        {
            _db.Products.Update(obj);
        }
    }
}
```

#### Config Product Repo in UoW

```cs
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        IProductRepository Product { get; }

        void Save();
    }
```

```cs
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _db;
        
        public ICategoryRepository Category { get; private set; }
        public IProductRepository Product { get; private set; }
        
        public UnitOfWork(AppDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Product = new ProductRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
```

### Assignment 2 - Product CRUD Operations [83]

#### Create Product Controller and Action methods (Create/Edit/Delete/Index)

#### Create Views for (Create/Edit/Delete/Index)

#### Add Client-Side and Server-Side Validation

### Assignment 2 Solution - Product CRUD Operations [84]
### Add Foreign Key in EF Core [85]

Add to the Product model:  

We need a navigation Property to Category

```cs
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; } //We need a navigation Property to Category
```

Add-Migration addForeignKeyForCategoryProductRelation

```
Build started...
Build succeeded.
An operation was scaffolded that may result in the loss of data. Please review the migration for accuracy.
To undo this action, use Remove-Migration.

Remove-Migration

Add-Migration addForeignKeyForCategoryProductRelation
...
```
Update-Database


### Add Image Url Column [86]

### Projections in EF Core [87]

We need to Retrieve and Pass a list of Categories from controller to the view

```cs
//IEnumerable<SelectListItem> categoryList = 
//    _unitOfWork.Category.GetAll().ToList(); ... 
```
- Q: How to convert?
- A: Projections in .NET Core

```cs
IEnumerable<SelectListItem> categoryList =
    _unitOfWork.Category.GetAll().Select(u => new SelectListItem()
    {
        Text = u.Name,
        Value = u.Id.ToString()
    });
```

### Viewbag in Action [88]

- Q: And how to pass it?
- A: via ViewBag 
  - ViewBag transfers data from controller to View and NOT vise-versa
  - Ideal for situations in which the temp data is not in a model
  - ViewBag is dynamic property, C# 4.0
  - Any number of properties can be assigned to ViewBag
  - The ViewBag's life only lasts during the current http request.
  - ViewBag values will be null if the redirection occurs.
  - ViewBag is wrapper around the ViewData

```cs
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> categoryList =
                _unitOfWork.Category.GetAll().Select(u => new SelectListItem()
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });

            ViewBag.CategoryList = categoryList;

            return View();
        }
```

```cs
    <div class="form-floating py-2 col-12">
        <select asp-for="CategoryId" asp-items="ViewBag.CategoryList" type="text" class="form-select border-0 shadow">
            <option disabled selected>--Select Category--</option>
        </select>
        <label asp-for="CategoryId" class="ms-2"></label>
        <span asp-validation-for="CategoryId" class="text-danger"></span>
    </div>
```

### ViewData in Action [89]

ViewData
- Transfers data from controller to View and NOT vise-versa (same as ViewBag)
- Ideal for situations in which the temp data is not in a model (same as ViewBag)
- ViewData is derived from ViewDataDictionary which is a dictionary type
- ViewData MUST be type cast before use
- ViewBag values will be null if the redirection occurs. (same as ViewBag)
- ViewBag is wrapper around the ViewData (same as ViewBag)

NB!

**ViewBag internally inserts data into ViewData dictionary.**

So, **the key of ViewData and property of ViewBag MUST NOT MATCH**

### Remember TempData [89]

- Used to Store data between 2 consecutive requests
- Internally use Session to store the data.
  - So think of it as a short lived session
- Values must be type cast before use
  - Check for null before use to avoid runtime errors
- TempData can be used to store only one time messages like 
  - Error messages 
  - Validation messages

### View Models in Action [90]

But what if we have 10 ViewData and 20 ViewBags ?

Alternatively, tie the view with the object that you want.

ViewModel is a model specifically for View

Why?
```
System.NullReferenceException: 'Object reference not set to an instance of an object.'
```
Because ValidationState.IsValid = false

Because everything is validated, including ProductViewModel in VM,

So Skip validation using 
```
[ValidateNever]
```

**Strongly typed View**

https://learn.microsoft.com/en-us/aspnet/mvc/overview/views/dynamic-v-strongly-typed-views


```cs
        [HttpPost]
        public IActionResult Create(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(productViewModel.Product);
                _unitOfWork.Save();
                TempData["success"] = "Product created successfully";
                return RedirectToAction("Index");
            }
            else
            {
                productViewModel.CategoryList = 
                    _unitOfWork.Category.GetAll().Select(u => new SelectListItem()
                    {
                        Text = u.Name,
                        Value = u.Id.ToString()
                    });

                // In case of validation error - return the same page, do not forget the CategoryList
                return View(productViewModel);
            }
        }
```

```cs
<div class="form-floating py-2 col-12">
    <select asp-for="@Model.Product.CategoryId" asp-items="@Model.CategoryList" type="text" class="form-select border-0 shadow">
        <option disabled selected>--Select Category--</option>
    </select>
    <label asp-for="Product.CategoryId" class="ms-2"></label>
    <span asp-validation-for="Product.CategoryId" class="text-danger"></span>
</div>
```
### File Upload Input [91]

NB!

enctype="multipart/form-data"

```cs
        <form method="post" class="row" enctype="multipart/form-data">
                <div class="form-floating py-2 col-12">
                    <input type="file" class="form-control border-0 shadow" />
                    <label asp-for="Product.ImageUrl" class="ms-2"></label>
                </div>
```

### Combine, Create, and Edit Pages [92]

Combine Update and Insert = UpdateInsert = **Upsert()**

```cs
        public IActionResult Upsert(int? id)
        {
            ProductViewModel productViewModel = new()
            {
                Product = new Product(),
                CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem()
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                })
            };
            if(id == null || id == 0)
            {
                //create
                return View(productViewModel);
            }
            else
            {
                //update
                productViewModel.Product = _unitOfWork.Product.Get(u => u.Id == id);
                return View(productViewModel);
            }
            
        }

        [HttpPost]
        public IActionResult Upsert(ProductViewModel productViewModel, IFormFile? file) // remember enctype="multipart/form-data" ?
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(productViewModel.Product);
                _unitOfWork.Save();
                TempData["success"] = "Product created successfully";
                return RedirectToAction("Index");
            }
            else
            {
                productViewModel.CategoryList = 
                    _unitOfWork.Category.GetAll().Select(u => new SelectListItem()
                    {
                        Text = u.Name,
                        Value = u.Id.ToString()
                    });

                // In case of validation error - return the same page, do not forget the CategoryList
                return View(productViewModel);
            }
        }

```
we need
```
<input asp-for="Product.Id" hidden />
```
Update Issue:
```

-		$exception	{"An error occurred while saving the entity changes. See the inner exception for details."}	Microsoft.EntityFrameworkCore.DbUpdateException

		Message	"Cannot insert explicit value for identity column in table 'Products' when IDENTITY_INSERT is set to OFF."	string
-		InnerException	{"Cannot insert explicit value for identity column in table 'Products' when IDENTITY_INSERT is set to OFF."}	System.Exception {Microsoft.Data.SqlClient.SqlException}
```

### Rich Text Editor [93]

https://www.tiny.cloud/

https://www.tiny.cloud/my-account/dashboard/

### Create Product [94]

```cs
        [HttpPost]
        public IActionResult Upsert(ProductViewModel productViewModel, IFormFile? file) // remember enctype="multipart/form-data" ?
```

Save IFormFile? file in wwwroot Images\product

Inject web host environment (built in functionality, no need to register)

(name="file") - bind with (IFormFile? file) :

```cs
    <div class="form-floating py-2 col-12">
        <input type="file" name="file" class="form-control border-0 shadow" />
        <label asp-for="Product.ImageUrl" class="ms-2"></label>
    </div>
```

```cs
[HttpPost]
public IActionResult Upsert(ProductViewModel productViewModel, IFormFile? file) // remember enctype="multipart/form-data" ?
{
    if (ModelState.IsValid)
    {
        string wwwRootPath = _webHostEnvironment.WebRootPath; // wwwroot
        if(file != null)
        {
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string productPath = Path.Combine(wwwRootPath, @"images\product");
            string fullFilePath = Path.Combine(productPath, fileName);
            using (var fileStream = new FileStream(fullFilePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            productViewModel.Product.ImageUrl = @"images\product" + fileName;
        }
    ...
```

### Display Image on Update [95]

```cs
<div class="col-2">
    <img src = "@Model.Product.ImageUrl" width="100%"
    style="border-radius:5px; border: 1px solid #bbb9b9"/>
</div>
```

### Handle Image on Update [96]

```cs
...
                if(!string.IsNullOrEmpty(productViewModel.Product.ImageUrl))
                {
                    // delete the old image
                    var oldImagePath = Path.Combine(wwwRootPath, productViewModel.Product.ImageUrl.TrimStart('\\'));

                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }
...
```

### Custom Product Update [97]

```cs
        <form method="post" class="row" enctype="multipart/form-data">
            <input asp-for="Product.Id" hidden />
            <input asp-for="Product.ImageUrl" hidden /> 
            !!!
```
Product repo:
```cs
        public void Update(Product obj)
        {
            //_db.Products.Update(obj);

            // We can be explicit
            var objFromDb = _db.Products.FirstOrDefault(u => u.Id == obj.Id);

            if(objFromDb != null)
            {
                objFromDb.Title = obj.Title;
                objFromDb.ISBN = obj.ISBN;
                objFromDb.Price = obj.Price;
                objFromDb.Price50 = obj.Price50;
                objFromDb.ListPrice = obj.ListPrice;
                objFromDb.Price100 = obj.Price100;
                objFromDb.Description = obj.Description;
                objFromDb.CategoryId = obj.CategoryId;
                objFromDb.Author = obj.Author;
                if (obj.ImageUrl != null)
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
                }
            }
        }
```

Cleanup

```sql
update [Bulky].[dbo].[Products] set ImageUrl = '' where ImageUrl != ''
```

### Loading Navigation Properties [98]

The included property will automatically been populated based on foreign key relation

```cs
        void IncludePropertiesForDbSet(ref IQueryable<T> query, string? includeProperties = null)
        {
            if (!string.IsNullOrEmpty(includeProperties))
            {
                var properties = includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var includeProperty in properties)
                {
                    query = query.Include(includeProperty); 
                    // The property will automatically been populated based on foreign key relation
                }
            }
        }

        public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);

            IncludePropertiesForDbSet (ref query, includeProperties);

            return query.FirstOrDefault();
        }

        // Category, Cover, etc.
        public IEnumerable<T> GetAll(string? includeProperties = null) // Case sensitive!
        {
            IQueryable<T> query = dbSet;

            IncludePropertiesForDbSet(ref query, includeProperties);

            return query.ToList();
        }
```

### Use of DataTables API [99]

Search? Pagination? Sorting? ... etc

https://datatables.net/

.NET Core: API support is added to the controller already

```cs
//https://localhost:7209/Admin/Product/getall
[HttpGet]
public IActionResult GetAll()
{
    var productList = _unitOfWork.Product.GetAll(includeProperties: "Category").ToList();
    return Json(new { data = productList });
}
```

### Load DataTables [100]

https://datatables.net/manual/ajax

Loading data

Ajax data is loaded by DataTables simply by using the ajax option to set the URL for where the Ajax request should be made. For example, the following shows a minimal configuration with Ajax sourced data:

```js
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/product/getall' },
        "columns": [
            { data: 'title', "width": "20%" },
            { data: 'author', "width": "20%" },
            { data: 'isbn', "width": "10%" },
            { data: 'price', "width": "10%" },
            { data: 'category.name', "width": "15%" }
        ]
    });
}
```

Very common error messages with data tables:

We need to have an exact column names, as in the JSON file

Format the json from https://localhost:7209/Admin/Product/GetAll 

```json
{
  "data": [
    {
      "id": 1,
      "title": "Fortune of Time",
      "description": "Praesent vitae sodales libero. ... tincidunt. ",
      "isbn": "SWD9999001",
      "author": "Billy Spark",
      "listPrice": 99,
      "price": 90,
      "price50": 85,
      "price100": 80,
      "categoryId": 1,
      "category": {
        "id": 1,
        "name": "Action",
        "displayOrder": 3
      },
      "imageUrl": ""
    },
```

### Datatable column count [101]

- Columns must match
- the Number of columns in js cannot exceed the number of columns in cshtml!

### Edit Product Link in DataTable [102]

```js
function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/product/getall' },
        "columns": [
            { data: 'title', "width": "10%" },
            { data: 'author', "width": "10%" },
            { data: 'isbn', "width": "10%" },
            { data: 'price', "width": "10%" },
            { data: 'category.name', "width": "10%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                     <a href="/admin/product/upsert?id=${data}" class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i> Edit</a>               
                     <a class="btn btn-danger mx-2"> <i class="bi bi-trash-fill"></i> Delete</a>
                    </div>`
                },
                "width": "15%"
            }
        ]
    });
}
```

### Delete Product [103]

```cs
        public IActionResult Delete(int? id)
        {
            var productToBeDeleted = _unitOfWork.Product.Get(u => u.Id == id);
            
            if (productToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, productToBeDeleted.ImageUrl.TrimStart('\\'));

            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }

            _unitOfWork.Product.Remove(productToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete Successful" });
        }
```

```html
<a href="/admin/product/delete?id=${data}" class="btn btn-danger mx-2"> <i class="bi bi-pencil-square"></i>Delete</a>   
```

### SweetAlerts [104]

```js

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/product/getall' },
        "columns": [
            { data: 'title', "width": "10%" },
            { data: 'author', "width": "10%" },
            { data: 'isbn', "width": "10%" },
            { data: 'price', "width": "10%" },
            { data: 'category.name', "width": "10%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                     <a href="/admin/product/upsert?id=${data}" class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i>Edit</a>               
                     <a onClick=Delete("/admin/product/delete?id=${data}") class="btn btn-danger mx-2"> <i class="bi bi-pencil-square"></i>Delete</a>               
                    </div>`
                },
                "width": "15%"
            }
        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                }
            })
        }
    })
}
```

## Section 7: Home and Details Page

### Home Page [105]

```cs
@model IEnumerable<Product>

<div class="row pb-3">
    @foreach (var product in Model)
    {
        <div class="col-lg-3 col-sm-6">
            <div class="row p-2">
                <div class="col-12 p-1">
                    <div class="card border-0 p-3 shadow border-top border-bottom border-5 rounded">
                        <img src="@product.ImageUrl" class="card-img-top rounded" />
                        <div class="card-body pb-0">
                            <div class="pl-1">
                                <p class="card-title h5 text-dark opacity-75 text-uppercase text-center">@product.Title</p>
                                <p class="card-title text-warning text-center">by <b>@product.Author</b></p>
                            </div>
                            <div class="pl-1">
                                <p class="text-dark text-opacity-75 text-center mb-0">
                                    List Price:
                                    <span class="text-decoration-line-through">
                                        @product.ListPrice.ToString("c")
                                    </span>
                                </p>
                            </div>
                            <div class="pl-1">
                                <p class="text-dark text-opacity-75 text-center">
                                    As low as:
                                    <span>
                                        @product.Price100.ToString("c")
                                    </span>
                                </p>
                            </div>
                        </div>
                        <div>
                            <a href="#" class="btn btn-primary bg-gradient border-0 form-control">
                                Details
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    }
</div>
```

### Details Action Method [106]

```cs
<div>
    <a  asp-action="Details"
        asp-route-productId="@product.Id"
        class="btn btn-primary bg-gradient border-0 form-control">
        Details
    </a>
</div>
```

```cs
public IActionResult Details(int productId)
{
    Product product = _unitOfWork.Product
        .Get(p => p.Id == productId, includeProperties: "Category");
    
    return View(product);
}
```

### Details UI [107]

CourseContent\1 Details UI.txt

## Section 8: Identity in .NET Core

- Identity - Registration, Login, Passwords, Tables in  the Db, Security
- .NET team provided default identity implementation
- Web project -> Add -> New Scaffolded Item -> Identity
- Requires DB Context class, ours DbContext is in the separate project, so lets tune:

```cs
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
...
// Change DbContext to IdentityDbContext
    public class AppDbContext : IdentityDbContext
...
// and NB!
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ...
        }
```

### Scaffold Identity [108]

### Scaffold Identity Issue (NET8) [109]

There were issues and nuget conflicts

```
Error
There was an error running the selected code generator: 
'Package restore failed. Rolling back package changes for 'BulkyBookWeb'.'
```

So I merged scaffolded code manually

### Understand what Got Added [110]

On the AppDbContext we added
```cs
base.OnModelCreating(modelBuilder);
```
Class was changed to **IdentityDbContext**

Program.cs:

```cs
builder.Services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<AppDbContext>();
// Add service which adds a default identity
// AddEntityFrameworkStores() - we also added tables needed for identity
// Users table, Claims... etc.
// Here we binding EF with Identity tables 

builder.Services.AddRazorPages(); // Our scaffolded Razor views should work 

app.UseAuthentication(); // Authentication Before the Authorization. Check if the username and password are valid 

app.UseAuthorization(); // Based on your role you have access to some pages
...
app.MapRazorPages();
```

appsettings.json - it tries to add a new connection (we already have it)

_LoginPartial - register and login buttons

Areas\Identity - a lot of Razor Pages (we selected while scaffolding)

In C# 2.0 - both MVC and Razor pages, but now there is only Razor pages under maintenance

### Add Identity Tables [111]

#### What is missing?

```cs
builder.Services.AddRazorPages();

...

app.MapRazorPages();
```

#### Add-Migration addIdentityTables

AddEntityFrameworkStores() - we also added tables needed for identity, so

Add-Migration addIdentityTables

- AspNetRoles
- AspNetUsers
- AspNetRoleClaims
- AspNetUserClaims
- AspNetUserLogins
- AspNetUserRoles
- AspNetUserTokens

### Extend Identity User [112]

Models:

```cs
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BulkyBook.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string Name { get; set; }

        public string? StreetAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
    }
}
```

- Add ApplicationUser to the DBContext DbSets
- Add-Migration ExtendIdentityUser
- Update-Database


```sql
SELECT [Id]
      ,[UserName]
      ,[NormalizedUserName]
      ,[Email]
      ,[NormalizedEmail]
      ,[EmailConfirmed]
      ,[PasswordHash]
      ,[SecurityStamp]
      ,[ConcurrencyStamp]
      ,[PhoneNumber]
      ,[PhoneNumberConfirmed]
      ,[TwoFactorEnabled]
      ,[LockoutEnd]
      ,[LockoutEnabled]
      ,[AccessFailedCount]
      ,[City]
      ,[Discriminator]   -- <------- "IdentityUser" / "ApplicationRole"
      ,[Name]
      ,[PostalCode]
      ,[State]
      ,[StreetAddress]

  FROM [Bulky].[dbo].[AspNetUsers]
```

#### What is Discriminator field?

- Is it an Application User ("ApplicationRole") or Identity User

<https://stackoverflow.com/questions/28054254/what-is-a-discriminator-column-in-asp-net-migrations>

### Register a User [113]

```cs
builder.Services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<AppDbContext>();
```
test@gmail.com

Test123!

```sql
SELECT [Id], [UserName], [NormalizedUserName], [Email], [City], [Discriminator], [Name], [PostalCode], [State], [StreetAddress] FROM [Bulky].[dbo].[AspNetUsers]
-- Id	UserName	NormalizedUserName	Email	City	Discriminator	Name	PostalCode	State	StreetAddress
-- 22a26e4c-4301-4a15-aa17-4ce001cf04cd	test@gmail.com	TEST@GMAIL.COM	test@gmail.com	NULL	IdentityUser	NULL	NULL	NULL	NULL
```
- Discriminator column = **IdentityUser**
- No City, Name, PostalCode, State and StreetAddress

### Register an Application User [114]

Register.cshtml.cs:
- Injected Managers:
  - SignInManager
  - UserManager
  - ... RoleManager
- Handlers (Get and Post Handlers):
  - Create User On Post:

```cs
        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = CreateUser();

...

        private IdentityUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<IdentityUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(IdentityUser)}'. " +
                    $"Ensure that '{nameof(IdentityUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }
```

Change IdentityUser -> ApplicationUser

testAppUser@gmail.com

Test123!

Discriminator = ApplicationUser

AspNetRoles is empty (we haven't any role)

### Create Roles in Database [115]

Change

```cs
//builder.Services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
```

```cs
        public async Task OnGetAsync(string returnUrl = null)
        {
            // Hacky way
            if(!_roleManager.RoleExistsAsync(AppRole.Admin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(AppRole.Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(AppRole.Company)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(AppRole.Customer)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(AppRole.Employee)).GetAwaiter().GetResult();
            }

            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }
```

```sql
SELECT [Name],[NormalizedName],[ConcurrencyStamp] FROM [Bulky].[dbo].[AspNetRoles]
-- Name	NormalizedName	ConcurrencyStamp
-- Admin	ADMIN	NULL
-- Company	COMPANY	NULL
-- Customer	CUSTOMER	NULL
-- Employee	EMPLOYEE	NULL
```

Note, Fake EmailSender was created to inject it and omit injection errors

### Assign Roles on Registration [116]

testAdm1@gmail.com
Test123!

Issue

```
An unhandled exception occurred while processing the request.
NotSupportedException: No IUserTwoFactorTokenProvider<TUser> named 'Default' is registered.
Microsoft.AspNetCore.Identity.UserManager<TUser>.GenerateUserTokenAsync(TUser user, string tokenProvider, string purpose

NotSupportedException: No IUserTwoFactorTokenProvider<TUser> named 'Default' is registered.
Microsoft.AspNetCore.Identity.UserManager<TUser>.GenerateUserTokenAsync(TUser user, string tokenProvider, string purpose)
BulkyBookWeb.Areas.Identity.Pages.Account.RegisterModel.OnPostAsync(string returnUrl) in Register.cshtml.cs
+
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

```

Solution

```cs
builder.Services
    .AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders(); // Solution, because var code = await _userManager.GenerateEmailConfirmationTokenAsync(user); requires default token providers
```

testAdm2@gmail.com
Test123!

cust01@gmail.com
Test123!

```sql
select UserName, roles.Name as AppRole from [dbo].[AspNetUsers] u
left join [dbo].[AspNetUserRoles] userRoles on userRoles.UserId = u.Id
left join [dbo].[AspNetRoles] roles on roles.Id = userRoles.RoleId

-- UserName	AppRole
-- testAdm1@gmail.com	Admin
-- test@gmail.com	NULL
-- cust01@gmail.com	Customer
-- testAppUser@gmail.com	NULL
-- testAdm2@gmail.com	Admin
```
### Authorization in Project [117]

```cs
    @if (User.IsInRole(AppRole.Admin))
    {
        <li class="nav-item dropdown">
        ...
    }
```

But Customer can go to the url, so

```cs
    [Area("Admin")]
    [Authorize(Roles = AppRole.Admin)] // <----
    public class CategoryController : Controller
```

Now, Default route for access denied, so

```cs
builder.Services.ConfigureApplicationCookie(options => {
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Identity/Account/Logout";
    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
});
```
Note, **ConfigureApplicationCookie MUST be after the AddIdentity**!

Now only admin able to see pages

https://localhost:7209/Admin/Product

https://localhost:7209/Admin/Category  

and the Access Denied is shown for another roles

### Update Login and Register UI [118]

[] TODO: CSS and Bootstrap

```css
.divider-text:before,
.divider-text:after {
    color: white;
    content: "";
    flex: 1;
    border-bottom: 1px solid #555;
    margin: auto 0.25rem;
    box-shadow: 0 -2px;
}
```

### Register Other Fields [119]

testDetails@gmail.com
Test123!

### UI Bug [120]

_ViewStart.cshtml = to know which _Layout to use

[] TODO: I do not understand it fully yet

## Section 9: Company CRUD
### Why do we have a Company Role? [121]

Advantage of Company Users - they don not have to pay right away,
They will have 30 days (we call it NET 30) to make payment after the product have been placed.

Admin = All ops, Content Management

Employee = Ship products

User can belongs to a company

### Assignment 3 [122]
### Assignment 3 Solution - Company CRUD Operations [123]

### Display Company Dropdown [124]

User can belongs to a company

```cs
using BulkyBook.Models.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BulkyBook.Models
{
    public class ApplicationUser : IdentityUser
    {
...
        public int? CompanyId { get; set; }
        [ForeignKey("CompanyId")] 
        [ValidateNever]
        public Company Company { get; set; } // Navigation property
    }
}

```

### Toggle Company Dropdown [125]

But Company Dropdown should be used/visible only for Company Users!

So add style="display:none" to the Company dropdown and add the script:

```cs
@section Scripts {
    <partial name="_ValidationScriptsPartial" />

    <script>
        $(document).ready(function () {
            $('#Input_Role').change(function(){
                var selection = $('#Input_Role Option:Selected').text();
                if (selection == 'Company') {
                    $('#Input_CompanyId').show();
                }
                else {
                    $('#Input_CompanyId').hide();
                }
            })
        })
    </script>
}

```

### Register Company User [126]
```
companyUser@gmail.com
Test123!

SqlException: Invalid column name 'CompanyId'. 
// I forgot:
//1. in the Post method: user.CompanyId = Input.CompanyId;
//2. Update-Database
```

In the DB: User within the CompanyId was created

## Section 10: Shopping Cart

### Add Shopping Cart Model [127]

We do not have a model to save a shopping cart in the DataBase

```cs
namespace BulkyBook.Models {
    public class ShoppingCart {
        public int Id { get; set; }

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        [ValidateNever]
        public Product Product { get; set; }
        [Range(1, 1000, ErrorMessage = "Please enter a value between 1 and 1000")]
        public int Count { get; set; }

        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }
    }
}
```

### Add Shopping Cart to Repository and UoW [128]

As usual

### Add ApplicationUser Repository [129]

As usual but without the Update functionality for the App User

### What will be Model for Details Page? [130]

Details.cshtml - form will post product and count

### Add to Cart [131]

If form post we need Count and ProductId, so add hidden field

```cs
<form method="post">
    <input hidden asp-for="ProductId" />
```

- We need logged User Id, so Authorize attribute on this post
- Get the user id from Claims Identity
- Set shopping cart user Id 

```cs
        [HttpPost]
        [Authorize]
        public IActionResult Details(ShoppingCart cart)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            cart.ApplicationUserId = userId;
            
            _unitOfWork.ShoppingCart.Add(cart);
            _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }
```

Claim (contains user Id 4bd29062-da6b-4ed7-8cad-18db72907eec):

```
+		new System.Collections.Generic.ICollectionDebugView<System.Security.Claims.Claim>(new System.Security.Claims.ClaimsIdentity.ClaimsIdentityDebugProxy(claimsIdentity).Claims).Items[0]	{http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier: 4bd29062-da6b-4ed7-8cad-18db72907eec}	System.Security.Claims.Claim
```

But! We add everything to the cart, we do not update the product with the same Id.

```sql
SELECT TOP (100) [Id]
      ,[ProductId]
      ,[Count]
      ,[ApplicationUserId]
  FROM [Bulky].[dbo].[ShoppingCarts]

-- Id	ProductId	Count	ApplicationUserId
-- 1	5	        1       4bd29062-da6b-4ed7-8cad-18db72907eec
-- 2	2 (same!)   2       4bd29062-da6b-4ed7-8cad-18db72907eec
-- 3	2 (same!)   3       4bd29062-da6b-4ed7-8cad-18db72907eec
```

### Fix Issue with Add to Cart [132]

```cs
        [HttpPost]
        [Authorize]
        public IActionResult Details(ShoppingCart cart)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            cart.ApplicationUserId = userId;

            ShoppingCart cartFromDb = _unitOfWork.ShoppingCart
                .Get(u => u.ApplicationUserId == userId && u.ProductId == cart.ProductId);

            if(cartFromDb != null)
            {
                // shopping cart exists
                cartFromDb.Count += cart.Count;
                _unitOfWork.ShoppingCart.Update(cartFromDb);
            }
            else
            {
                // add a cart
                _unitOfWork.ShoppingCart.Add(cart);
            }
           
            _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }
```


### A Weird Bug [133]

And now interesting thing:

_unitOfWork.ShoppingCart.Update(cartFromDb); // EVEN  if I comment it, EF will update it in the database

Why?

- We are retrieving the shopping cart
- When you are retrieving something with EF Core, it constantly **tracking** that.
- We updated the Count: cartFromDb.Count += cart.Count;, and that was **tracked by EF Core**
- _unitOfWork.Save(); Will update our change even without the Update()
- But sometimes it could be harmful for the Application
- What if we should not track this entity?
- We can change this default behavior in the repository. dbSet.AsNoTracking();

```cs
            ShoppingCart cartFromDb = _unitOfWork.ShoppingCart
                .Get(u => u.ApplicationUserId == userId && u.ProductId == cart.ProductId);

            if(cartFromDb != null)
            {
                // shopping cart exists
                cartFromDb.Count += cart.Count;
                //_unitOfWork.ShoppingCart.Update(cartFromDb); // EVEN  if I comment it, EF will update it in the database
            }
            else
            {
...
            }
           
            _unitOfWork.Save(); // Will update our change even without the Update
...
```

#### dbSet.AsNoTracking()

```cs
        public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false)
        {
            IQueryable<T> query = tracked ? dbSet : dbSet.AsNoTracking();

            query = query.Where(filter);

            IncludePropertiesForDbSet (ref query, includeProperties);

            return query.FirstOrDefault();
        }
```

### Shopping Cart UI [134]

### Get Shopping Cart [135]

```cs
namespace BulkyBookWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class CartController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ShoppingCartViewModel ShoppingCartViewModel { get; set; }

        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            ShoppingCartViewModel shoppingCartViewModel = new()
            {
                ShoppingCartList = _unitOfWork.ShoppingCart
                    .GetAll(u => u.ApplicationUserId == userId,
                    includeProperties: "Product") // We also need Product
            };

            foreach (var cart in ShoppingCartViewModel.ShoppingCartList)
            {
                cart.Price = GetPriceBasedOnQuantity(cart);
                shoppingCartViewModel.OrderTotal += cart.Price;
            }

            return View(shoppingCartViewModel);
        }

        private double GetPriceBasedOnQuantity(ShoppingCart shoppingCart)
        {
            if(shoppingCart.Count <= 50)
            {
                return shoppingCart.Product.Price;
            }
            else
            {
                if(shoppingCart.Count <= 100)
                {
                    return shoppingCart.Product.Price50;
                }
                else
                {
                    return shoppingCart.Product.Price100;
                }
            }
        }
    }
}

// Shopping Cart:
```cs
{
...   
    [NotMapped]
    public double Price { get; set; } // not mapped to the DB, for display purpose ony
}
```

### Get Order Total in Shopping Cart [136]
Check commit

### Dynamic Shopping Cart [137]
Check commit

### Update Quantity in Shopping Cart [138]

Note, Param asp-route-cartId="@item.Id"

```cs
<a asp-action="plus" asp-route-cartId="@item.Id" class="btn btn-outline-primary bg-gradient py-2">
    <i class="bi bi-plus-square"></i>
</a>
```
```cs
        public IActionResult Plus(int cartId)
        {
            var cartFromDb = _unitOfWork.ShoppingCart.Get(c => c.Id == cartId);
            cartFromDb.Count++;
            _unitOfWork.ShoppingCart.Update(cartFromDb);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Minus(int cartId)
        {
            var cartFromDb = _unitOfWork.ShoppingCart.Get(c => c.Id == cartId);

            if (cartFromDb.Count <= 1)
            {
                //remove from cart
                _unitOfWork.ShoppingCart.Remove(cartFromDb);
            }
            else
            {
                cartFromDb.Count--;
                _unitOfWork.ShoppingCart.Update(cartFromDb);
            }

            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remove(int cartId)
        {
            var cartFromDb = _unitOfWork.ShoppingCart.Get(c => c.Id == cartId);
            _unitOfWork.ShoppingCart.Remove(cartFromDb);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }
```

### Order Summary UI [139]
Check commit

## Section 11: Order Confirmation

### Create Order Header and Details Model [140]

ValidateNever - do not validate during the update

OrderDetails class contains Prise
- Product Price could be updated
- The Price in Order Details will remain, should never change  

### Fix DateOnly EFCore7 Issue
```
The property 'OrderHeader.PaymentDueDate' could not be mapped because it is of type 'DateOnly', which is not a supported primitive type or a valid entity type. Either explicitly map this property, or ignore it using the '[NotMapped]' attribute or by using 'EntityTypeBuilder.Ignore' in 'OnModelCreating'.
```

https://code-maze.com/csharp-map-dateonly-timeonly-types-to-sql/

The OrderHeader contains DateOnly PaymentDueDate

Seems, EFCore7 cannot map DateOnly automatically as EFCore8-preview does.

```cs
    public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
    {
        public DateOnlyConverter() : base(
            dateOnly => dateOnly.ToDateTime(TimeOnly.MinValue),
            dateTime => DateOnly.FromDateTime(dateTime))
        { }
    }

    public class TimeOnlyConverter : ValueConverter<TimeOnly, TimeSpan>
    {
        public TimeOnlyConverter() : base(
            timeOnly => timeOnly.ToTimeSpan(),
            timeSpan => TimeOnly.FromTimeSpan(timeSpan))
        { }
    }
    
    public class DateOnlyComparer : ValueComparer<DateOnly>
    {
        public DateOnlyComparer() : base(
            (x, y) => x.DayNumber == y.DayNumber,
            dateOnly => dateOnly.GetHashCode())
        { }
    }

    public class TimeOnlyComparer : ValueComparer<TimeOnly>
    {
        public TimeOnlyComparer() : base(
            (x, y) => x.Ticks == y.Ticks,
            timeOnly => timeOnly.GetHashCode())
        { }
    }

    //In AppDbContext:
    protected override void ConfigureConventions(ModelConfigurationBuilder builder)
    {
        base.ConfigureConventions(builder);
        builder.Properties<DateOnly>().HaveConversion<DateOnlyConverter, DateOnlyComparer>().HaveColumnType("date");
        builder.Properties<TimeOnly>().HaveConversion<TimeOnlyConverter, TimeOnlyComparer>();
    }
```

### Add Order Header and Detail Repository [141]

### Make ShoppingCartVM more Dynamic [142]

### Summary GET Action Method [143]

```cs
        public IActionResult Summary()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            var cart = CartViewModel = new()
            {
                ShoppingCartList = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == userId, includeProperties: "Product"),
                OrderHeader = new()
            };

            var user = CartViewModel.OrderHeader.ApplicationUser = _unitOfWork.ApplicationUser.Get(u => u.Id == userId);

            cart.OrderHeader.Name = user.Name;
            cart.OrderHeader.PhoneNumber = user.PhoneNumber;
            cart.OrderHeader.StreetAddress = user.StreetAddress;
            cart.OrderHeader.City = user.City;
            cart.OrderHeader.State = user.State;
            cart.OrderHeader.PostalCode = user.PostalCode;

            foreach (var cartItem in CartViewModel.ShoppingCartList)
            {
                cartItem.Price = GetPriceBasedOnQuantity(cartItem);
                CartViewModel.OrderHeader.OrderTotal += cartItem.Price * cartItem.Count;
            }

            return View(CartViewModel);
        }
```

### Load Summary UI with Data [144]

### Order Status [145]

Order Status Management:
```
Customer				
Stage	        Makes Payment	    Order Confirmation	Processing	Shipped
Order Status:	Pending	Approved	Processing	        Shipped
Payment Status:	Pending	Approved	Approved	        Approved
				
Company				
Stage	        Order Confirmation	        Processing	                Shipped	Makes Payment
Order Status:	Approved	                Processing	                Shipped	Shipped
Payment Status:	ApprovedForDelayedPayment	ApprovedForDelayedPayment	ApprovedForDelayedPayment	Approved
```


### Summary POST Action [146]

```cs
        [HttpPost]
        [ActionName("Summary")]
        public IActionResult SummaryPOST()// Don't pass the ShoppingCartViewModel cartViewModel because we have Binding property
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            CartViewModel.ShoppingCartList = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == userId, includeProperties: "Product");

            CartViewModel.OrderHeader.OrderDate = DateTime.UtcNow;
            CartViewModel.OrderHeader.ApplicationUserId = userId;

            CartViewModel.OrderHeader.ApplicationUser = _unitOfWork.ApplicationUser.Get(u => u.Id == userId);

            foreach (var cartItem in CartViewModel.ShoppingCartList)
            {
                cartItem.Price = GetPriceBasedOnQuantity(cartItem);
                CartViewModel.OrderHeader.OrderTotal += cartItem.Price * cartItem.Count;
            }

            bool isRegularCustomerAccount = CartViewModel.OrderHeader.ApplicationUser.CompanyId.GetValueOrDefault() == 0;

            if(isRegularCustomerAccount)
            {
                // Capture payment
                CartViewModel.OrderHeader.PaymentStatus = PaymentStatus.Pending;
                CartViewModel.OrderHeader.OrderStatus = OrderStatus.Pending;
            }
            else
            {
                // It is Company User
                CartViewModel.OrderHeader.PaymentStatus = PaymentStatus.DelayedPayment;
                CartViewModel.OrderHeader.OrderStatus = OrderStatus.Approved;
            }

            _unitOfWork.OrderHeader.Add(CartViewModel.OrderHeader);
            _unitOfWork.Save();

            foreach(var cart in CartViewModel.ShoppingCartList)
            {
                OrderDetail orderDetail = new()
                {
                    ProductId = cart.ProductId,
                    OrderHeaderId = CartViewModel.OrderHeader.Id, // Id was populated after the _unitOfWork.Save();
                    Price = cart.Price,
                    Count = cart.Count
                };

                _unitOfWork.OrderDetail.Add(orderDetail);
                _unitOfWork.Save();
            }

            return View(CartViewModel); // need redirect to the confirmation page
        }

```

### Place Order for Company Accounts [147]

NB!
```cs
ShoppingCartVM.OrderHeader.ApplicationUser = _unitOfWork.ApplicationUser.Get(u => u.Id == userId);
```
Sql Exception Violation of Primary Key

CHANGED TO 

```cs
ApplicationUser applicationUser = _unitOfWork.ApplicationUser.Get(u => u.Id == userId);
```
BECAUSE

when you set the ShoppingCartVM.OrderHeader.ApplicationUser,

EF tries to create the new user with the same Id. 

When EF Core ties to add a navigation property - it will create new object in the database.

### Register for Stripe Account [148]

If the user in not a company, and it is a customer - we need to process payment.

<https://stripe.com/en-nl>

### Configure Stripe in Project [149]

```
Publishable key
pk_test_51...
Secret key
sk_test_51...
```

For the dev - appsettings.json

for the prod - save secrets in a secret place

appsettings.json:

```json
  "Stripe": {
    "PublishableKey": "pk_test_51...",
    "SecretKey": "sk_test_51..."
  }
}
```

```cs
namespace BulkyBook.Utility
{
    public class StripeSettings
    {
        public string PublishableKey { get; set; }

        public string SecretKey { get; set;}
    }
}
```


```cs
using Stripe;

...

builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));

...

StripeConfiguration.ApiKey = builder.Configuration.GetSection("Stripe:SecretKey").Get<string>();

```

### Add Helper Methods in Order Header Repository [150]

Stripe Payment -> Session -> PaymentIntentId (if session was successful)

```cs
namespace BulkyBook.DataAccess.Repository
{
    public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
    {
        private AppDbContext _db;

        public OrderHeaderRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(OrderHeader obj)
        {
            _db.OrderHeaders.Update(obj);
        }

        public void UpdateStatus(int id, string orderStatus, string? paymentStatus = null)
        {
            var orderFromDb = _db.OrderHeaders.FirstOrDefault(x => x.Id == id);
            if(orderFromDb != null)
            {
                orderFromDb.OrderStatus = orderStatus;

                if (!string.IsNullOrEmpty(paymentStatus))
                {
                    orderFromDb.PaymentStatus = paymentStatus;
                }
            }
        }

        public void UpdateStripePaymentID(int id, string sessionId, string paymentIntentId)
        {
            var orderFromDb = _db.OrderHeaders.FirstOrDefault(x => x.Id == id);
            if (!string.IsNullOrEmpty(sessionId))
            {
                orderFromDb.SessionId = sessionId;
            }

            if (!string.IsNullOrEmpty(paymentIntentId))
            {
                orderFromDb.PaymentIntentId = paymentIntentId;
                orderFromDb.PaymentDate = DateTime.Now;
            }
        }
    }
}

```

### Stripe in Action [151]

https://stripe.com/docs/api

https://stripe.com/docs/api/checkout/sessions

https://stripe.com/docs/api/checkout/sessions/create?lang=dotnet

```cs
        [HttpPost]
        [ActionName("Summary")]
        public IActionResult SummaryPOST()
        {
            ...

            if (isRegularCustomerAccount)
            {
                // It is regular customer account and we need to capture payment

                //https://stripe.com/docs/api/checkout/sessions/create?lang=dotnet
                //StripeConfiguration.ApiKey = already set

                var testDomain = "https://localhost:7209/";

                var options = new SessionCreateOptions
                {
                    SuccessUrl = $"{testDomain}customer/cart/OrderConfirmation?id={CartViewModel.OrderHeader.Id}",
                    CancelUrl = $"{testDomain}customer/cart/index",
                    LineItems = new List<SessionLineItemOptions>(),
                    Mode = "payment",
                };

                //LineItems = product details
                foreach (var item in CartViewModel.ShoppingCartList)
                {
                    var sessionLineItem = new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            UnitAmount = (long)item.Price * 100, // $20.50 => 2050
                            Currency = "usd",
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = item.Product.Title
                            }
                        },
                        Quantity = item.Count
                    };
                    options.LineItems.Add(sessionLineItem);
                }

                var service = new SessionService();
                Session session = service.Create(options);

                _unitOfWork.OrderHeader.UpdateStripePaymentID(CartViewModel.OrderHeader.Id, session.Id, session.PaymentIntentId);
                _unitOfWork.Save();
                Response.Headers.Add("Location", session.Url);

                return new StatusCodeResult(303);
            }
```


When you go to checkout, the session id is present in the OrderHeader table

cs_test_b1...

[] TODO
```
Microsoft.EntityFrameworkCore.DbUpdateException: 'An error occurred while saving the entity changes. See the inner exception for details.'
Microsoft.EntityFrameworkCore.DbUpdateException: 'An error occurred while saving the entity changes. See the inner exception for details.'

On the summary page I can place order with the empty orders details fields
Why are they empty?
Why it is possible to proceed?
```


Note, 

Browser "back" => Order Summary

Stripes "Back" => Carts Index page 

### Confirm Stripe Payment [152]

ok, we go to the OrderConfirmation

```cs
SuccessUrl = $"{testDomain}customer/cart/OrderConfirmation?id={CartViewModel.OrderHeader.Id}",
```

- How do we know that payment was successful?

- Get the session from Stripe and check the status.

#### Stripe Payment Status

https://stripe.com/docs/api/checkout/sessions/object#checkout_session_object-payment_status

```
payment_status
enum
The payment status of the Checkout Session, one of paid, unpaid, or no_payment_required. You can use this value to decide when to fulfill your customer’s order.

Possible enum values
paid - The payment funds are available in your account.
unpaid - The payment funds are not yet available in your account.
no_payment_required - The payment is delayed to a future date, or the Checkout Session is in setup mode and doesn’t require a payment at this time.
```

#### Order Confirmation

```cs
        public IActionResult OrderConfirmation(int orderId)
        {
            OrderHeader orderHeader = _unitOfWork.OrderHeader.Get(o => o.Id == orderId, includeProperties: "ApplicationUser");
            
            // do not care about delayed status

            if(orderHeader.PaymentStatus != PaymentStatus.DelayedPayment)
            {
                // this is order by customer

                SessionService sessionService = new();
                Session session = sessionService.Get(orderHeader.SessionId);

                if(session.PaymentStatus.ToLower() == StripePaymentStatus.Paid)
                {
                    // If payment was successful - update our statuses in the DB
                    _unitOfWork.OrderHeader.UpdateStripePaymentID(orderId, session.Id, session.PaymentIntentId);
                    _unitOfWork.OrderHeader.UpdateStatus(orderId, OrderStatus.Approved, PaymentStatus.Approved);
                    _unitOfWork.Save();
                }
            }

            // Clean the Shopping cart
            List<ShoppingCart> shoppingCarts = 
                _unitOfWork.ShoppingCart
                .GetAll(u => u.ApplicationUserId == orderHeader.ApplicationUserId)
                .ToList();

            _unitOfWork.ShoppingCart.RemoveRange(shoppingCarts);
            _unitOfWork.Save();

            return View(orderId);
        }
```

### Order Placed Successfully with Stripe [153]

Fixed orderId, 

So we have the order header with PaymentIntentId = pi_3Nn...

and OrderStatus, PaymentStatus = Approved, Approved

## Section 12: Order Management

### OrderVM and Order Controller [154]

Order Processing, Shipped

Company users - Make a payment later on 

Need an Order Management

1) Order Controller
2) Order View Model

### Order List UI [155]

Similar to Product List

### Add Status Filter [156]
### Make Status Selected Active [157]
### Demo - Filters in Order List [158]

### Order Details Get Action [159]

```cs
        public IActionResult Details(int orderId)
        {
            OrderViewModel orderViewModel = new()
            {
                OrderHeader = _unitOfWork.OrderHeader.Get(o => o.Id == orderId, includeProperties: "ApplicationUser"),

                OrderDetail = _unitOfWork.OrderDetail.GetAll(o => o.OrderHeaderId == orderId, includeProperties: "Product")
            };

            return View(orderViewModel);
        }
```

### Loading Order Details Header [160]

```cs
<div class="row my-1">
    <div class="col-3">Zip Code</div>
    <div class="col-9">
        @if (User.IsInRole(AppRole.Admin) || User.IsInRole(AppRole.Employee))
        {
            <input asp-for="OrderHeader.PostalCode" type="text" class="form-control" />
            <span asp-validation-for="OrderHeader.PostalCode" class="text-danger"></span>
        }
        else
        {
            <input asp-for="OrderHeader.PostalCode" readonly type="text" class="form-control" />
        }
    </div>
</div>
```

### Display Order Details [161]

### Update Order Details [162]

We have different buttons, how to POST different action methods?

NB!

```cs
<form method="post">
    <input asp-for="OrderHeader.Id" hidden />
```

```cs
        [HttpPost]
        [Authorize(Roles = $"{AppRole.Admin},{AppRole.Employee}")]
        public IActionResult UpdateOrderDetail()
        {
            var orderHeaderFromDb = _unitOfWork.OrderHeader.Get(o => o.Id == OrderViewModel.OrderHeader.Id);
            
            orderHeaderFromDb.Name = OrderViewModel.OrderHeader.Name;
            orderHeaderFromDb.PhoneNumber = OrderViewModel.OrderHeader.PhoneNumber;
            orderHeaderFromDb.StreetAddress = OrderViewModel.OrderHeader.StreetAddress;
            orderHeaderFromDb.City = OrderViewModel.OrderHeader.City;
            orderHeaderFromDb.State = OrderViewModel.OrderHeader.State;
            orderHeaderFromDb.PostalCode = OrderViewModel.OrderHeader.PostalCode;
            
            if (!string.IsNullOrEmpty(OrderViewModel.OrderHeader.Carrier))
            {
                orderHeaderFromDb.Carrier = OrderViewModel.OrderHeader.Carrier;
            }
            
            if (!string.IsNullOrEmpty(OrderViewModel.OrderHeader.TrackingNumber))
            {
                orderHeaderFromDb.Carrier = OrderViewModel.OrderHeader.TrackingNumber;
            }
            
            _unitOfWork.OrderHeader.Update(orderHeaderFromDb);
            _unitOfWork.Save();

            TempData["Success"] = "Order Details Updated Successfully.";

            return RedirectToAction(nameof(Details), new { orderId = orderHeaderFromDb.Id });
        }
```

### Only Admin and Employee Can See all Orders [163]

```cs
        //https://localhost:7209/Admin/Product/getall
        [HttpGet]
        public IActionResult GetAll(string status)
        {
            IEnumerable<OrderHeader> objOrderHeaders;

            if(User.IsInRole(AppRole.Admin) || User.IsInRole(AppRole.Employee))
            {
                // Admins sees orders from everyone
                objOrderHeaders = _unitOfWork.OrderHeader.GetAll(includeProperties: "ApplicationUser");
            }
            else
            {
                // User see his orders
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

                objOrderHeaders = _unitOfWork.OrderHeader.GetAll(u => u.ApplicationUserId == userId, 
                    includeProperties: "ApplicationUser");
            }

            switch (status)
            {
                ...
```

### Order Processing Buttons Logic [164]

```cs
@if (Model.OrderHeader.PaymentStatus == PaymentStatus.DelayedPayment &&
     Model.OrderHeader.OrderStatus == OrderStatus.Shipped)
{
    <button type="submit" class="btn btn-success form-control my-1">Pay Now</button>
}

@if (User.IsInRole(AppRole.Admin) || User.IsInRole(AppRole.Employee))
{
    if (Model.OrderHeader.OrderStatus == OrderStatus.Approved)
    {
        <button type="submit" class="btn btn-primary form-control my-1">Start Processing</button>
    }

    if (Model.OrderHeader.OrderStatus == OrderStatus.InProcess)
    {
        <button type="submit" class="btn btn-primary form-control my-1">Ship Order</button>
    }
    
    if (Model.OrderHeader.OrderStatus != OrderStatus.Refunded &&
        Model.OrderHeader.OrderStatus != OrderStatus.Cancelled &&
        Model.OrderHeader.OrderStatus != OrderStatus.Shipped)
    {
        <button type="submit" class="btn btn-danger form-control my-1">Cancel Order</button>
    }
}
```

### Ship Order [165]

#### Fields Validation

```cs
...
@section Scripts
    {
    <partial name="_ValidationScriptsPartial" />
    <script>
        function validateInput() {
            if (document.getElementById("trackingNumber").value == "") {
                Swal.fire({
                    icon: 'error',
                    title: 'Oops...',
                    text: 'Please enter tracking number!',
                });
                return false;
            }
            if (document.getElementById("carrier").value == "") {
                Swal.fire({
                    icon: 'error',
                    title: 'Oops...',
                    text: 'Please enter carrier!',
                });
                return false;
            }
            return true;
        }
    </script>
}
```

#### StartProcessing and ShipOrder

```cs
        [HttpPost]
        [Authorize(Roles = $"{AppRole.Admin},{AppRole.Employee}")]
        public IActionResult StartProcessing()
        {
            _unitOfWork.OrderHeader.UpdateStatus(OrderViewModel.OrderHeader.Id, OrderStatus.InProcess);
            _unitOfWork.Save();
            TempData["success"] = "Order Details Updated Successfully.";
            return RedirectToAction(nameof(Details), new { orderId = OrderViewModel.OrderHeader.Id });
        }

        [HttpPost]
        [Authorize(Roles = $"{AppRole.Admin},{AppRole.Employee}")]
        public IActionResult ShipOrder()
        {
            // Update Tracking and Carrier information
            var orderHeader = _unitOfWork.OrderHeader.Get(o => o.Id == OrderViewModel.OrderHeader.Id);
            orderHeader.TrackingNumber = OrderViewModel.OrderHeader.TrackingNumber;
            orderHeader.Carrier = OrderViewModel.OrderHeader.Carrier;
            orderHeader.OrderStatus = OrderStatus.Shipped;
            orderHeader.ShippingDate = DateTime.Now;

            // Update Payment info:
            if (orderHeader.PaymentStatus == PaymentStatus.DelayedPayment)
            {
                orderHeader.PaymentDueDate = DateOnly.FromDateTime(DateTime.Now.AddDays(30));
            }

            _unitOfWork.OrderHeader.Update(orderHeader);
            _unitOfWork.Save();

            TempData["success"] = "Order Shipped Successfully";
            return RedirectToAction(nameof(Details), new { orderId = OrderViewModel.OrderHeader.Id });
        }

```

### Cancel Order [166]

#### Cancel Order

```cs
        [HttpPost]
        [Authorize(Roles = $"{AppRole.Admin},{AppRole.Employee}")]
        public IActionResult CancelOrder()
        {
            var orderHeader = _unitOfWork.OrderHeader.Get(o => o.Id == OrderViewModel.OrderHeader.Id);

            if(orderHeader.PaymentStatus == PaymentStatus.Approved)
            {
                // Refund
                var options = new RefundCreateOptions
                {
                    Reason = RefundReasons.RequestedByCustomer,
                    PaymentIntent = orderHeader.PaymentIntentId
                };
                try
                {
                    var refundService = new RefundService();
                    Refund refund = refundService.Create(options);
                }
                catch (StripeException ex)
                {
                    TempData["error"] = ex.Message;
                    throw;
                }

                _unitOfWork.OrderHeader.UpdateStatus(orderHeader.Id, OrderStatus.Cancelled, PaymentStatus.Refunded);
            }
            else
            {
                _unitOfWork.OrderHeader.UpdateStatus(orderHeader.Id, OrderStatus.Cancelled, PaymentStatus.Cancelled);
            }
            _unitOfWork.Save();
            TempData["Success"] = "Order Cancelled Successfully.";
            return RedirectToAction(nameof(Details), new { orderId = OrderViewModel.OrderHeader.Id });
        }
```

#### Stripe Refund Event

The refund for $170.00 USD has been completed

```json
{
  "object": {
    "id": "ch_3NnOKiAlqQU8uFZK1Z7FVg6i",
    "object": "charge",
    "amount": 17000,
```

#### Double Refund StripeException

Also got a double click refund with the Stripe.StripeException: 'Charge ch_3NnOKiAlqQU8uFZK1Z7FVg6i has already been refunded.'

### There is some mess with Order and Payment Statuses

Author of the course mixed these statuses.

### Process Delayed Payment [167]

Pay Now for company users: the product should be shipped

```cs
        [ActionName("Details")]
        [HttpPost]
        public IActionResult DetailsPayNow()
        {
            OrderViewModel.OrderHeader = _unitOfWork.OrderHeader
                .Get(u => u.Id == OrderViewModel.OrderHeader.Id, includeProperties: "ApplicationUser");
            OrderViewModel.OrderDetail = _unitOfWork.OrderDetail
                .GetAll(u => u.OrderHeaderId == OrderViewModel.OrderHeader.Id, includeProperties: "Product");

            var domain = "https://localhost:7209/";
            var options = new SessionCreateOptions
            {
                SuccessUrl = domain + $"admin/order/PaymentConfirmation?orderHeaderId={OrderViewModel.OrderHeader.Id}",
                CancelUrl = domain + $"admin/order/details?orderId={OrderViewModel.OrderHeader.Id}",
                LineItems = new List<SessionLineItemOptions>(),
                Mode = "payment",
            };

            foreach (var item in OrderViewModel.OrderDetail)
            {
                var sessionLineItem = new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = (long)(item.Price * 100), // $20.50 => 2050
                        Currency = "usd",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = item.Product.Title
                        }
                    },
                    Quantity = item.Count
                };
                options.LineItems.Add(sessionLineItem);
            }

            var service = new SessionService();
            Session session = service.Create(options);
            _unitOfWork.OrderHeader.UpdateStripePaymentID(OrderViewModel.OrderHeader.Id, session.Id, session.PaymentIntentId);
            _unitOfWork.Save();
            Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);
        }

        public IActionResult PaymentConfirmation(int orderHeaderId)
        {
            OrderHeader orderHeader = _unitOfWork.OrderHeader.Get(u => u.Id == orderHeaderId);
            if (orderHeader.PaymentStatus == PaymentStatus.DelayedPayment)
            {
                //this is an order by company
                var service = new SessionService();
                Session session = service.Get(orderHeader.SessionId);

                if (session.PaymentStatus.ToLower() == StripePaymentStatus.Paid)
                {
                    _unitOfWork.OrderHeader.UpdateStripePaymentID(orderHeaderId, session.Id, session.PaymentIntentId);
                    _unitOfWork.OrderHeader.UpdateStatus(orderHeaderId, orderHeader.OrderStatus, PaymentStatus.Approved);
                    _unitOfWork.Save();
                }
            }
            return View(orderHeaderId);
        }

```

## Section 13: Advance Concepts
### Authorization [168]

### Session in .NET Core [169]

Sessions are not configured by default

```cs
// Add sessions to the services
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(100);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

...

app.UseSession();// Add sessions in our request pipeline
```

While Adding to the cart:

```cs
{
    ...
    _unitOfWork.ShoppingCart.Add(cart);
    _unitOfWork.Save();

    int cartItemsCount = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == userId).Count();
    HttpContext.Session.SetInt32(AppSession.ShoppingCart, cartItemsCount);
}
```

Cannot access HttpContext in _Layout

In a View you have to explicitly inject that

In _Layout:

```cs
@using Microsoft.AspNetCore.Http
@inject IHttpContextAccessor HttpContextAccessor
...

```

```cs
@if (@HttpContextAccessor.HttpContext.Session.GetInt32(AppSession.ShoppingCart) != null)
{
    <li class="nav-item">
        <a class="nav-link" asp-area="Customer" asp-controller="Cart" asp-action="Index">
            <i class="bi bi-cart"></i> &nbsp;
            (@HttpContextAccessor.HttpContext.Session.GetInt32(AppSession.ShoppingCart))
        </a>
    </li>
}
else
{
    <li class="nav-item">
        <a class="nav-link" asp-area="Customer" asp-controller="Cart" asp-action="Index">
            <i class="bi bi-cart"></i> &nbsp;
            (0)
        </a>
    </li>
}
```

### Remove from Session and Bug [170]

1) Now cart On UI is 0 while login
2) + Need clear on logout, 
3) + decrement on delete from shopping cart

#### Login

```cs
        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            if(claim != null) // null if user is not logged in
            {
                var userId = claim.Value;
                int cartItemsCount = _unitOfWork.ShoppingCart.GetAll(c => c.ApplicationUserId == userId).Count();
                HttpContext.Session.SetInt32(AppSession.ShoppingCart, cartItemsCount);
            }

            IEnumerable<Product> productList = _unitOfWork.Product
                .GetAll(includeProperties: "Category");
            
            return View(productList);
        }
```

#### Remove() and Minus() Action Methods

```cs
        public IActionResult Remove(int cartId)
        {
            var cartFromDb = _unitOfWork.ShoppingCart.Get(c => c.Id == cartId);
            
            int cartItemsCount = _unitOfWork.ShoppingCart
                .GetAll(u => u.ApplicationUserId == cartFromDb.ApplicationUserId).Count() - 1;
            HttpContext.Session.SetInt32(AppSession.ShoppingCart, cartItemsCount); // Count() - 1 because on the next line we will remove this record

            _unitOfWork.ShoppingCart.Remove(cartFromDb);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }
```

### Bug Solution and Logout [171]

#### Bug AsNoTracking() so pass tracked true
```
System.InvalidOperationException: 'The instance of entity type 'ShoppingCart' cannot be tracked because another instance with the same key value for {'Id'} is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached. Consider using 'DbContextOptionsBuilder.EnableSensitiveDataLogging' to see the conflicting key values.'
```

Remember?
```cs
        public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false)
        {
            IQueryable<T> query = tracked ? dbSet : dbSet.AsNoTracking();

            query = query.Where(filter);

            IncludePropertiesForDbSet(ref query, includeProperties);

            return query.FirstOrDefault();
        }
```

so use

```cs
var cartFromDb = _unitOfWork.ShoppingCart.Get(c => c.Id == cartId, tracked: true);
```

#### Logout: Clear Session

For Logout in OnPost() Logout.cshtml.cs add HttpContext.Session.Clear():

Bulky\BulkyWeb\Areas\Identity\Pages\Account\Logout.cshtml.cs

```cs
        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();

            HttpContext.Session.Clear();
...
```

### Create View Component [172]
### View Component in Action [173]
### Facebook Social Login [174]
### Facebook Login in Action [175]
### Creating Admin and Employee Accounts [176]
### Session Bug [177]

## Section 14: Deployment & Email
### DBInitializer [178]
### DBInitializer Implementation [179]
### DBInitializer in Action [180]
### SendGrid Email Setup [181]
### SendGrid in Action [182]
### Create Azure SQL Server and Database [183]
### Downgrade to Net 7 [184]
### Azure Production Deployment [185]
### Azure Deployment in Action [186]
### Facebook Url [187]
### Facebook Url Error [188]

## Section 15: User Management
### Display User List [189]
### Display Company Name [190]
### Display Roles [191]
### Lock Unlock Action Method [192]
### Lock Unlock in Action [193]
### Assignment 4 - User Role [194]
### Assignment 4 Solution Part 1 - View Code [195]
### Assignment 4 Solution Part 2 - Role Logic [196]

## Section 16: Multiple Product Image
### Next Task [197]
### Remove ImageUrl from Product [198]
### Product Image Table [199]
### Add Product Image Repository [200]
### Upload Images on Product Upsert [201]
### Demo - Upload Images [202]
### Display Image on Update Product Page [203]
### Delete Image [204]
### Delete Product [205]
### Display Image in Shopping Cart [206]
### Bootstrap Carousel [207]
### Assignment 5 - User Controller [208]
### Assignment 5 Solution - User Controller [209]
### Microsoft Social Login [210]
### Upgrade .NET Version [211]
### Deploy Application to Azure using Visual Studio [212]