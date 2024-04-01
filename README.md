# DBVISIT_TEST


# Requirements

To run this project, you will need:

- Visual Studio 2022 or later
- SpecFlow Visual Studio extension
- .NET Core 6.0 or later
- Chrome browser version 118


```csproj
  <ItemGroup>
    <PackageReference Include="DotNetSeleniumExtras.WaitHelpers" Version="3.11.0" />
    <PackageReference Include="ExtentReports" Version="4.1.0" />
    <PackageReference Include="Gherkin" Version="27.0.0" />
    <PackageReference Include="log4net" Version="2.0.15" />
    <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.7.2" />
    <PackageReference Include="Selenium.Support" Version="4.14.1" />
    <PackageReference Include="Selenium.WebDriver" Version="4.14.1" />
    <PackageReference Include="SpecFlow" Version="3.9.74" />
    <PackageReference Include="SpecFlow.Plus.LivingDocPlugin" Version="3.9.57" />
    <PackageReference Include="SpecFlow.NUnit" Version="3.9.74" />
    <PackageReference Include="nunit" Version="3.13.3" />
    <PackageReference Include="NUnit3TestAdapter" Version="4.5.0" />
    <PackageReference Include="FluentAssertions" Version="6.12.0" />
  </ItemGroup>
```

# Installation

1. Open the solution in Visual Studio.
2. Restore the NuGet packages.
3. Build the solution.
4. Open the Test Explorer window.
5. Click on "Run All" to run all the tests.

# Structure

The structure of the project:

![](https://lh3.googleusercontent.com/pw/AJFCJaWku2KhGiVqLIdhP8GUdrgZFrhnYJo082WLP4lrSYhBxfFOM8leWu2k9RtXy3iqh3FN33RLQHtPkj5Yi54bd3jUs0BbEBMk0x8o28bpVOSlIwW9p3ZjNekAmtrGBPEJ6yLhIw5pF9dzwhum7MqTGFe1Yb_jSAP-LkaFnfD_rhhyokO96-yavKGp5AL4zfcjDf6zXZoOY7Bmkrn5faUc_qAkoHdzpSGACzw3VQAuSt8SmzEvrUqBwH7k9F8nZ5tG-1pQM22_lR_PHWMTSlqp4MRAOY6kAhqgUHe0fSms2WmgitdW79esa-kWDe-_zXiuOEb-OnbYwgcv_pTTMc0mjhZBtelpcjWNgHazjWczsr2xqA9in-_5zUroHpSr4G09ip5A5mFFhG2fuVYrj7LnJWQ-OVIndGDqmOenxpUFsG4AXMUs6J94-04Ri-TILcmzhcDIeznAdS4krP0yGzGncH3I8nqm67Lf_4FlGw-ppDET66vukGCR5hjMJjmm91oSF8TKC9L7Y96QgSYyMY0CDXGNe43JVdENrpMncOUhLFyC1yxzvaqFABjErbxpq4IpK9a6I0Z2uSO7-J-iGLRLByXfaoDn6C8KvmfuQ5iQMDiaiehxY6QxWA78gPMWsPTGAVen-lwXJF8oU57GUDaMiX4JYppGLNSHkI9F0r7HrJ9m4JLnFizAZvhZ6o38XjNo70l8yflqy5-hSi3fEhB2mY4r9mwFoV0ARx8azPdgE-ryPvThlZe1QteWjRmz9-wU7IzoDok1aqDLBWZJwNUy4rVcgVgMFHcBTaDEF2X_lBT0Re9Y1GAG2EyRok0t0b-XXwhZl-YG6ptsVzHVrWcEK6apD31OGk50CuTwqXJv9AjEQETL0-jBAiO_-lBIxX6sK7GHKDViPxYUMSk3l8ec4ETC=w640-h792-s-no?authuser=0)

# Tech Stack

Selenium, Specflow, log4net, Extentreport, NUnit, Gherkin, PageObject

# Highlight

1. Store all configuration files in the config folder for easy management

2. Easily use selenium by calling the selenium APIs already wrapped in CommonWeb.cs

3. Easily run your browser by storing the `xxxdriver.exe` corresponding to your browser version in the Driver folder.

4. All daily log files are generated in the Logs folder and can show the location of the logged code, log time, log level and content

   ```log
  2023-10-25 19:56:17,902 INFO [NonParallelWorker] DBVISIT_TEST.Core.CommonWeb.Open(58) | Open Browser: https://172.25.156.92:4433
2023-10-25 19:56:23,537 INFO [NonParallelWorker] DBVISIT_TEST.Core.CommonWeb.MaxWindow(306) | Set max window
2023-10-25 19:56:34,196 INFO [NonParallelWorker] DBVISIT_TEST.Core.CommonWeb.GetScreenShot(267) | Get Screenshot
2023-10-25 19:56:34,492 INFO [NonParallelWorker] DBVISIT_TEST.Core.CommonWeb.Quit(339) | Quit the browser
2023-10-25 19:56:34,512 INFO [NonParallelWorker] DBVISIT_TEST.Core.CommonWeb.Open(58) | Open Browser: https://172.25.156.92:4433
2023-10-25 19:56:37,227 INFO [NonParallelWorker] DBVISIT_TEST.Core.CommonWeb.MaxWindow(306) | Set max window
2023-10-25 19:56:46,593 INFO [NonParallelWorker] DBVISIT_TEST.Core.CommonWeb.Type(376) | Type the element with: 1
2023-10-25 19:56:46,846 INFO [NonParallelWorker] DBVISIT_TEST.Core.CommonWeb.Type(376) | Type the element with: 123456
2023-10-25 19:56:47,071 INFO [NonParallelWorker] DBVISIT_TEST.Core.CommonWeb.Click(350) | Click element:xpath=/html/body/div[1]/section[2]/form/div/button
2023-10-25 19:56:47,406 INFO [NonParallelWorker] DBVISIT_TEST.Core.CommonWeb.Quit(339) | Quit the browser
2023-10-25 19:57:11,717 INFO [NonParallelWorker] DBVISIT_TEST.Core.CommonWeb.Open(58) | Open Browser: https://172.25.156.92:4433
2023-10-25 19:57:14,444 INFO [NonParallelWorker] DBVISIT_TEST.Core.CommonWeb.MaxWindow(306) | Set max window
2023-10-25 19:57:24,740 INFO [NonParallelWorker] DBVISIT_TEST.Core.CommonWeb.GetScreenShot(267) | Get Screenshot
2023-10-25 19:57:24,979 INFO [NonParallelWorker] DBVISIT_TEST.Core.CommonWeb.Quit(339) | Quit the browser
2023-10-25 19:57:39,592 INFO [NonParallelWorker] DBVISIT_TEST.Core.CommonWeb.Open(58) | Open Browser: https://172.25.156.92:4433
2023-10-25 19:57:41,907 INFO [NonParallelWorker] DBVISIT_TEST.Core.CommonWeb.MaxWindow(306) | Set max window
2023-10-25 19:57:52,217 INFO [NonParallelWorker] DBVISIT_TEST.Core.CommonWeb.GetScreenShot(267) | Get Screenshot
2023-10-25 19:57:52,439 INFO [NonParallelWorker] DBVISIT_TEST.Core.CommonWeb.Quit(339) | Quit the browser
2023-10-25 19:58:24,310 INFO [NonParallelWorker] DBVISIT_TEST.Core.CommonWeb.Open(58) | Open Browser: https://172.25.156.92:4433
2023-10-25 19:58:26,696 INFO [NonParallelWorker] DBVISIT_TEST.Core.CommonWeb.MaxWindow(306) | Set max window
2023-10-25 19:59:18,325 INFO [NonParallelWorker] DBVISIT_TEST.Core.CommonWeb.Open(58) | Open Browser: https://172.25.156.92:4433
2023-10-25 19:59:21,118 INFO [NonParallelWorker] DBVISIT_TEST.Core.CommonWeb.MaxWindow(306) | Set max window
2023-10-25 19:59:31,410 INFO [NonParallelWorker] DBVISIT_TEST.Core.CommonWeb.GetScreenShot(267) | Get Screenshot
2023-10-25 19:59:31,653 INFO [NonParallelWorker] DBVISIT_TEST.Core.CommonWeb.Quit(339) | Quit the browser
2023-10-25 20:14:12,948 INFO [NonParallelWorker] DBVISIT_TEST.Core.CommonWeb.Open(58) | Open Browser: https://172.25.156.92:4433
2023-10-25 20:14:16,175 INFO [NonParallelWorker] DBVISIT_TEST.Core.CommonWeb.MaxWindow(306) | Set max window
2023-10-25 20:14:26,575 INFO [NonParallelWorker] DBVISIT_TEST.Core.CommonWeb.GetScreenShot(267) | Get Screenshot
2023-10-25 20:14:26,866 INFO [NonParallelWorker] DBVISIT_TEST.Core.CommonWeb.Quit(339) | Quit the browser
2023-10-25 20:15:18,503 INFO [15] DBVISIT_TEST.Core.CommonWeb.Open(58) | Open Browser: https://172.25.156.92:4433
2023-10-25 20:17:04,536 INFO [NonParallelWorker] DBVISIT_TEST.Core.CommonWeb.Open(58) | Open Browser: https://172.25.156.92:4433
2023-10-25 20:17:06,498 INFO [NonParallelWorker] DBVISIT_TEST.Core.CommonWeb.MaxWindow(306) | Set max window
2023-10-25 20:17:06,666 INFO [NonParallelWorker] DBVISIT_TEST.Core.CommonWeb.Click(350) | Click element:id=details-button
2023-10-25 20:17:06,832 INFO [NonParallelWorker] DBVISIT_TEST.Core.CommonWeb.Click(350) | Click element:id=proceed-link
2023-10-25 20:17:07,246 INFO [NonParallelWorker] DBVISIT_TEST.Core.CommonWeb.Type(376) | Type the element with: 
2023-10-25 20:17:07,466 INFO [NonParallelWorker] DBVISIT_TEST.Core.CommonWeb.Type(376) | Type the element with: 
2023-10-25 20:17:07,656 INFO [NonParallelWorker] DBVISIT_TEST.Core.CommonWeb.Click(350) | Click element:xpath=/html/body/div[1]/section[2]/form/div/button
2023-10-25 20:17:18,020 INFO [NonParallelWorker] DBVISIT_TEST.Core.CommonWeb.GetScreenShot(267) | Get Screenshot
2023-10-25 20:17:18,245 INFO [NonParallelWorker] DBVISIT_TEST.Core.CommonWeb.Quit(339) | Quit the browser
2023-10-25 20:50:52,013 INFO [15] DBVISIT_TEST.Core.CommonWeb.Open(58) | Open Browser: https://172.25.156.92:4433
2023-10-25 20:51:45,767 INFO [15] DBVISIT_TEST.Core.CommonWeb.MaxWindow(306) | Set max window
2023-10-25 20:51:51,180 INFO [15] DBVISIT_TEST.Core.CommonWeb.Click(350) | Click element:id=details-button
2023-10-25 20:51:53,603 INFO [15] DBVISIT_TEST.Core.CommonWeb.Click(350) | Click element:id=proceed-link
2023-10-25 20:52:06,991 INFO [15] DBVISIT_TEST.Core.CommonWeb.Type(376) | Type the element with: 
2023-10-25 20:52:07,212 INFO [15] DBVISIT_TEST.Core.CommonWeb.Type(376) | Type the element with: 
2023-10-25 20:52:07,395 INFO [15] DBVISIT_TEST.Core.CommonWeb.Click(350) | Click element:xpath=/html/body/div[1]/section[2]/form/div/button
2023-10-25 20:55:36,721 INFO [15] DBVISIT_TEST.Core.CommonWeb.Open(58) | Open Browser: https://172.25.156.92:4433
2023-10-25 20:56:07,892 INFO [15] DBVISIT_TEST.Core.CommonWeb.MaxWindow(306) | Set max window
2023-10-25 20:56:09,813 INFO [15] DBVISIT_TEST.Core.CommonWeb.Click(350) | Click element:id=details-button
2023-10-25 20:56:10,811 INFO [15] DBVISIT_TEST.Core.CommonWeb.Click(350) | Click element:id=proceed-link
2023-10-25 20:56:25,054 INFO [15] DBVISIT_TEST.Core.CommonWeb.Quit(339) | Quit the browser
2023-10-25 20:58:25,249 INFO [15] DBVISIT_TEST.Core.CommonWeb.Open(58) | Open Browser: https://172.25.156.92:4433
2023-10-25 20:58:37,436 INFO [15] DBVISIT_TEST.Core.CommonWeb.MaxWindow(306) | Set max window
2023-10-25 20:58:39,066 INFO [15] DBVISIT_TEST.Core.CommonWeb.Click(350) | Click element:id=details-button
2023-10-25 20:58:39,958 INFO [15] DBVISIT_TEST.Core.CommonWeb.Click(350) | Click element:id=proceed-link
2023-10-25 20:58:47,967 INFO [15] DBVISIT_TEST.Core.CommonWeb.Type(376) | Type the element with: admin
2023-10-25 20:58:48,210 INFO [15] DBVISIT_TEST.Core.CommonWeb.Type(376) | Type the element with: admin
2023-10-25 20:58:48,774 INFO [15] DBVISIT_TEST.Core.CommonWeb.Click(350) | Click element:xpath=/html/body/div[1]/section[2]/form/div/button
2023-10-25 20:58:50,978 INFO [15] DBVISIT_TEST.Core.CommonWeb.Quit(339) | Quit the browser

   ```

5. Easy to manage Extent Reports which are generated in the reports folder which sort by date, under each date sort by time

6. This report can log information such as testers,test environment test start time, test end time, features, test results, etc.

7. If the test fails, a screenshot will be included in the report
8. All failed screenshots will also be stored in the screenshots folder to distinguish the time of the screenshot



