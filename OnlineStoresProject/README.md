"# Selenium_CSharp_NUnit" 

For running the test, open the solution in Visual Studio and either right click and choose run all tests
Or open test explorer from the Test Tab in Visual Studio and then run the tests as per categories which are none other than tags in TestNG
Also, You can run all the tests from Test Explorer by clicking the first run button and a single test by clicking on second run button

The project has accessed credentials from excel file which is named TestData.xls which is present in main project structure and TestDataAccess
Enter your credentials under username and password. 
Then your tests will start working. 

As part of POC, I have added two tests one is smoke and other is sanity. One checks the redirection to the website with assertion of the title. 
Another check if I am able to successfully login to the application and then with the help of assertion checking whether I have succcessfully login or not.

Extent Report will be generated in Reports Folder. 

If any screenshot got failed, will be present in Screenshots folder.
